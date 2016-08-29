using AdminTool.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTool
{
    public partial class frmUserMailToLead : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                /* Session["LoggedInuserId"] = 1;
                 Session["ViewUserId"] = 5;
                 Session["ViewUserSubjectId"] = 12;*/
                try
                {
                    int LoggedInuserId, UserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    UserId = Convert.ToInt32(Session["ViewUserId"]);
                    AddNewLeadInfo.Visible = false;
                    tbNewLeadInfo.Text = "";
                    tbNewMailInfo.Text = "";
                    if (LoggedInuserId < 1)
                    { Response.Redirect("~/default.aspx"); }
                    else
                    {
                        SetUserLeadMailInfo(UserId);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                    lblMsg.Text = "Some Error Occured";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }


        public void SetUserLeadMailInfo(int userId)
        {
            if (userId > 0)
            {
                DataTable dt = dataBaseProvider.getListofColumnHeaderOfLeadToMailTable(userId);
                ViewState["DefaultSubjectDataTable"] = dt;
                if (dt.Rows.Count < 1)
                {
                    GridLeadDetail.Visible = false;
                    ImgExportToCSV.Enabled = false;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    GridLeadDetail.AutoGenerateColumns = false;
                    GridLeadDetail.Visible = true;
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                    GridLeadDetail.DataSource = dt;
                    GridLeadDetail.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void ImageGoBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/frmUserDetailViewScreen.aspx");
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstring = txtSearchBox.Text.Trim();
            GridLeadDetail.EditIndex = -1;
            FillDefaultGridView(false);
            if (string.IsNullOrEmpty(searchstring))
            {
                hdnSearchTxt.Value = "";
                FillDefaultGridView(false);
            }
            else
            {
                hdnSearchTxt.Value = searchstring;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["DefaultLeadDataTable"];
                if (dt.Rows.Count == 0)
                {
                    FillDefaultGridView(false);
                    dt = (DataTable)ViewState["DefaultLeadDataTable"];
                }

                Session["SearchString"] = searchstring;
                dt = FilterData(searchstring, dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridLeadDetail.DataSource = dt;
                    GridLeadDetail.DataBind();
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                }
                else
                {
                    DataTable dtnew = dt;
                    dtnew.Clear();
                    GridLeadDetail.DataSource = dtnew;
                    GridLeadDetail.DataBind();
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    ImgExportToCSV.Enabled = false;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                }
            }
        }


        private void FillDefaultGridView(bool refresh)
        {
            int ViewUserId;
            ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            DataTable dt = new DataTable();
            dt = dataBaseProvider.getListofColumnHeaderOfLeadToMailTable(ViewUserId);
            AddNewLeadInfo.Visible = false;
            ViewState["DefaultLeadDataTable"] = dt;

            if (!string.IsNullOrEmpty(hdnSearchTxt.Value))
            {
                dt = FilterData(hdnSearchTxt.Value, dt);
            }

            GridLeadDetail.DataSource = dt;
            GridLeadDetail.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                ImgExportToCSV.Enabled = true;
                ImgExportToExcel.Enabled = true;
                ImgExportToPDF.Enabled = true;
                GridLeadDetail.Visible = true;
            }
            else
            {

                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
                AddNewLeadInfo.Visible = true;
                GridLeadDetail.Visible = false;
                lblMsg.Text = "No DataFound";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected DataTable FilterData(string searchString, DataTable dt)
        {
            DataTable dtnew = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] foundRows = dt.Select("leadColumnHeader LIKE '%" + searchString + "%' OR mailColumnHeader LIKE '%" +
                    searchString + "%'");
                foreach (DataRow row in foundRows)
                    dtnew.ImportRow(row);
            }

            return dtnew;
        }

        protected void ImgAddNewLeadColumn_Click1(object sender, EventArgs e)
        {
            AddNewLeadInfo.Visible = true;
            lblMsg.Visible = false;
        }

        protected void imgBtnNewLeadInfo_Click(object sender, EventArgs e)
        {
            try
            {

                int userId = Convert.ToInt32(Session["ViewUserId"]);
                string MailColumnHeader = tbNewMailInfo.Text.ToString();
                string LeadColumnHeader = tbNewLeadInfo.Text.ToString();
                if (string.IsNullOrEmpty(MailColumnHeader.Trim()) || string.IsNullOrEmpty(LeadColumnHeader.Trim()))
                {
                    lblMsg.Text = "Filed Should be not empty";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string result = dataBaseProvider.AddNewColumnHeaderOfLeadToMail(MailColumnHeader, LeadColumnHeader, userId);
                    if (result.Equals("SUCCESS"))
                    {
                        lblMsg.Text = "Lead Info Added Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        GridLeadDetail.EditIndex = -1;
                        tbNewLeadInfo.Text = "";
                        tbNewMailInfo.Text = "";
                    }
                    else
                    {
                        lblMsg.Text = result;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                lblMsg.Visible = true;
                FillDefaultGridView(true);
            }
            catch (Exception ex)
            {
                ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void imgBtnNewLeadInfoCancel_Click(object sender, EventArgs e)
        {
            AddNewLeadInfo.Visible = false;
            tbNewMailInfo.Text = "";
            tbNewLeadInfo.Text = "";
            FillDefaultGridView(true);

        }

        protected void GridLeadDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int LeadId = Convert.ToInt32(GridLeadDetail.DataKeys[e.RowIndex].Values["Id"]);
            string result = dataBaseProvider.DeleteColumnHeaderOfLeadToMail(LeadId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Lead Info Deleted Sucessfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = result;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridLeadDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridLeadDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridLeadDetail.EditIndex = -1;
            FillDefaultGridView(false);

        }

        protected void GridLeadDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Session["ViewUserId"]);
                int LeadId = Convert.ToInt32(((HiddenField)GridLeadDetail.Rows[e.RowIndex].FindControl("hiddenLeadId")).Value.Trim());
                string MailColumnHeader = ((TextBox)GridLeadDetail.Rows[e.RowIndex].FindControl("tbMailColumnHeader")).Text.Trim();
                string LeadColumnHeader = ((TextBox)GridLeadDetail.Rows[e.RowIndex].FindControl("tbLeadColumnHeader")).Text.Trim();
                string result = dataBaseProvider.UpdateColumnHeaderOfLeadToMailInfo(LeadId, MailColumnHeader, LeadColumnHeader, UserId);
                if (string.IsNullOrEmpty(MailColumnHeader.Trim()) || string.IsNullOrEmpty(LeadColumnHeader.Trim()))
                {
                    lblMsg.Text = "Filed Should be not empty";
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    if (result.Equals("SUCCESS"))
                    {
                        lblMsg.Text = "Lead Info Update Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        GridLeadDetail.EditIndex = -1;
                        FillDefaultGridView(true);
                    }
                    else
                    {
                        lblMsg.Text = result;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                lblMsg.Visible = true;
            }
            catch (Exception ex)
            {
                ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridLeadDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridLeadDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridLeadDetail.EditIndex = e.NewEditIndex;

            FillDefaultGridView(false);
        }

        protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = sender as ImageButton;
            int LeadId = Convert.ToInt32(img.CommandArgument);
            string result = dataBaseProvider.DeleteColumnHeaderOfLeadToMail(LeadId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Lead Info Deleted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtSearchBox.Text = "";
                hdnSearchTxt.Value = "";
                GridLeadDetail.EditIndex = -1;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = result;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ImgExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToPDF_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToCSV_Click(object sender, EventArgs e)
        {

        }
    }
}