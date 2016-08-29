using AdminTool.DataBase;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AdminTool
{
    public partial class frmUserList : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Session["LoggedInuserId"] = 1;
             Session["ViewUserId"] = 5;
             Session["ViewUserSubjectId"] = 12;*/

            lblMsg.Style.Remove("color");
            lblMsg.Text = "";
            Session["ViewUserId"] = 0;
            if (!IsPostBack)
            {
                try
                {
                    int LoggedInuserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    if (LoggedInuserId < 1)
                    { Response.Redirect("~/default.aspx"); }
                    else
                    {
                        GetAllUserList(LoggedInuserId);
                    }
                }
                catch (Exception exc)
                {
                    ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, exc.Message);
                }
            }

        }

        public void GetAllUserList(int UserId)
        {
            DataTable dt = dataBaseProvider.getListOfallUser(UserId);
            ViewState["DefaultDataTable"] = dt;
            if (dt.Rows.Count < 1)
            {
                emptyListMsg.Visible = true;
                GridUserDetails.Visible = false;
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
            }
            else
            {
                emptyListMsg.Visible = false;
                ImgExportToCSV.Enabled = true;
                ImgExportToExcel.Enabled = true;
                ImgExportToPDF.Enabled = true;
                GridUserDetails.Visible = true;
                GridUserDetails.DataSource = dt;
                GridUserDetails.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            search();
        }

        private void search()
        {
            string searchstring = txtSearchBox.Text.Trim();
            GridUserDetails.EditIndex = -1;
            if (string.IsNullOrEmpty(searchstring))
            {
                hdnSearchTxt.Value = "";
                FillDefaultGridView(false);
            }
            else
            {
                hdnSearchTxt.Value = searchstring;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["DefaultDataTable"];
                if (dt.Rows.Count == 0)
                {
                    FillDefaultGridView(false);
                    dt = (DataTable)ViewState["DefaultDataTable"];
                }

                Session["SearchString"] = searchstring;
                dt = FilterData(searchstring, dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridUserDetails.DataSource = dt;
                    GridUserDetails.DataBind();
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                }
                else
                {
                    DataTable dtnew = dt;
                    dtnew.Clear();
                    GridUserDetails.DataSource = dtnew;
                    GridUserDetails.DataBind();
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    ImgExportToCSV.Enabled = false;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                }
            }
        }

        protected DataTable FilterData(string searchString, DataTable dt)
        {
            DataTable dnew = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] foundRows = dt.Select("FirstName LIKE '%" + searchString + "%' OR LastName LIKE '%" +
                    searchString + "%' OR EmailId LIKE '%" + searchString + "%'");
                if (foundRows.Count() > 0)
                {
                    dnew = foundRows.CopyToDataTable();
                }
            }

            return dnew;
        }


        private void FillDefaultGridView(bool refresh)
        {
            int LoggedInuserId;
            LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
            DataTable dt = new DataTable();
            dt = dataBaseProvider.getListOfallUser(LoggedInuserId);
            ViewState["DefaultDataTable"] = dt;

            if (!string.IsNullOrEmpty(hdnSearchTxt.Value))
            {
                dt = FilterData(hdnSearchTxt.Value, dt);
            }

            GridUserDetails.DataSource = dt;
            GridUserDetails.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                ImgExportToCSV.Enabled = true;
                ImgExportToExcel.Enabled = true;
                ImgExportToPDF.Enabled = true;
                Panel1.Enabled = true;
            }
            else
            {

                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
                Panel1.Enabled = false;
                lblMsg.Text = "No DataFound";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        public DataTable FilterDataForExport(DataTable dt, string searchstring)
        {
            DataTable dtnew = new DataTable();
            DataRow[] foundRows = dt.Select("FirstName LIKE '%" + searchstring + "%' OR LastName LIKE '%" + searchstring + "%' OR EmailId LIKE '%" + searchstring + "%' OR Organization LIKE '%" + searchstring + "%' OR Region LIKE '%" + searchstring + "%'");
            if (foundRows.Count() > 0)
            {
                dtnew = foundRows.CopyToDataTable();

            }
            else
            {
                dtnew = null;
            }
            return dtnew;
        }


        protected void GridUserDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridUserDetails.EditIndex = e.NewEditIndex;
            FillDefaultGridView(false);
        }

        protected void GridUserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GridUserDetails.DataKeys[e.RowIndex].Values["Id"]);
            string result = dataBaseProvider.deleteUser(userId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "User Deleted Sucessfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }

        protected void GridUserDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridUserDetails.EditIndex = -1;
            FillDefaultGridView(false);
        }

        protected void GridUserDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int CreatorId = Convert.ToInt32(Convert.ToInt32(Session["LoggedInuserId"]));
                int ViewUserId = Convert.ToInt32(((HiddenField)GridUserDetails.Rows[e.RowIndex].FindControl("hiddenUserId")).Value.Trim());
                string FirstName = ((TextBox)GridUserDetails.Rows[e.RowIndex].FindControl("tbFirstName")).Text.Trim();
                string LastName = ((TextBox)GridUserDetails.Rows[e.RowIndex].FindControl("tbLastName")).Text.Trim();
                string EmailId = ((TextBox)GridUserDetails.Rows[e.RowIndex].FindControl("tbEmailId")).Text.Trim();
                string Password = ((HiddenField)GridUserDetails.Rows[e.RowIndex].FindControl("hiddenPassword")).Value.Trim();
                int APIlimit = Convert.ToInt32(((HiddenField)GridUserDetails.Rows[e.RowIndex].FindControl("hiddenAPIlimit")).Value.Trim());
                int IsApproved = Convert.ToInt32(((HiddenField)GridUserDetails.Rows[e.RowIndex].FindControl("hiddenIsApproved")).Value.Trim());
                string configurationAuthToken = ((TextBox)GridUserDetails.Rows[e.RowIndex].FindControl("tbconfigurationAuthToken")).Text.Trim();
                string result = dataBaseProvider.updateExisingUserInfoIntoDataBase(ViewUserId, FirstName, LastName, EmailId, configurationAuthToken, 1, IsApproved, Password, APIlimit);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "User Update Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridUserDetails.EditIndex = -1;
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

        protected void GridUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserDetails.PageIndex = e.NewPageIndex;
            System.Data.DataTable dt = new DataTable();
            dt = (System.Data.DataTable)ViewState["DefaultDataTable"];
            string searchString = hdnSearchTxt.Value;
            if (!string.IsNullOrEmpty(searchString))
            {
                dt = FilterDataForExport(dt, searchString);
            }
            GridUserDetails.EditIndex = -1;
            GridUserDetails.DataSource = dt;
            GridUserDetails.DataBind();
        }

        protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton img = sender as ImageButton;
            int userId = Convert.ToInt32(img.CommandArgument);
            string result = dataBaseProvider.deleteUser(userId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "User Deleted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtSearchBox.Text = "";
                hdnSearchTxt.Value = "";
                GridUserDetails.EditIndex = -1;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ImgExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some Error Occured . Please Try Again Later";
                lblMsg.Style.Add("color", "Red");
                lblMsg.Style.Add("display", "block");
            }
        }

        protected void ImgExportToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "Report.csv";
                GridUserDetails.AllowPaging = false;
                DataTable dt1 = new DataTable("GridView_Data");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (TableCell cell in GridUserDetails.HeaderRow.Cells)
                {
                    if (!cell.Text.Equals("&nbsp;"))
                    {
                        dt1.Columns.Add(cell.Text.Trim());
                        sb.Append(cell.Text.Trim() + ',');
                    }
                }
                sb.Append("\r\n");

                foreach (GridViewRow row in GridUserDetails.Rows)
                {
                    dt1.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (!GridUserDetails.HeaderRow.Cells[i].Text.Trim().Equals("&nbsp;"))
                            {
                            string str = System.Net.WebUtility.HtmlDecode(row.Cells[i].Text);
                            dt1.Rows[dt1.Rows.Count - 1][i] = str;
                        }
                    }
                }

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/text";
                Response.AddHeader("content-disposition", "attachment;filename=" + name);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        sb.Append(Convert.ToString(dt1.Rows[i][j]) + ',');
                    }
                    sb.Append("\r\n");
                }
                string b = System.Net.WebUtility.HtmlDecode(sb.ToString());
                Response.Write(b);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some Error Occured . Please Try Again Later";
                lblMsg.Style.Add("color", "Red");
                lblMsg.Style.Add("display", "block");
            }

        }

        protected void ImgExportToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "Report.pdf";
                GridUserDetails.AllowPaging = false;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + name);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridUserDetails.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document doc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                HTMLWorker htmlParser = new HTMLWorker(doc);
                PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();
                htmlParser.Parse(sr);
                doc.Close();
                Response.Write(doc);
                Response.End();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some Error Occured . Please Try Again Later";
                lblMsg.Style.Add("color", "Red");
                lblMsg.Style.Add("display", "block");
            }
        }

        protected void imgBtnUserDetail_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = sender as ImageButton;
            int userId = Convert.ToInt32(img.CommandArgument);
            Session["ViewUserId"] = userId;
            Response.Redirect("~/frmUserDetailViewScreen.aspx");
        }

        protected void ImgAddNewUser_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserDetailViewScreen.aspx");
        }
    }
}