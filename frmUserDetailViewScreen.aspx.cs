using AdminTool.DataBase;
using AdminTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTool
{
    public partial class frmUserDetailViewScreen : System.Web.UI.Page
    {

        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        static int UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    //Session["LoggedInuserId"] = 1;
                    //Session["ViewUserId"] = 0;
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
            fillUserApiDropDownList(userId);
            if (userId > 0)
            {
                DataTable UserInfo = dataBaseProvider.getUserInfoById(userId);
                if (UserInfo.Rows.Count > 0)
                {
                    UserType = Convert.ToInt32(UserInfo.Rows[0]["type"].ToString());
                    tbFirstName.Text = UserInfo.Rows[0]["FirstName"].ToString();
                    tbLastName.Text = UserInfo.Rows[0]["LastName"].ToString();
                    tbEmail.Text = UserInfo.Rows[0]["EmailId"].ToString();
                    tbPassword.Text = UserInfo.Rows[0]["password"].ToString();
                    chkIsApproved.Checked = Convert.ToBoolean(UserInfo.Rows[0]["isApproved"]);
                    tbConfigurationToken.Text = UserInfo.Rows[0]["configurationAuthToken"].ToString();
                    dropdownAPiLimit.SelectedValue = UserInfo.Rows[0]["apiLimit"].ToString();
                    EnableDisable(false);
                }
            }
            else
            {
                tbFirstName.Text = string.Empty;
                tbLastName.Text = string.Empty;
                tbEmail.Text = string.Empty;
                tbPassword.Text = string.Empty;
                tbConfigurationToken.Text = string.Empty;

                EnableDisable(true);

            }
            fillUserApiDropDownList(userId);
        }

        private void fillUserApiDropDownList(int userId)
        {
            DataTable ApiInfo = dataBaseProvider.getApiSubscriptionInfo();
            if (ApiInfo.Rows.Count > 0)
            {
                dropdownAPiLimit.DataSource = ApiInfo;
                dropdownAPiLimit.DataBind();
                dropdownAPiLimit.DataTextField = "Info";
                dropdownAPiLimit.DataValueField = "id";
            }

        }

        private void EnableDisable(bool isEnable)
        {
            tbFirstName.Enabled = isEnable;
            tbLastName.Enabled = isEnable;
            ImgViewSubject.Visible = !isEnable;
            ImgViewLeadColumnHeader.Visible = !isEnable;
            ImgSync.Visible = !isEnable;
            tbEmail.Enabled = isEnable;
            tbPassword.Enabled = isEnable;
            tbConfigurationToken.Enabled = isEnable;
            dropdownAPiLimit.Enabled = isEnable;
            chkIsApproved.Enabled = isEnable;
            AddNewUser.Visible = isEnable;
            UpdateDiv.Visible = !isEnable;

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

        //protected void ButtonGoBack_Click(object sender, EventArgs e)
        //{
        //    if (UserType > 1)
        //    {
        //        Response.Redirect("~/frmUserList.aspx");
        //    }
        //}


        protected void ImgTestApi_Click(object sender, EventArgs e)
        {
            int ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            if (ViewUserId > 0)
            {
               // MainTimeTicker.SendEmailStarted(ViewUserId);
               temp_mail_check.SendEmailStarted(ViewUserId);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
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

            string FirstName, LastName, EmailId, configurationAuthToken, password = string.Empty, result = string.Empty;
            FirstName = tbFirstName.Text;
            LastName = tbLastName.Text;
            EmailId = tbEmail.Text;
            configurationAuthToken = tbConfigurationToken.Text;
            password = tbPassword.Text.Trim();
            apiLimit = Convert.ToInt32(dropdownAPiLimit.SelectedValue);

            EnableDisable(true);
            if (ViewUserId > 0)
            {
                result = dataBaseProvider.updateExisingUserInfoIntoDataBase(ViewUserId, FirstName, LastName, EmailId, configurationAuthToken, userType, IsApproved, password, apiLimit);
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
                result = dataBaseProvider.AddNewUserIntoDatabase(LoggedInuserId, IsApproved, FirstName, LastName, EmailId, configurationAuthToken, password, userType, apiLimit);
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

        protected void ImageGoBack1_Click(object sender, ImageClickEventArgs e)
        {
            int ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            if (ViewUserId > 0)
            {
                Response.Redirect("~/frmApiReport.aspx");
            }
            else
            {
                Response.Redirect("~/frmUserList.aspx");
            }
        }
    }
}