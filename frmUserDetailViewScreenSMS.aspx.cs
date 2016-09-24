using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminTool.DataBase;
using System.Data;

namespace AdminTool
{
    public partial class frmUserDetailViewScreenSMS : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        static int UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                   
                    int LoggedInuserId, UserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    UserId = Convert.ToInt32(Session["ViewUserId"]);
                    if (LoggedInuserId < 1)
                    {
                        Response.Redirect("~/default.aspx");
                    }
                    else
                    {
                        SetUserInfoIntoForm(UserId);
                    }
                    ((Label)(Master).FindControl("lblUserName")).Text = Session["UserName"].ToString();
                }
                catch (Exception ex)
                { }
            }
        }

        public void SetUserInfoIntoForm(int userId)
        {
            if (userId > 0)
            {
                DataTable UserInfo = dataBaseProvider.getSMSUserInfoById(userId);
                if (UserInfo.Rows.Count > 0)
                {
                    UserType = Convert.ToInt32(UserInfo.Rows[0]["type"].ToString());
                    tbFirstName.Text = UserInfo.Rows[0]["FirstName"].ToString();
                    tbLastName.Text = UserInfo.Rows[0]["LastName"].ToString();
                    tbEmail.Text = UserInfo.Rows[0]["EmailId"].ToString();
                    tbPassword.Text = UserInfo.Rows[0]["password"].ToString();
                    chkIsApproved.Checked = Convert.ToBoolean(UserInfo.Rows[0]["isApproved"]);
                    tbConfigurationToken.Text = UserInfo.Rows[0]["configurationAuthToken"].ToString();

                    tbAppKey.Text = UserInfo.Rows[0]["AppKey"].ToString();
                    tbAppSecretKey.Text = UserInfo.Rows[0]["AppSecretKey"].ToString();

                    tbSmsUserId.Text = UserInfo.Rows[0]["SmsUserId"].ToString();
                    tbSmsPassword.Text = UserInfo.Rows[0]["SmsPassword"].ToString();
                    tbSmsFrom.Text = UserInfo.Rows[0]["SmsFrom"].ToString();
                    EnableDisable(false);
                }
            }
            else
            {
                tbFirstName.Text = string.Empty;
                tbLastName.Text = string.Empty;
                tbEmail.Text = string.Empty;
                tbConfigurationToken.Text = string.Empty;

                EnableDisable(true);

            }
        }


        private void EnableDisable(bool isEnable)
        {
            tbFirstName.Enabled = isEnable;
            tbLastName.Enabled = isEnable;
            ImgCreateSms.Visible = !isEnable;
            tbEmail.Enabled = isEnable;
            tbPassword.Enabled = isEnable;
            tbConfigurationToken.Enabled = isEnable;
            chkIsApproved.Enabled = isEnable;
            AddNewUser.Visible = isEnable;
            UpdateDiv.Visible = !isEnable;
            tbAppKey.Enabled = isEnable;
            tbAppSecretKey.Enabled = isEnable;
            tbSmsUserId.Enabled = isEnable;
            tbSmsPassword.Enabled = isEnable;
            tbSmsFrom.Enabled = isEnable;

            if (UserType < 2)
            {
                ImageGoBack.Visible = false;
            }
            else
            {
                ImageGoBack.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void ImgViewSubject_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmViewSubjectInfo.aspx");
        }

        protected void ImgViewLeadColumnHeader_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserMailToLead.aspx");
        }


        protected void ImgCreateSMS_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateSMS.aspx");
        }


       protected void default_credantial_check_clicked(Object sender, EventArgs e)
        {

            Boolean b = chkUserCredential.Checked;

            CheckBox check = (CheckBox)sender;
            if (check.Checked)
            {
                
            tbAppKey.Visible = false;
            lblAppKey.Visible = false;
            tbAppSecretKey.Visible = false;
            lblAppSecretKey.Visible = false;
            tbSmsUserId.Visible = false;
            lblSmsUserId.Visible = false;
            tbSmsPassword.Visible = false;
            lblSmsPassword.Visible = false; 
            tbSmsFrom.Visible = false;
            lblSmsFrom.Visible = false;
            }
            else
            {
            tbAppKey.Visible = true;
            lblAppKey.Visible = true;
            tbAppSecretKey.Visible = true;
            lblAppSecretKey.Visible = true;
            tbSmsUserId.Visible = true;
            lblSmsUserId.Visible = true;
            tbSmsPassword.Visible = true;
            lblSmsPassword.Visible = true; 
            tbSmsFrom.Visible = true;
            lblSmsFrom.Visible = true;
            
            }

        }

        protected void btnSaveCancel_Click(object sender, EventArgs e)
        {
            int ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            SetUserInfoIntoForm(ViewUserId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            int LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
            int userType = 1, IsApproved = 1, apiLimit;
            bool default_sms_credantial;
            string FirstName, LastName, EmailId, configurationAuthToken, password = string.Empty, result = string.Empty;
            string AppKey, AppSecretKey, SmsUserId, SmsPassword, SmsFrom;
            FirstName = tbFirstName.Text;
            LastName = tbLastName.Text;
            EmailId = tbEmail.Text;
            configurationAuthToken = tbConfigurationToken.Text;
            password = tbPassword.Text.Trim();

            AppKey = tbAppKey.Text.ToString();
            AppSecretKey = tbAppSecretKey.Text.ToString();
            SmsUserId = tbSmsUserId.Text.ToString();
            SmsPassword = tbSmsPassword.Text.ToString();
            SmsFrom = tbSmsFrom.Text.ToString();
            apiLimit = 1;
            default_sms_credantial = chkUserCredential.Checked;
            EnableDisable(true);

            if (ViewUserId > 0)
            {
                result = dataBaseProvider.updateExisingSmsUserInfoIntoDataBase(ViewUserId, FirstName, LastName, EmailId, configurationAuthToken, userType, IsApproved, password, apiLimit, AppKey, AppSecretKey, SmsUserId, SmsPassword, SmsFrom, default_sms_credantial);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "User Information Update Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    SetUserInfoIntoForm(ViewUserId);
                }
                else
                {
                    lblMsg.Text = "Some Error Occured";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                result = dataBaseProvider.AddNewSmsUserIntoDatabase(LoggedInuserId, IsApproved, FirstName, LastName, EmailId, configurationAuthToken, password, userType, apiLimit, AppKey, AppSecretKey, SmsUserId, SmsPassword, SmsFrom, default_sms_credantial);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "User Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("~/frmUserList.aspx");
                }
                else
                {
                    lblMsg.Text = "Some Error Occured";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserList.aspx");
        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            if (!tbFirstName.Enabled)
            {
                EnableDisable(true);
            }
        }

        protected void btnChangePassword_Click1(object sender, EventArgs e)
        {

        }

        protected void ImgViewUserReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserMailReport.aspx");
        }

        protected void ImageGoBack_Click(object sender, ImageClickEventArgs e)
        {
            int ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            if (ViewUserId > 0)
            {
                Response.Redirect("~/frmCategory.aspx");
            }
            else
            {
                Response.Redirect("~/frmUserList.aspx");
            }
        }
    }
}