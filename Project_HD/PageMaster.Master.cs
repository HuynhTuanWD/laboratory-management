using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public static class StringExtension
    {
        public static DateTime? ToDate(this string a)
        {
            try
            {
                string[] dt = a.Split('/');
                DateTime x = new DateTime(Convert.ToInt32(dt[2]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[0]));
                return x;
            }
            catch (Exception x)
            {
                return null;
            }
        }
    }
    public partial class PageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ten.InnerHtml = Session["TenHienThi"].ToString();
            }
        }
        protected void btn_logoutClick(object sender, EventArgs e)
        {
            Session.Clear();
            Server.Transfer("Login.aspx");
        }
    }
}