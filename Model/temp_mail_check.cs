using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AdminTool.DataBase;
using System.Text;

namespace AdminTool.Model
{
    public class temp_mail_check
    {
        private static DateTime dtProcessed = DateTime.Now.ToUniversalTime();
        private static DateTime dtAppStart = DateTime.Now.ToUniversalTime();
        static DataBaseProvider databaseProvider = new DataBaseProvider();
        // static DataTable ListOfAllSubject = new DataTable();

        public static void SendEmailStarted(int UserId)
        {
            string Email, token, Password;
            int APILimit, Service;
            DateTime dtEmailTime, dtLastProcessed, dtMailDate;
            try
            {
                DataTable UserInfo = databaseProvider.getUserInfoById(UserId);
                if (UserInfo.Rows.Count < 0)
                { return; }

                Email = UserInfo.Rows[0]["EmailId"].ToString();
                token = UserInfo.Rows[0]["configurationAuthToken"].ToString();
                Password = UserInfo.Rows[0]["password"].ToString();
                APILimit = Convert.ToInt32(UserInfo.Rows[0]["apiLimit"].ToString());
                Service = 1;
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(token) || Service == 0)
                    return;

                MailHelper mailHelper = new MailHelper();
                if (mailHelper.connect(Email, Password))
                {
                    try
                    {
                        //Get last Processed Mail Date in GMT HelperClass.Format
                        dtProcessed = databaseProvider.GetLastProcessedTime(UserId);
                        DataTable ListOfAllSubject = databaseProvider.getListOfAllUserSubject(UserId);

                        StringBuilder oSB = new StringBuilder();
                        //Check Every Mail
                        dtProcessed = DateTime.Now.AddDays(-1);
                        DataTable usermail = databaseProvider.GetUserTempMail();
                        for (int xy = 0; xy < usermail.Rows.Count; xy++)
                        {
                            try
                            {
                                dtEmailTime = DateTime.Now.AddDays(-1);
                                string sMailContent = usermail.Rows[xy]["mail_content_body"].ToString() + usermail.Rows[xy]["subjectLine"].ToString();
                                dtLastProcessed = dtEmailTime;
                                sMailContent = HelperClass.StripHTML(sMailContent);  //remove html tags form content
                           
                                if (ListOfAllSubject.Rows.Count < 0) { return; }

                                // Insert MailInto DataBase

                                for (int SubjectRowNo = 0; SubjectRowNo < ListOfAllSubject.Rows.Count; SubjectRowNo++)
                                {
                                    string SubjectLine = ListOfAllSubject.Rows[SubjectRowNo]["subjectLine"].ToString();


                                    if (sMailContent.Contains(SubjectLine))
                                    {
                                        int SubjectId = Convert.ToInt32(ListOfAllSubject.Rows[SubjectRowNo]["id"].ToString());

                                        // Insert MailInto DataBase
                                        int DataBaseMailId = databaseProvider.InsertMailIntoDataBase(SubjectId, sMailContent, dtEmailTime);
                                        if (DataBaseMailId < 0)
                                            return;

                                        DataTable UserMailToLeadColumnHeader = databaseProvider.getListOfMailContentSplitInfo(SubjectId);
                                        bool mailSplitStatus = true;
                                        for (int LeadRowNo = 0; LeadRowNo < UserMailToLeadColumnHeader.Rows.Count; LeadRowNo++)
                                        {
                                            string splitStartText, splitEndText;
                                            int columnHeaderId, contentSplitId;
                                            splitStartText = UserMailToLeadColumnHeader.Rows[LeadRowNo]["startText"].ToString();
                                            splitEndText = UserMailToLeadColumnHeader.Rows[LeadRowNo]["endText"].ToString();
                                            columnHeaderId = Convert.ToInt32(UserMailToLeadColumnHeader.Rows[LeadRowNo]["columnHeaderId"].ToString());
                                            contentSplitId = Convert.ToInt32(UserMailToLeadColumnHeader.Rows[LeadRowNo]["id"].ToString());

                                            if (sMailContent.Contains(splitStartText))
                                            {
                                                string[] Temp = sMailContent.Split(new string[] { splitStartText }, StringSplitOptions.None);
                                                if (Temp.Length > 0)
                                                {
                                                    string[] Temp1 = Temp[1].Split(new string[] { splitEndText }, StringSplitOptions.None);
                                                    if (Temp1.Length > 0)
                                                    {
                                                        string ValueForColumnHeader = Temp1[0].Trim();
                                                        if (ValueForColumnHeader.Trim().Length > 0)
                                                        {
                                                            string result;
                                                            if (Convert.ToInt32(UserMailToLeadColumnHeader.Rows[LeadRowNo]["IsValueSplit"].ToString()) > 0)
                                                            {
                                                                Temp1 = null;
                                                                if (UserMailToLeadColumnHeader.Rows[LeadRowNo]["splitType"].ToString().Trim().ToLower() == "space")
                                                                {
                                                                    Temp1 = ValueForColumnHeader.Split(' ');
                                                                }
                                                                else if (UserMailToLeadColumnHeader.Rows[LeadRowNo]["splitType"].ToString().Trim().ToLower() == "newline")
                                                                {
                                                                    Temp1 = ValueForColumnHeader.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                                                }
                                                                else
                                                                {
                                                                    string text = UserMailToLeadColumnHeader.Rows[LeadRowNo]["splitValueText"].ToString().Trim().ToLower();
                                                                    Temp1 = ValueForColumnHeader.Split(new string[] { text }, StringSplitOptions.None);
                                                                }
                                                                if (Temp1.Length > 1)
                                                                {
                                                                    if (Convert.ToInt32(UserMailToLeadColumnHeader.Rows[LeadRowNo]["splitIndex"].ToString()) > 0)
                                                                    {

                                                                        ValueForColumnHeader = Temp1[1].ToString().Trim();
                                                                        if (string.IsNullOrEmpty(ValueForColumnHeader))
                                                                        {
                                                                            for (int te = 1; te < Temp1.Length; te++)
                                                                            {
                                                                                if (string.IsNullOrEmpty(ValueForColumnHeader))
                                                                                {
                                                                                    if (!string.IsNullOrEmpty(Temp1[te].ToString().Trim()))
                                                                                    {
                                                                                        ValueForColumnHeader = Temp1[te].ToString().Trim();
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        ValueForColumnHeader = Temp1[0].ToString();
                                                                    }
                                                                }

                                                            }

                                                            result = databaseProvider.InsertMailSplitInfoFromBody(DataBaseMailId, ValueForColumnHeader, contentSplitId);




                                                            if (result.ToLower() != "success")
                                                            {
                                                                // mailSplitStatus = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (mailSplitStatus)
                                        {
                                            databaseProvider.updateMailSplitContentCompleteStatus(DataBaseMailId);
                                        }
                                    }
                                }


                            }
                            catch (Exception ex)
                            {
                                databaseProvider.logApplicationError("ERROR WHILE PROCESSING MAIL INTO DATABASE " + ex.Message, "Information");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        databaseProvider.logApplicationError("ERROR WHILE PROCESSING MAIL INTO DATABASE " + ex.Message, "Information");
                    }
                }


                //Fetch Leads Info From Database and Update same into CRM
                SendInformationIntoCrm.SendInformationIntoCRMFromDB(UserId);

                // Send SumaryMail to team
                if (DateTime.Now.Hour <= 1)
                    summaryEmail.SendSumaryMail(UserId);
            }
            catch (Exception ex) { }
        }
    }
}