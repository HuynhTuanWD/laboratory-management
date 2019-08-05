using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
namespace Project_HD
{
    public partial class Login : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                Server.Transfer("index.aspx", true);
                return;
            }
            if(!Page.IsPostBack)
            {
                Session["ID"] = null;
                Session["TaiKhoan"] = null;
                Session["MatKhau"] = null;
                Session["TenHienThi"] = null;
                Session["VaiTro"] = null;
            }
        }

        protected void btn_DangNhapClick(object sender, EventArgs e)
        {
            DataRow t = DAO.clsNguoiDungDAO.getAccount(txtTenTaiKhoan.Text.ToString(), DAO.clsString.GetMD5(txtMatKhau.Text.ToString()));
            if (t == null)
            {
                ThongBao.Style.Add("display", "block");
            }
            else 
            {
                Session["ID"] = t["ID"];
                Session["TaiKhoan"] = t["TaiKhoan"];
                Session["MatKhau"] = t["MatKhau"];
                Session["TenHienThi"] = t["TenHienThi"];
                Session["VaiTro"] = t["VaiTro"];
                Server.Transfer("index.aspx", true);
            }
        }

    }
}