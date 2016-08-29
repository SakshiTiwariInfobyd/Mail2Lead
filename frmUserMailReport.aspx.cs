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
    public partial class frmUserMailReport : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int LoggedInuserId, UserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    UserId = Convert.ToInt32(Session["ViewUserId"]);
                    SetupUserReport(UserId);
                }
                catch (Exception ex)
                { }
            }
        }

        private void SetupUserReport(int userId)
        {
            if (userId < 0)
            {
                Response.Redirect("~/default.aspx");
            }
            else
            {
                DataTable dt = dataBaseProvider.GetUserMailReportByUserId(userId);
                ViewState["DefaultUserMailReportDataTable"] = dt;
                if (dt.Rows.Count < 1)
                {
                    ImgExportToCSV.Enabled = false;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                    GridUserMailReport.Visible = false;
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    GridUserMailReport.Visible = true;
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                    GridUserMailReport.DataSource = dt;
                    GridUserMailReport.DataBind();
                }
            }
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {

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

        protected void GridUserMailReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

    }
}