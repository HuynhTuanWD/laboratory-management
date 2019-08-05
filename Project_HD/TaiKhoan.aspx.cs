using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;
namespace Project_HD
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if (Session["VaiTro"].ToString() != "1")
            {
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                rptDanhSachNguoiDungBind();
            }
        }

        private void rptDanhSachNguoiDungBind()
        {
            DataTable t = DAO.clsNguoiDungDAO.getList();
            rptDanhSachNguoiDung.DataSource = t;
            rptDanhSachNguoiDung.DataBind();
            ddlVaiTro.DataSource = DAO.clsVaiTroDAO.getList();
            ddlVaiTro.DataTextField = "Ten";
            ddlVaiTro.DataValueField = "ID";
            ddlVaiTro.DataBind();
            ddlVaiTro.SelectedValue = "2";
        }

        protected void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (Session["VaiTro"].ToString() != "1")
            {
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
            }
            else
            {
                string tk = txtTaiKhoan.Text;
                string mk = DAO.clsString.GetMD5(txtMatKhau.Text);
                string ten = txtTenHienThi.Text;
                string sdt = txtTenHienThi.Text;
                int vt = Convert.ToInt32(ddlVaiTro.SelectedValue);
                if (DAO.clsNguoiDungDAO.isExistedTaiKhoan(tk))
                {
                    Response.Write("<script>alert(\"Thất bại! Tên tài khoản đã tồn tại\");</script>");
                }
                else
                {
                    if (string.IsNullOrEmpty(tk) ||
                        string.IsNullOrEmpty(mk) ||
                        string.IsNullOrEmpty(ten))
                    {
                        Response.Write("<script>alert(\"Thất bại! Không được để trống\");</script>");
                    }
                    else
                    {
                        if (DAO.clsNguoiDungDAO.addNguoiDung(tk, mk, ten, sdt, vt) && DAO.clsPhanQuyenDAO.insertNew(DAO.clsNguoiDungDAO.getIDByTK(tk)))
                        {
                            Response.Write("<script>alert(\"Tạo thành công\");</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert(\"Thất bại\");</script>");
                        }
                    }
                }
                rptDanhSachNguoiDungBind();
            }
        }

        protected void rptDanhSachNguoiDung_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Session["VaiTro"].ToString() != "1")
            {
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
                return;
            }
            else
            {
                Button btn = (Button)sender;
                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                Label lblid = (Label)item.FindControl("lblID");
                DropDownList ddl = (DropDownList)item.FindControl("ddl_VaiTro");
                int ID = Convert.ToInt32(lblid.Text);
                int ID_VaiTro = Convert.ToInt32(ddl.SelectedValue);
                DAO.clsNguoiDungDAO.updateNguoiDung(ID, ID_VaiTro);
                rptDanhSachNguoiDungBind();
            }
        }

        protected void btnXoa_Click1(object sender, EventArgs e)
        {
            if (Session["VaiTro"].ToString() != "1")
            {
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
                return;
            }
            else
            {
                if (DAO.clsNguoiDungDAO.xoaNguoiDung(Convert.ToInt32(txtID_NguoiDung.Text)))
                {
                    Response.Write("<script>alert(\"Xóa thành công\");</script>");
                }
                rptDanhSachNguoiDungBind();
            }
        }
    }
}