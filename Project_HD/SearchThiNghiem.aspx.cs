using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class SearchThiNghiem : System.Web.UI.Page
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
                rptThiNghiemBind();
            }
        }
        private void rptThiNghiemBind()
        {
            string key = DAO.clsString.convertToUnSign3(Request.QueryString["q"].ToString()).ToLower();
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DateTime a, b;
            if (DateTime.TryParseExact(Request.QueryString["q"].ToString(), "d/M/yyyy", null, DateTimeStyles.None, out a))
            {
                b = a.AddDays(1);
                rptThiNghiem.DataSource = TNDAO.getListSearchDSThiNghiemByDate(a, b);
            }
            else
            {
                rptThiNghiem.DataSource = TNDAO.getListSearchDSThiNghiemByString(key);
            }
            rptThiNghiem.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            string key = DAO.clsString.convertToUnSign3(txtSearch.Text);
            Response.Redirect("SearchThiNghiem.aspx?q=" + key);
        }

        protected void rptThiNghiem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn_Sua")
            {
                Label id = e.Item.FindControl("mazic_lblID") as Label;
                Label loaithinghiem = e.Item.FindControl("mazic_lblLoaiThiNghiem") as Label;
                Response.Redirect("SuaThiNghiem.aspx?ID=" + id.Text + "&ID_LoaiThiNghiem=" + loaithinghiem.Text);
            }
            if (e.CommandName == "btn_Khoa")
            {
                Label id = e.Item.FindControl("mazic_lblID") as Label;
                Label quyensua = e.Item.FindControl("mazic_lblQuyenSua") as Label;
                int quyen = Convert.ToInt32(quyensua.Text) == 1 ? 0 : 1;
                DAO.clsThiNghiemDAO.updateQuyen(Convert.ToInt32(id.Text), quyen);
                rptThiNghiemBind();
            }
            if (e.CommandName == "btn_Xoa")
            {
                Label id = e.Item.FindControl("mazic_lblID") as Label;
                DAO.clsThiNghiemDAO.updateTrangThai(Convert.ToInt32(id.Text), 0);
                DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
                Global.numbMaxRow_ThiNghiem = TNDAO.getNumbMaxPage();
                rptThiNghiemBind();
            }
            if (e.CommandName == "btn_Copy")
            {
                Label idCopy = e.Item.FindControl("mazic_lblID") as Label;
                Label loaithinghiem = e.Item.FindControl("mazic_lblLoaiThiNghiem") as Label;
                DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
                int ID = TNDAO.lastID() + 1;
                if (DAO.clsThiNghiemDAO.insertCopy(ID, Convert.ToInt32(idCopy.Text), Session["TenHienThi"].ToString()))
                {
                    // Thêm list NhapLieu
                    DAO.clsNhapLieuDAO NLDAO = new DAO.clsNhapLieuDAO();
                    NLDAO.insertNhapLieu(ID, Convert.ToInt32(loaithinghiem.Text));
                    //
                    Global.numbMaxRow_ThiNghiem = TNDAO.getNumbMaxPage();
                    rptThiNghiemBind();
                }
                Global.numbMaxRow_ThiNghiem = TNDAO.getNumbMaxPage();
                rptThiNghiemBind();
            }
            if (e.CommandName == "btn_XuatBaoCao")
            {
                DAO.clsThiNghiemDAO.updateBaoCao(Convert.ToInt32(e.CommandArgument));
                rptThiNghiemBind();
            }
        }

        protected void rptThiNghiem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DAO.clsPhanQuyenDAO PQDAO = new DAO.clsPhanQuyenDAO();
            DataRow tbl_ND = PQDAO.getQuyen(Convert.ToInt32(Session["ID"]));
            if (tbl_ND["VaiTro"] == null)
            {
                Response.Redirect("index.aspx");
                return;
            }
            if (tbl_ND["VaiTro"].ToString() != "1")
            {
                foreach (RepeaterItem item in ((Repeater)sender).Items)
                {
                    Button btnXoa = item.FindControl("btn_XoaContent") as Button;
                    Button btnXoa1 = item.FindControl("btn_Xoa") as Button;
                    Button btnSua = item.FindControl("btn_Sua") as Button;
                    Button btnKhoa = item.FindControl("btn_Khoa") as Button;
                    Label lblQuyenSua = item.FindControl("mazic_lblQuyenSua") as Label;
                    HyperLink hyper_NhapLieu = item.FindControl("hyperNhapLieu") as HyperLink;
                    HyperLink hyper_XuatBaoCao = item.FindControl("hyperXuatBaoCao") as HyperLink;
                    btnKhoa.Visible = false;
                    btnXoa.Visible = false;
                    btnXoa1.Visible = false;
                    if (lblQuyenSua.Text == "0")
                    {
                        btnSua.Visible = false;
                        hyper_NhapLieu.Visible = false;
                    }
                    if (tbl_ND["SuaThiNghiem"].ToString() == "0")
                    {
                        btnSua.Visible = false;
                    }
                    if (tbl_ND["XuatBaoCao"].ToString() == "0")
                    {
                        hyper_XuatBaoCao.Visible = false;
                    }
                }
            }
            if (tbl_ND["VaiTro"].ToString() == "1")
            {
                foreach (RepeaterItem item in ((Repeater)sender).Items)
                {
                    Button btnKhoa = item.FindControl("btn_Khoa") as Button;
                    Label lblQuyenSua = item.FindControl("mazic_lblQuyenSua") as Label;
                    if (lblQuyenSua.Text == "1")
                    {
                        btnKhoa.Text = "";
                        btnKhoa.CssClass = "btn btn-outline-primary font-weight-bold fa";
                    }
                    if (lblQuyenSua.Text == "0")
                    {
                        btnKhoa.Text = "";
                        btnKhoa.CssClass = "btn btn-outline-secondary font-weight-bold fa";
                    }
                }
            }
        }
    }
}