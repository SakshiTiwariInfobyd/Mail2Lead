using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AdminTool.DataBase
{
    public class DataBaseProvider
    {
        public static string myConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public int LoginUser(string Emailid, string Password)
        {
            int UserId = 0;
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_user_login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sEmailId", MySqlDbType.VarChar).Value = Emailid;
                    cmd.Parameters.Add("sPassword", MySqlDbType.VarChar).Value = Password;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        UserId = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    }
                    return UserId;
                }
            }
        }


        public string AddNewUserIntoDatabase(int CreatorId, int IsApproved, string FirstName, string LastName, string EmailId, string AuthToken, string Password, int sType, int ApiLimit)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_new_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sFirstName", MySqlDbType.VarChar).Value = FirstName;
                    cmd.Parameters.Add("@sLastName", MySqlDbType.VarChar).Value = LastName;
                    cmd.Parameters.Add("@sEmailId", MySqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@sConfigurationAuthToken", MySqlDbType.VarChar).Value = AuthToken;
                    cmd.Parameters.Add("@sPassword", MySqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@sProfileImage", MySqlDbType.VarChar).Value = "NA";
                    cmd.Parameters.Add("@sType", MySqlDbType.Int32).Value = sType;
                    cmd.Parameters.Add("@sIsApproved", MySqlDbType.Int32).Value = IsApproved;
                    cmd.Parameters.Add("@sApiLimit", MySqlDbType.Int32).Value = ApiLimit;
                    cmd.Parameters.Add("@sCreatorId", MySqlDbType.Int32).Value = CreatorId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string updateExisingUserInfoIntoDataBase(int ViewUserId, string FirstName, string LastName, string EmailId, string AuthToken, int sType, int IsApproved, string Password, int ApiLimit)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_user_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sFirstName", MySqlDbType.VarChar).Value = FirstName;
                    cmd.Parameters.Add("@sLastName", MySqlDbType.VarChar).Value = LastName;
                    cmd.Parameters.Add("@sEmailId", MySqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@sConfigurationAuthToken", MySqlDbType.VarChar).Value = AuthToken;
                    cmd.Parameters.Add("@sType", MySqlDbType.Int32).Value = sType;
                    cmd.Parameters.Add("@sPassword", MySqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@sProfileImage", MySqlDbType.VarChar).Value = "Na";
                    cmd.Parameters.Add("@sIsApproved", MySqlDbType.Int32).Value = IsApproved;
                    cmd.Parameters.Add("@sApiLimit", MySqlDbType.Int32).Value = ApiLimit;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = ViewUserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }




        internal string AddNewSmsUserIntoDatabase(int CreatorId, int IsApproved, string FirstName, string LastName, string EmailId, string AuthToken,
            string Password, int sType, int ApiLimit, string AppKey, string AppSecretKey, string SmsUserId, string SmsPassword, string SmsFrom, bool default_sms_credantial)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_new_sms_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sFirstName", MySqlDbType.VarChar).Value = FirstName;
                    cmd.Parameters.Add("@sLastName", MySqlDbType.VarChar).Value = LastName;
                    cmd.Parameters.Add("@sEmailId", MySqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@sConfigurationAuthToken", MySqlDbType.VarChar).Value = AuthToken;
                    cmd.Parameters.Add("@sPassword", MySqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@sProfileImage", MySqlDbType.VarChar).Value = "NA";
                    cmd.Parameters.Add("@sType", MySqlDbType.Int32).Value = sType;
                    cmd.Parameters.Add("@sIsApproved", MySqlDbType.Int32).Value = IsApproved;
                    cmd.Parameters.Add("@sApiLimit", MySqlDbType.Int32).Value = ApiLimit;
                    cmd.Parameters.Add("@sCreatorId", MySqlDbType.Int32).Value = CreatorId;

                    cmd.Parameters.Add("@sAppKey", MySqlDbType.VarChar).Value = AppKey;
                    cmd.Parameters.Add("@sAppSecretKey", MySqlDbType.VarChar).Value = AppSecretKey;
                    cmd.Parameters.Add("@sSmsUserId", MySqlDbType.VarChar).Value = SmsUserId;
                    cmd.Parameters.Add("@sSmsPassword", MySqlDbType.VarChar).Value = SmsPassword;
                    cmd.Parameters.Add("@sSmsFrom", MySqlDbType.VarChar).Value = SmsFrom;
                    cmd.Parameters.Add("@sdefaultSmsCredantialCheck", MySqlDbType.Int32).Value = default_sms_credantial;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        internal string updateExisingSmsUserInfoIntoDataBase(int ViewUserId, string FirstName, string LastName, string EmailId, string AuthToken, int sType, int IsApproved, string Password, int ApiLimit, string AppKey, string AppSecretKey, string SmsUserId, string SmsPassword, string SmsFrom, bool default_sms_credantial)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_sms_user_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sFirstName", MySqlDbType.VarChar).Value = FirstName;
                    cmd.Parameters.Add("@sLastName", MySqlDbType.VarChar).Value = LastName;
                    cmd.Parameters.Add("@sEmailId", MySqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@sConfigurationAuthToken", MySqlDbType.VarChar).Value = AuthToken;
                    cmd.Parameters.Add("@sType", MySqlDbType.Int32).Value = sType;
                    cmd.Parameters.Add("@sPassword", MySqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@sProfileImage", MySqlDbType.VarChar).Value = "Na";
                    cmd.Parameters.Add("@sIsApproved", MySqlDbType.Int32).Value = IsApproved;
                    cmd.Parameters.Add("@sApiLimit", MySqlDbType.Int32).Value = ApiLimit;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = ViewUserId;

                    cmd.Parameters.Add("@sAppKey", MySqlDbType.VarChar).Value = AppKey;
                    cmd.Parameters.Add("@sAppSecretKey", MySqlDbType.VarChar).Value = AppSecretKey;
                    cmd.Parameters.Add("@sSmsUserId", MySqlDbType.VarChar).Value = SmsUserId;
                    cmd.Parameters.Add("@sSmsPassword", MySqlDbType.VarChar).Value = SmsPassword;
                    cmd.Parameters.Add("@sSmsFrom", MySqlDbType.VarChar).Value = SmsFrom;
                    cmd.Parameters.Add("@sdefaultSmsCredantialCheck", MySqlDbType.Int32).Value = default_sms_credantial;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }


        public DataTable getUserInfoById(int userId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_user_info_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable getSMSUserInfoById(int userId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_sms_user_info_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }



        public DataTable getApiSubscriptionInfo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("get_api_subscription_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }




        public DataTable getListOfallUser(int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_list_of_all_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable getListOfallSMSUser(int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_list_of_all_sms_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }


        public DataTable getApiStatusReport(int UserId)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_api_status_report", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("sUserId", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            return dt;
        }


        public DataTable getAvailablePaymentOption(int UserId)
        {

            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_all_available_payment_option", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("sUserId", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
            return dt;
        }



        public DataTable getListOfAllUserSubject(int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_list_of_all_subject", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable getListOfAllUserSubject(string emailId)
        {
            DataTable dt = new DataTable();
            return dt;
        }


        public DataTable getListOfMailContentSplitInfo(int SubjectId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_list_mail_content_split_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sSubjectId", MySqlDbType.VarChar).Value = SubjectId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable updateMailSplitContentCompleteStatus(int MailId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_is_split_mail_content_completed", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sMailId", MySqlDbType.VarChar).Value = MailId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable updateMailContentSubmitToCrmStatus(int MailId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_is_info_submited_into_crm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sMailId", MySqlDbType.VarChar).Value = MailId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable updateMailContentSubmitToCrmStatusWithError(int MailId, string Error)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_is_info_submited_into_crm_with_Error", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sMailId", MySqlDbType.VarChar).Value = MailId;
                    cmd.Parameters.Add("sInsertError", MySqlDbType.VarChar).Value = Error;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public void logApplicationError(string ErrorDetail, string ErrorType)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_error_info_of_application", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sErrorDetail", MySqlDbType.VarChar).Value = ErrorDetail;
                    cmd.Parameters.Add("sErrorType", MySqlDbType.VarChar).Value = ErrorType;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
        }


        public DataTable getListOfunfiledHeaderofMailContentSplit(int SubjectId, int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_list_of_unfiled_header_of_mail_content_split", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sSubjectId", MySqlDbType.VarChar).Value = SubjectId;
                    cmd.Parameters.Add("sUserId", MySqlDbType.VarChar).Value = UserId;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }



        public DataTable getListofColumnHeaderOfLeadToMailTable(int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_mail_to_lead_column_header_list", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("sUserid", MySqlDbType.VarChar).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }
            return dt;
        }

        public string AddNewColumnHeaderOfLeadToMail(string mailColumnHeader, string LeadColumnHeader, int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_new_mail_to_lead_header_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sLeadColumnHeader", MySqlDbType.VarChar).Value = LeadColumnHeader;
                    cmd.Parameters.Add("@sMailColumnHeader", MySqlDbType.VarChar).Value = mailColumnHeader;
                    cmd.Parameters.Add("@sUserid", MySqlDbType.Int32).Value = UserId;
                    cmd.Parameters.Add("@UTC_TIMESTAMP", MySqlDbType.DateTime).Value = System.DateTime.UtcNow;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string AddNewMailContentSplitInfo(string sStartText, string sEndText, int sColumnHeaderId, int sSubjectId, string splitValueText, int splitIndex, string SplitType, Boolean isValueSplit)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_mail_content_split_info_new", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sStartText", MySqlDbType.VarChar).Value = sStartText;
                    cmd.Parameters.Add("@sEndText", MySqlDbType.VarChar).Value = sEndText;
                    cmd.Parameters.Add("@sSubjectId", MySqlDbType.Int32).Value = sSubjectId;
                    cmd.Parameters.Add("@sColumnHeaderId", MySqlDbType.Int32).Value = sColumnHeaderId;
                    cmd.Parameters.Add("@sSplitValueText", MySqlDbType.VarChar).Value = splitValueText;
                    cmd.Parameters.Add("@sSplitIndex", MySqlDbType.Int32).Value = splitIndex;
                    cmd.Parameters.Add("@sSplitType", MySqlDbType.VarChar).Value = SplitType;
                    if (isValueSplit)
                        cmd.Parameters.Add("@sIsValueSplit", MySqlDbType.Int32).Value = 1;
                    else
                        cmd.Parameters.Add("@sIsValueSplit", MySqlDbType.Int32).Value = 0;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }


        public string UpdateMailContentSplitInfo(string sStartText, string sEndText, int sColumnHeaderId, int sSubjectId, int RowId, string splitValueText, int splitIndex, string SplitType, Boolean isValueSplit)
        {   
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_mail_content_split_info_new", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sStartText", MySqlDbType.VarChar).Value = sStartText;
                    cmd.Parameters.Add("@sEndText", MySqlDbType.VarChar).Value = sEndText;
                    cmd.Parameters.Add("@sSubjectId", MySqlDbType.Int32).Value = sSubjectId;
                    cmd.Parameters.Add("@sColumnHeaderId", MySqlDbType.Int32).Value = sColumnHeaderId;
                    cmd.Parameters.Add("@sMailContentId", MySqlDbType.Int32).Value = RowId;
                    cmd.Parameters.Add("@sSplitValueText", MySqlDbType.VarChar).Value = splitValueText;
                    cmd.Parameters.Add("@sSplitIndex", MySqlDbType.Int32).Value = splitIndex;
                    cmd.Parameters.Add("@sSplitType", MySqlDbType.VarChar).Value = SplitType;
                    if (isValueSplit)
                        cmd.Parameters.Add("@sIsValueSplit", MySqlDbType.Int32).Value = 1;
                    else
                        cmd.Parameters.Add("@sIsValueSplit", MySqlDbType.Int32).Value = 0;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string AddNewSubject(string SubjectLine, int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_new_subject", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sSubejctLine", MySqlDbType.VarChar).Value = SubjectLine;
                    cmd.Parameters.Add("@sUserid", MySqlDbType.Int32).Value = UserId;
                    cmd.Parameters.Add("@UTC_TIMESTAMP", MySqlDbType.DateTime).Value = System.DateTime.UtcNow;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string UpdateSubjectInfoById(string SubjectLine, int SubjectId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_subject_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sSubejctLine", MySqlDbType.VarChar).Value = SubjectLine;
                    cmd.Parameters.Add("@sSubjectId", MySqlDbType.Int32).Value = SubjectId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string DeleteSubjectById(int SubjectId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delete_subject_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sSubjectId", MySqlDbType.VarChar).Value = SubjectId;
                    cmd.Parameters.Add("@UTC_TIMESTAMP", MySqlDbType.DateTime).Value = System.DateTime.UtcNow;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }

        public string DeleteMailContentSplitInfo(int RowId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delete_mail_content_split_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sMailContentId", MySqlDbType.VarChar).Value = RowId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }


        public string DeleteColumnHeaderOfLeadToMail(int MailToLeadColumnRowId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delete_mail_to_lead_column_header_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sColumnHeaderId", MySqlDbType.VarChar).Value = MailToLeadColumnRowId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }


        public string UpdateColumnHeaderOfLeadToMailInfo(int MailToLeadColumnRowId, string MailColumnHeader, string LeadColumnHeader, int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_update_mail_to_lead_column_header_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sColumnHeaderId", MySqlDbType.VarChar).Value = MailToLeadColumnRowId;
                    cmd.Parameters.Add("@sLeadColumnHeader", MySqlDbType.VarChar).Value = LeadColumnHeader;
                    cmd.Parameters.Add("@sMailColumnHeader", MySqlDbType.VarChar).Value = MailColumnHeader;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }
        public string deleteUser(int UserId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delete_user_by_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = UserId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt.Rows[0]["result"].ToString().ToUpper();
                }
            }
        }



        /************** Following For Automation */



        public DateTime GetLastProcessedTime(int userId)
        {
            DateTime result = DateTime.Now.ToUniversalTime();
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_user_mail_last_processed_time", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        if (DateTime.TryParse(dt.Rows[0]["result"].ToString(), out result))
                        {
                            result = Convert.ToDateTime(dt.Rows[0]["result"].ToString());
                        }
                    }
                }
            }
            return result;
        }

        public int InsertMailIntoDataBase(int SubjectId, string mailBody, DateTime mailTime)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_mail_detail_info_of_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sSubject_id", MySqlDbType.Int32).Value = SubjectId;
                    cmd.Parameters.Add("@sMail_content_body", MySqlDbType.Text).Value = mailBody;
                    cmd.Parameters.Add("@sMail_actual_date_time", MySqlDbType.DateTime).Value = mailTime;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return int.Parse(dt.Rows[0]["result"].ToString().ToUpper());
                }
            }
        }

        public string InsertMailSplitInfoFromBody(int MailDataBaseId, string Value, int contentSplitId)
        {
            string result = string.Empty;
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_lead_to_mail_column_content_value", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUser_mail_detail_id", MySqlDbType.Int32).Value = MailDataBaseId;
                    cmd.Parameters.Add("@sValue_from_mail", MySqlDbType.Text).Value = Value;
                    cmd.Parameters.Add("@sLead_to_mail_column_header_id", MySqlDbType.Int32).Value = contentSplitId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    result = dt.Rows[0]["result"].ToString().ToUpper();
                }
            }

            return result;
        }

        public DataTable getAllUnProcessedMailToPutIntoCrm(int userId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_all_unprocessed_mail_to_insert_into_crm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool CheckUserApiCallCountStatusOfUser(int userId)
        {
            bool result = false;
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_check_use_api_call_count_status_of_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    result = bool.Parse(dt.Rows[0]["result"].ToString().ToUpper());
                }
            }

            return result;
        }

        public DataTable GetLeadToMailColumnValueByMailId(int mailId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_get_lead_to_mail_column_value_by_mail_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sMailId", MySqlDbType.Int32).Value = mailId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetUserMailReportByUserId(int userId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("get_mail_report_by_user_id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sUserId", MySqlDbType.Int32).Value = userId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


        internal void InsertSubmitedMailCRMInfo(int MailId, string record_time, string record_id)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insert_mail_submit_crm_info", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    cmd.Parameters.Add("@sRecord_id", MySqlDbType.VarChar).Value = record_id;
                    cmd.Parameters.Add("@sRecord_time", MySqlDbType.VarChar).Value = record_time;
                    cmd.Parameters.Add("@sDatabaseMailId", MySqlDbType.Int32).Value = MailId;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
        }

        public DataTable GetUserTempMail()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("temp_sp", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        internal void UpdatePaymentInfoByUserId(int UserId, string p_2, string p_3)
        {
            throw new NotImplementedException();
        }


        internal DataTable GetPendingReceivedMessage()
        {
            throw new NotImplementedException();
        }

        internal string GetSubject(string ConversationId)
        {
            throw new NotImplementedException();
        }

        internal void UpdateReceivedSMSStatus(int Id, int nStatus)
        {
            throw new NotImplementedException();
        }

        internal void InsertSMS(string p, string sModuleId, string sName, string p_2, string p_3, int nModuleType, DateTime dateTime, DateTime dateTime_2, DateTime dateTime_3, string p_4)
        {
            throw new NotImplementedException();
        }

        internal DataTable GetNewLeadId()
        {
            throw new NotImplementedException();
        }

        internal void InsertLeadInfo(string p, string p_2, string p_3, string p_4, string p_5)
        {
            throw new NotImplementedException();
        }

        internal DataTable GetNewContactId()
        {
            throw new NotImplementedException();
        }

        internal DataTable getUserSmsConfigurationinfo(int UserId)
        {
            throw new NotImplementedException();
        }

        internal void UpdateSMSStatus(string SMSId, string p)
        {
            throw new NotImplementedException();
        }

        internal void InsertSMSStatus(string SMSId, string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        internal void InsertReceivedSMS(string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, string p_8, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        internal DataTable GetPendingMessage()
        {
            throw new NotImplementedException();
        }

        internal void InsertContactInfo(string p, string p_2, string p_3, string p_4, string p_5)
        {
            throw new NotImplementedException();
        }
    }
}
