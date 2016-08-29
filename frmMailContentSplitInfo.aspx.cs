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
    public partial class frmMailContentSplitInfo : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
           /* Session["LoggedInuserId"] = 1;
            Session["ViewUserId"] = 5;
            Session["ViewUserSubjectId"] = 12;*/
            if (!IsPostBack)
            {
                try
                {
                    int LoggedInuserId, SubjectID;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    SubjectID = Convert.ToInt32(Session["ViewUserSubjectId"]);
                    AddNewSplitInfo.Visible = false;
                    tbEndText.Text = "";
                    tbStartText.Text = "";
                    if (LoggedInuserId < 1)
                    { Response.Redirect("~/default.aspx"); }
                    else
                    {
                        SetUserLeadMailSplitInfo(SubjectID);
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


        public void SetUserLeadMailSplitInfo(int SubjectID)
        {
            if (SubjectID > 0)
            {
                DataTable dt = dataBaseProvider.getListOfMailContentSplitInfo(SubjectID);
                ViewState["DefaultLeadSplitDataTable"] = dt;
                if (dt.Rows.Count < 1)
                {
                    ImgExportToCSV.Enabled = false;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                    GridSplitDetail.Visible = false;
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    GridSplitDetail.Visible = true;
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                    GridSplitDetail.DataSource = dt;
                    GridSplitDetail.DataBind();
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
            GridSplitDetail.EditIndex = -1;
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
                dt = (DataTable)ViewState["DefaultLeadSplitDataTable"];
                if (dt.Rows.Count == 0)
                {
                    FillDefaultGridView(false);
                    dt = (DataTable)ViewState["DefaultLeadSplitDataTable"];
                }

                Session["SearchString"] = searchstring;
                dt = FilterData(searchstring, dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridSplitDetail.DataSource = dt;
                    GridSplitDetail.DataBind();
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                }
                else
                {
                    DataTable dtnew = dt;
                    dtnew.Clear();
                    GridSplitDetail.DataSource = dtnew;
                    GridSplitDetail.DataBind();
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
            int SubjectID = Convert.ToInt32(Session["ViewUserSubjectId"]);
            DataTable dt = new DataTable();
            dt = dataBaseProvider.getListOfMailContentSplitInfo(SubjectID);
            AddNewSplitInfo.Visible = false;
            ViewState["DefaultSubjectDataTable"] = dt;

            if (!string.IsNullOrEmpty(hdnSearchTxt.Value))
            {
                dt = FilterData(hdnSearchTxt.Value, dt);
            }


            GridSplitDetail.DataSource = dt;
            GridSplitDetail.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                ImgExportToCSV.Enabled = true;
                ImgExportToExcel.Enabled = true;
                ImgExportToPDF.Enabled = true;
                GridSplitDetail.Visible = true;
            }
            else
            {
                GridSplitDetail.Visible = true;
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
                lblMsg.Text = "No DataFound";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            FileHeaderComboBox();
        }

        private void FileHeaderComboBox()
        {
            if (GridSplitDetail.Rows.Count <= 0)
            {
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
            }

            int ViewSubjectid, ViewUserId;
            ViewSubjectid = Convert.ToInt32(Session["ViewUserSubjectId"]);
            ViewUserId = Convert.ToInt32(Session["ViewUserId"]);
            DataTable dt = dataBaseProvider.getListOfunfiledHeaderofMailContentSplit(ViewSubjectid, ViewUserId);
            if (dt.Rows.Count < 1)
            {
                MailToLeadColumnHeader.DataSource = new DataTable();
                MailToLeadColumnHeader.DataBind();
                AddNewSplitInfo.Visible = false;
                lblMsg.Visible = true;                
                lblMsg.Text = "No More Data Available";
            }
            else
            {
                AddNewSplitInfo.Visible = true;
                lblMsg.Visible = false;
                MailToLeadColumnHeader.DataSource = dt;
                MailToLeadColumnHeader.DataTextField = "leadColumnHeader";
                MailToLeadColumnHeader.DataValueField = "id";
                MailToLeadColumnHeader.DataBind();
            }
        }

        protected DataTable FilterData(string searchString, DataTable dt)
        {
            DataTable dtnew = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] foundRows = dt.Select("leadColumnHeader LIKE '%" + searchString + "%' OR mailColumnHeader LIKE '%" +
                    searchString + "%' OR startText LIKE '%" + searchString + "%' OR endText LIKE '%" +
                    searchString + "%'");
                foreach (DataRow row in foundRows)
                    dtnew.ImportRow(row);
            }

            return dtnew;
        }

        protected void ImgExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToCSV_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToPDF_Click(object sender, EventArgs e)
        {

        }

        protected void ImgAddNewSplitInfo_Click(object sender, EventArgs e)
        {
            if (GridSplitDetail.Rows.Count <= 0)
            {
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
            }
            FileHeaderComboBox();
        }

        protected void imgBtnCancel_Click(object sender, EventArgs e)
        {
            AddNewSplitInfo.Visible = false;
            tbStartText.Text = "";
            tbEndText.Text = "";
            FillDefaultGridView(false);
        }

        protected void imgBtnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSplitInfo.Visible = false;
                ImageButton img = sender as ImageButton;
                int ColumnHeaderId = Convert.ToInt32(MailToLeadColumnHeader.SelectedValue);
                int SubjectId = Convert.ToInt32(Session["ViewUserSubjectId"]);
                string startText = tbStartText.Text.ToString();
                string endText = tbEndText.Text.ToString();
                string result = dataBaseProvider.AddNewMailContentSplitInfo(startText, endText, ColumnHeaderId, SubjectId);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "Lead Info Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridSplitDetail.EditIndex = -1;
                    tbStartText.Text = "";
                    tbEndText.Text = "";
                    FillDefaultGridView(true);
                }
                else
                {
                    lblMsg.Text = "Some Error Occured";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }

        protected void GridSplitDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridSplitDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridSplitDetail.EditIndex = e.NewEditIndex;

            FillDefaultGridView(false);
        }

        protected void GridSplitDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int LeadSplitId = Convert.ToInt32(GridSplitDetail.DataKeys[e.RowIndex].Values["Id"]);
            string result = dataBaseProvider.DeleteMailContentSplitInfo(LeadSplitId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Lead Split Info Deleted Sucessfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridSplitDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridSplitDetail.EditIndex = -1;
            FillDefaultGridView(false);
        }

        protected void GridSplitDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int SubjectId = Convert.ToInt32(Session["ViewUserSubjectId"]);
                int SplitRowId = Convert.ToInt32(((HiddenField)GridSplitDetail.Rows[e.RowIndex].FindControl("hiddenSplitId")).Value.Trim());
                int ColumnHeaderId = Convert.ToInt32(((HiddenField)GridSplitDetail.Rows[e.RowIndex].FindControl("hiddenColumnHeaderId")).Value.Trim());

                string startText = ((TextBox)GridSplitDetail.Rows[e.RowIndex].FindControl("tbStartText")).Text.Trim();
                string endText = ((TextBox)GridSplitDetail.Rows[e.RowIndex].FindControl("tbEndText")).Text.Trim();

                string result = dataBaseProvider.UpdateMailContentSplitInfo(startText, endText, ColumnHeaderId, SubjectId, SplitRowId);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "Lead Split info Update Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridSplitDetail.EditIndex = -1;
                    FillDefaultGridView(true);
                }
                else
                {
                    lblMsg.Text = "Some Error Occured";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }

        protected void GridSplitDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = sender as ImageButton;
            int SplitId = Convert.ToInt32(img.CommandArgument);
            string result = dataBaseProvider.DeleteMailContentSplitInfo(SplitId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Lead Split Info Deleted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtSearchBox.Text = "";
                hdnSearchTxt.Value = "";
                GridSplitDetail.EditIndex = -1;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}