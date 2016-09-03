using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using AdminTool.DataBase;
namespace AdminTool
{
    public partial class frmApiReport : System.Web.UI.Page
    {
        static  DataBaseProvider dataBaseProvider = new DataBaseProvider();
        protected void Page_Load(object sender, EventArgs e)
    {
             if (!IsPostBack)
            {
                try
                {
                    int LoggedInuserId;
                    LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
                    if (LoggedInuserId < 1)
                    { 
                        Response.Redirect("~/default.aspx"); 
                    
                    }
                    else
                    {
                        GetApiStatus(LoggedInuserId);
                        
                    }
                    ((Label)(Master).FindControl("lblUserName")).Text = Session["UserName"].ToString();


            //LoggedInuserId = Convert.ToInt32(Session["LoggedInuserId"]);
            //DataTable dt = new DataTable();
            //dt = dataBaseProvider.getApiStatusReport(LoggedInuserId);
            //ViewState["DefaultApiReportDataTable"] = dt;
            //        GridView1.DataSource = dt;
            //        GridView1.DataBind();

                }
                catch (Exception exc)
                {
                    ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, exc.Message);
                }
            }

    }

        public void GetApiStatus(int UserId)
        {
            //DataTable dt = new DataTable();
            //dt = dataBaseProvider.getApiStatusReport(LoggedInuserId);
            //ViewState["DefaultApiReportDataTable"] = dt;
            //        GridView1.DataSource = dt;
            //        GridView1.DataBind();



            DataTable dt = dataBaseProvider.getApiStatusReport(UserId);
            ViewState["DefaultDataTable"] = dt;
            if (dt.Rows.Count < 1)
            {
                emptyListMsg.Visible = true;
                GridView1.Visible = false;

            }
            else
            {
                emptyListMsg.Visible = false;
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void UpdateUser_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserList.aspx");
                
        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {

        }
       

        
    }


        }

        
