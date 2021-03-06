﻿using AdminTool.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminTool
{
    public partial class frmViewSubjectInfo : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  Session["ViewUserId"] = 5;
            Session["LoggedInuserId"] = 1;*/
            if (!IsPostBack)
            {
                try
                {
                    int LoggedInuserId, UserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    UserId = Convert.ToInt32(Session["ViewUserId"]);
                    AddNewSubject.Visible = false;
                    tbNewSubjectLine.Text = "";
                    if (LoggedInuserId < 1)
                    { Response.Redirect("~/default.aspx"); }
                    else
                    {
                        SetUserSubjectInfo(UserId);
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

        public void SetUserSubjectInfo(int userId)
        {
            if (userId > 0)
            {
                DataTable dt = dataBaseProvider.getListOfAllUserSubject(userId);
                ViewState["DefaultSubjectDataTable"] = dt;
                if (dt.Rows.Count < 1)
                {
                    GridSubjectDetail.Visible = false;
                    lblMsg.Text = "No Data Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    ImgExportToExcel.Enabled = false;
                    ImgExportToCSV.Enabled = false;
                    ImgExportToPDF.Enabled = false;
                }
                else
                {
                    GridSubjectDetail.AutoGenerateColumns = false;
                    GridSubjectDetail.Visible = true;
                    GridSubjectDetail.DataSource = dt;
                    GridSubjectDetail.DataBind();
                    ImgExportToExcel.Enabled = true;
                    ImgExportToCSV.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                }
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstring = txtSearchBox.Text.Trim();
            GridSubjectDetail.EditIndex = -1;
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
                dt = (DataTable)ViewState["DefaultSubjectDataTable"];
                if (dt.Rows.Count == 0)
                {
                    FillDefaultGridView(false);
                    dt = (DataTable)ViewState["DefaultSubjectDataTable"];
                }

                Session["SearchString"] = searchstring;
                dt = FilterData(searchstring, dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridSubjectDetail.DataSource = dt;
                    GridSubjectDetail.DataBind();
                    ImgExportToCSV.Enabled = true;
                    ImgExportToExcel.Enabled = true;
                    ImgExportToPDF.Enabled = true;
                 }
                else
                {
                    DataTable dtnew = dt;
                    dtnew.Clear();
                    GridSubjectDetail.DataSource = dtnew;
                    GridSubjectDetail.DataBind();
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
            dt = dataBaseProvider.getListOfAllUserSubject(ViewUserId);
            AddNewSubject.Visible = false;
            ViewState["DefaultSubjectDataTable"] = dt;

            if (!string.IsNullOrEmpty(hdnSearchTxt.Value))
            {
                dt = FilterData(hdnSearchTxt.Value, dt);
            }

            GridSubjectDetail.DataSource = dt;
            GridSubjectDetail.DataBind();

            if (dt != null && dt.Rows.Count > 0)
            {
                ImgExportToCSV.Enabled = true;
                ImgExportToExcel.Enabled = true;
                ImgExportToPDF.Enabled = true;
                GridSubjectDetail.Visible = true;
            }
            else
            {
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
                GridSubjectDetail.Visible = false;
                lblMsg.Text = "No DataFound";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected DataTable FilterData(string searchString, DataTable dt)
        {
            DataTable dtnew = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] foundRows = dt.Select("subjectLine LIKE '%" + searchString + "%'");
                foreach (DataRow row in foundRows)
                    dtnew.ImportRow(row);
            }

            return dtnew;
        }
        protected void ImgAddSubject_Click(object sender, EventArgs e)
        {
            AddNewSubject.Visible = true;
            lblMsg.Visible = false;
            if (GridSubjectDetail.Rows.Count <= 0)
            {
                ImgExportToCSV.Enabled = false;
                ImgExportToExcel.Enabled = false;
                ImgExportToPDF.Enabled = false;
            }
        }

        protected void ImgExportToPDF_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToCSV_Click(object sender, EventArgs e)
        {

        }

        protected void ImgExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void GridSubjectDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SubjectId = Convert.ToInt32(GridSubjectDetail.DataKeys[e.RowIndex].Values["Id"]);
            string result = dataBaseProvider.DeleteSubjectById(SubjectId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Subject Deleted Sucessfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void GridSubjectDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridSubjectDetail.EditIndex = -1;
            FillDefaultGridView(false);
        }

        protected void GridSubjectDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int SubjectId = Convert.ToInt32(((HiddenField)GridSubjectDetail.Rows[e.RowIndex].FindControl("hiddenSubjectId")).Value.Trim());
                string SubjectLine = ((TextBox)GridSubjectDetail.Rows[e.RowIndex].FindControl("tbSubjectLine")).Text.Trim();
                string result = dataBaseProvider.UpdateSubjectInfoById(SubjectLine, SubjectId);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "Subject Update Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridSubjectDetail.EditIndex = -1;
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

        protected void GridSubjectDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridSubjectDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridSubjectDetail.EditIndex = e.NewEditIndex;

            FillDefaultGridView(false);

        }

        protected void GridSubjectDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = sender as ImageButton;
            int SubjectId = Convert.ToInt32(img.CommandArgument);
            string result = dataBaseProvider.DeleteSubjectById(SubjectId);
            if (result.Equals("SUCCESS"))
            {
                lblMsg.Text = "Subject Deleted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtSearchBox.Text = "";
                hdnSearchTxt.Value = "";
                GridSubjectDetail.EditIndex = -1;
                FillDefaultGridView(true);
            }
            else
            {
                lblMsg.Text = "Some Error Occured";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void imgBtnNewSubjectLine_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSubject.Visible = false;
                int userId = Convert.ToInt32(Session["ViewUserId"]);
                string SubjectLine = tbNewSubjectLine.Text.ToString();
                string result = dataBaseProvider.AddNewSubject(SubjectLine, userId);
                if (result.Equals("SUCCESS"))
                {
                    lblMsg.Text = "Subject Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridSubjectDetail.EditIndex = -1;
                    tbNewSubjectLine.Text = "";
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

        protected void imgBtnNewSubjectLineCancel_Click(object sender, EventArgs e)
        {
            AddNewSubject.Visible = false;
            tbNewSubjectLine.Text = "";
            FillDefaultGridView(true);

        }

        protected void ImageGoBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/frmUserDetailViewScreen.aspx");
        }

        protected void imgBtnSubjectDetail_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton img = sender as ImageButton;
            int SubjectId = Convert.ToInt32(img.CommandArgument);
            Session["ViewUserSubjectId"] = SubjectId;
            Response.Redirect("~/frmMailContentSplitInfo.aspx");
        }
    }
}