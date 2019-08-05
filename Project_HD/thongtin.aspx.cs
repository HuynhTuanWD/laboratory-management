using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
namespace Project_HD
{
    public partial class thongtin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if(!Page.IsPostBack)
            {
                DAO.clsPhanQuyenDAO PQDAO = new DAO.clsPhanQuyenDAO();
                DataRow t = PQDAO.getQuyen(Convert.ToInt32(Session["ID"]));
                txtTenHienThi.Text = Session["TenHienThi"].ToString();
                txtSDT.Text = t["SDT"].ToString();
            }
        }

        protected void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if(DAO.clsNguoiDungDAO.updateTenHienThi(Convert.ToInt32(Session["ID"]),txtTenHienThi.Text,txtSDT.Text))
            {
                Session["TenHienThi"] = txtTenHienThi.Text;
                Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
        }

        protected void btn_CapNhatMatKhau_Click(object sender, EventArgs e)
        {
            ThongBaoMK1.Style.Add("display", "none");
            ThongBaoMK2.Style.Add("display", "none");
            if (txtMatKhauMoi1.Text == txtMatKhauMoi2.Text && DAO.clsNguoiDungDAO.checkMatKhau(Convert.ToInt32(Session["ID"]), DAO.clsString.GetMD5(txtMatKhauCu.Text)))
            {
                if (DAO.clsNguoiDungDAO.changeMatKhau(Convert.ToInt32(Session["ID"]), DAO.clsString.GetMD5(txtMatKhauMoi1.Text)))
                {
                    ThongBaoMK1.Style.Add("display", "block");
                }
            }
            else
            {
                ThongBaoMK2.Style.Add("display", "block");
            }
        }
    }
}