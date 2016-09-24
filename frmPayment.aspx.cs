using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AdminTool.DataBase;
using System.Configuration;

namespace AdminTool
{
    public partial class frmPayment : System.Web.UI.Page
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
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
                        GetPaymentInfo(LoggedInuserId);

                    }
                    ((Label)(Master).FindControl("lblUserName")).Text = Session["UserName"].ToString();
                }
                catch (Exception exc)
                {
                    ExceptionAndErrorClass.StoretheErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, exc.Message);
                }
            }

        }

        public void GetPaymentInfo(int UserId)
        {
            DataTable dt = new DataTable();
            dt = dataBaseProvider.getAvailablePaymentOption(UserId);

            if (dt.Rows.Count < 1)
            {
                emptyListMsg.Visible = true;
                GridPaymentDetails.Visible = false;

            }
            else
            {
                emptyListMsg.Visible = false;
                GridPaymentDetails.Visible = true;
                GridPaymentDetails.DataSource = dt;
                GridPaymentDetails.DataBind();
            }
        }


        protected void imgBtnUserpayment_Click(object sender, EventArgs e)
        {
            Button img = sender as Button;
          //  int paymentId = Convert.ToInt32(img.CommandArgument.ToString());
            //Session["paymentId"] = paymentId;

            string Username = (string)Request.QueryString["Username"];
            string amount = "7.0";
            Response.Redirect("Checkout/CheckoutStart.aspx");
        }

        protected void ImageGoBack3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmApiReport.aspx");
        }
    }
}