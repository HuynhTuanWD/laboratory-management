using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class SuaThiNghiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                int ID_LoaiThiNghiem = Convert.ToInt32(Request.QueryString["ID_LoaiThiNghiem"]);
                form_ThiNghiemBind(ID, ID_LoaiThiNghiem);
                txtTenThiNghiem.Text = "Thí nghiệm thứ " + Request.QueryString["ID"].ToString();
            }
        }

        private void form_ThiNghiemBind(int ID, int ID_LoaiThiNghiem)
        {
            string t = DAO.clsLoaiThiNghiemDAO.getTenThiNghiemByID(ID_LoaiThiNghiem).Rows[0][0].ToString();
            txtTenLoaiThiNghiem.Text = t;
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            var rowThiNghiem = TNDAO.getThiNghiemByID(ID);
            if (rowThiNghiem["QuyenSua"].ToString() == "0" && Session["VaiTro"].ToString() != "1")
                btnSuaThiNghiem.Visible = false;
            txtXuatXu.Text = rowThiNghiem["XuatXu"].ToString();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            txtNgayLayMau.Text = Convert.ToDateTime(rowThiNghiem["NgayLayMau"]).ToString("d/M/yyyy");
            txtNgayNhanMau.Text = Convert.ToDateTime(rowThiNghiem["NgayNhanMau"]).ToString("d/M/yyyy");
            txtNgayThuMau.Text = Convert.ToDateTime(rowThiNghiem["NgayThuMau"]).ToString("d/M/yyyy");
            txtLyDoThiNghiem.Text = rowThiNghiem["LyDoThiNghiem"].ToString();
            txtPhuTrachLayMau.Text = rowThiNghiem["PhuTrachLayMau"].ToString();
            txtGhiChu.Text = rowThiNghiem["GhiChu"].ToString();
        }

        protected void btnSuaThiNghiem_Click(object sender, EventArgs e)
        {
            DTO.clsThiNghiemDTO TN = new DTO.clsThiNghiemDTO();
            TN.XuatXu = txtXuatXu.Text;
            TN.SearchXuatXu = DAO.clsString.convertToUnSign3(txtXuatXu.Text);
            int flag = 0;
            DateTime a, b, c;
            if (DateTime.TryParseExact(txtNgayLayMau.Text, "d/M/yyyy", null, DateTimeStyles.None, out a)
                && DateTime.TryParseExact(txtNgayNhanMau.Text, "d/M/yyyy", null, DateTimeStyles.None, out b)
                && DateTime.TryParseExact(txtNgayThuMau.Text, "d/M/yyyy", null, DateTimeStyles.None, out c))
            {
                TN.NgayLayMau = a;
                TN.NgayNhanMau = b;
                TN.NgayThuMau = c;
            }
            else
            {
                flag = 1;
            }
            TN.LyDoThiNghiem = txtLyDoThiNghiem.Text;
            TN.PhuTrachLayMau = txtPhuTrachLayMau.Text;
            TN.GhiChu = txtGhiChu.Text;
            TN.ID = Convert.ToInt32(Request.QueryString["ID"]);
            TN.Updated_by = Session["TenHienThi"].ToString();
            TN.Copy = 0;
            if (flag == 0 && DAO.clsThiNghiemDAO.updateThiNghiemByID(TN))
            {
                Response.Write("<script>alert(\"Cập Nhật Thành Công\");</script>");
            }
            else
            {
                Response.Write("<script>alert(\"Sai Định Dạng\");</script>");
            }
        }
    }
}