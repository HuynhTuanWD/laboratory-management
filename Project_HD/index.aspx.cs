using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                if (Request.Form["Label1"]!=null)
                    Response.Write("<script>alert(\"" + Request.Form["Label1"].ToString() + "\")</script>");
                Server.Transfer("Login.aspx", true);
                return;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string key = DAO.clsString.convertToUnSign3(txtSearch.Text).ToLower();
            Response.Redirect("SearchThiNghiem.aspx?q=" + key);
        }
    }
}