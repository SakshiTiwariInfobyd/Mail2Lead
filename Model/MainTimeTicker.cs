using AdminTool.DataBase;
using AdminTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AdminTool.Model
{
    public class MainTimeTicker
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
                        StringBuilder oSB = new StringBuilder();
                        //Check Every Mail
                        IEnumerable<MailMessage> mailMessages = mailHelper.getMsgSentAfter(dtProcessed);
                        mailHelper.disconnect();

                        foreach (MailMessage mailMessage in mailMessages)
                        {
                            try
                            {
                                dtEmailTime = DateTime.Now;
                                string sMailContent = mailMessage.Body;

                                sMailContent = mailMessage.Subject + " " + sMailContent;
                                string tempDate = mailMessage.Headers["Date"];

                                if (DateTime.TryParse(tempDate, out dtEmailTime))
                                    dtEmailTime = Convert.ToDateTime(tempDate);
                                else
                                    dtEmailTime = DateTime.Now;

                                dtLastProcessed = dtEmailTime;

                                sMailContent = HelperClass.StripHTML(sMailContent);  //remove html tags form content
                                DataTable ListOfAllSubject = databaseProvider.getListOfAllUserSubject(UserId);

                                if (ListOfAllSubject.Rows.Count < 0) { return; }

                                // Insert MailInto DataBase

                                for (int SubjectRowNo = 0; SubjectRowNo < ListOfAllSubject.Rows.Count; SubjectRowNo++)
                                {
                                    string SubjectLine = ListOfAllSubject.Rows[SubjectRowNo]["subjectLine"].ToString();


                                    if (sMailContent.Contains(SubjectLine))
                                    {
                                        //string SubjectLine = ListOfAllSubject.Rows[SubjectRowNo]["subjectLine"].ToString();
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
                                                        string ValueForColumnHeader = Temp1[0];
                                                        if (ValueForColumnHeader.Trim().Length > 0)
                                                        {
                                                            string result = databaseProvider.InsertMailSplitInfoFromBody(DataBaseMailId, ValueForColumnHeader, contentSplitId);
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