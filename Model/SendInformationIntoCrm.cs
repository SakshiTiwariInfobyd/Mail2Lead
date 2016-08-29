using AdminTool.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace AdminTool.Model
{
    public class SendInformationIntoCrm
    {
        static DataBaseProvider databaseProvider = new DataBaseProvider();

        public static void SendInformationIntoCRMFromDB(int UserId)
        {
            string Email, token, Password;
            int APILimit, Service;
            try
            {
                DataTable UserInfo = databaseProvider.getUserInfoById(UserId);
                if (UserInfo.Rows.Count < 0)
                { return; }

                Email = UserInfo.Rows[0]["EmailId"].ToString();
                token = UserInfo.Rows[0]["configurationAuthToken"].ToString();
                APILimit = Convert.ToInt32(UserInfo.Rows[0]["apiLimit"].ToString());

                DataTable DTLeadsInfo = databaseProvider.getAllUnProcessedMailToPutIntoCrm(UserId);
                string sTmpDataStr = string.Empty;
                string CRLF = "\r\n";
                for (int x = 0; x < DTLeadsInfo.Rows.Count; x++)
                {
                    //Check API Access Limits
                    Boolean status = Convert.ToBoolean(databaseProvider.CheckUserApiCallCountStatusOfUser(UserId));
                    if (!status)
                    {
                        summaryEmail.sendApiLimitExceedInfoMail(UserId);
                        break;
                    }

                    int MailId = Convert.ToInt32(DTLeadsInfo.Rows[x]["id"].ToString());

                    DataTable valueDataTable = databaseProvider.GetLeadToMailColumnValueByMailId(MailId);

                    sTmpDataStr = "<Leads>" + CRLF;
                    sTmpDataStr += "<row no=" + Convert.ToChar(34) + "1" + Convert.ToChar(34) + ">" + CRLF;

                    //Assign all Local variables
                    for (int xy = 0; xy < valueDataTable.Rows.Count; xy++)
                    {  //Get Record Data in XML Format
                        string sLeadSourceValue, Lead_Column_Header;
                        sLeadSourceValue = valueDataTable.Rows[xy]["FiledValue"].ToString();
                        Lead_Column_Header = valueDataTable.Rows[xy]["Lead_Column_Header"].ToString();
                        if (!string.IsNullOrEmpty(sLeadSourceValue))
                            sTmpDataStr += "<FL val=" + Convert.ToChar(34) + Lead_Column_Header + Convert.ToChar(34) + ">" + sLeadSourceValue + "</FL>" + CRLF;
                    }
                    sTmpDataStr += "</row>" + CRLF;
                    sTmpDataStr += "</Leads>";


                    //Insert Record in CRM and Update Log
                    string sRes = ZohoCRMAPI.APIMethod(token, sTmpDataStr);
                    if (!string.IsNullOrEmpty(sRes))
                    {
                        if (sRes.IndexOf("added successfully") > 0)
                        {
                            try
                            {
                                string record_time = string.Empty, record_id = string.Empty;
                                DataSet ds = new DataSet();
                                DataTable dt;

                                XmlReader xmlReader = XmlReader.Create(new StringReader(sRes));
                                ds.ReadXml(xmlReader);
                                dt = ds.Tables["FL"];
                                record_id = dt.Rows[0][1].ToString();
                                record_time = dt.Rows[1][1].ToString();
                            //    databaseProvider.InsertSubmitedMailCRMInfo(MailId, record_time, record_id);
                            }
                            catch (Exception ep)
                            { }
                            databaseProvider.updateMailContentSubmitToCrmStatus(MailId);
                            System.Threading.Thread.Sleep(30);
                        }
                        else
                        {
                            databaseProvider.logApplicationError(MailId + "__" + sRes, "Information");
                        }
                    }
                    else
                    {
                        databaseProvider.logApplicationError(MailId + "__FAILED TO INSERT DATA ONTO CRM", "Information");
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}