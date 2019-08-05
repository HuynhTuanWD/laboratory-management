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
    public partial class ThiNghiem : System.Web.UI.Page
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
                ddlLoaiThiNghiemBind();
            }
        }
        private void Pagination()
        {
            int numbItem = 10;
            int curPage = 1;
            int numbMaxPage = 1;
            int fromRowPrevious;
            if (Global.numbMaxRow_ThiNghiem != 0)
            {
                if (Global.numbMaxRow_ThiNghiem % numbItem == 0)
                {
                    numbMaxPage = Global.numbMaxRow_ThiNghiem / numbItem;
                }
                else
                {
                    numbMaxPage = Global.numbMaxRow_ThiNghiem / numbItem + 1;
                }
            }
            if (Request.QueryString["page"] != null)
                curPage = Convert.ToInt32(Request.QueryString["page"]);
            if (curPage < 1)
                curPage = 1;
            if (curPage > numbMaxPage)
                curPage = numbMaxPage;
            fromRowPrevious = curPage * numbItem;
            if (Global.numbMaxRow_ThiNghiem % numbItem > 0 && curPage == numbMaxPage)
            {
                numbItem = Global.numbMaxRow_ThiNghiem % numbItem;
                fromRowPrevious = Global.numbMaxRow_ThiNghiem;
            }
            //button
            btn_previous.Enabled = true;
            btn_next.Enabled = true;
            if (curPage == 1)
                btn_previous.Enabled = false;
            if (curPage == numbMaxPage)
                btn_next.Enabled = false;
            lblSoTrang.Text = curPage + "/" + numbMaxPage;
            // bind data
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            rptThiNghiem.DataSource = TNDAO.getListDSThiNghiemPaging(numbItem, fromRowPrevious);
            rptThiNghiem.DataBind();
        }
        private void rptThiNghiemBind() // 1: previous 2:next 3: edit 4: del row
        {
            Pagination();
        }

        private void ddlLoaiThiNghiemBind()
        {
            ddlLoaiThiNghiem.DataTextField = "TenLoai";
            ddlLoaiThiNghiem.DataValueField = "ID";
            DataTable t = DAO.clsLoaiThiNghiemDAO.getListLoaiThiNghiem();
            ddlLoaiThiNghiem.DataSource = t;
            ddlLoaiThiNghiem.DataBind();
        }

        protected void btnTaoThiNghiem_Click(object sender, EventArgs e)
        {
            DAO.clsPhanQuyenDAO PQDAO = new DAO.clsPhanQuyenDAO();
            DataRow tbl_ND = PQDAO.getQuyen(Convert.ToInt32(Session["ID"]));
            if (tbl_ND["VaiTro"].ToString() == "1" || tbl_ND["TaoThiNghiem"].ToString() == "1")
            {
                DTO.clsThiNghiemDTO TN = new DTO.clsThiNghiemDTO();
                int flag = 0;
                TN.XuatXu = txtXuatXu.Text;
                TN.SearchXuatXu = DAO.clsString.convertToUnSign3(txtXuatXu.Text);
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
                TN.ID_LoaiThiNghiem = Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue);
                TN.Created_at = DateTime.Now;
                TN.Created_by = Session["TenHienThi"].ToString();
                if (flag == 0)
                {
                    DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
                    TN.ID = TNDAO.lastID() + 1;
                    if (DAO.clsThiNghiemDAO.addThiNghiem(TN))
                    {
                        // Thêm list NhapLieu
                        DAO.clsNhapLieuDAO NLDAO = new DAO.clsNhapLieuDAO();
                        NLDAO.insertNhapLieu(TN.ID,TN.ID_LoaiThiNghiem);
                        //
                        Response.Write("<script>alert(\"Thêm Thành Công\");</script>");
                        Global.numbMaxRow_ThiNghiem = TNDAO.getNumbMaxPage();
                        rptThiNghiemBind();
                    }
                }
                else
                {
                    Response.Write("<script>alert(\"Sai Định Dạng\");</script>");
                }
            }
            else
            {
                Response.Write("<script>alert(\"Bạn không có quyền\");</script>");
            }
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
            if(e.CommandName == "btn_Copy")
            {
                Label idCopy = e.Item.FindControl("mazic_lblID") as Label;
                Label loaithinghiem = e.Item.FindControl("mazic_lblLoaiThiNghiem") as Label;
                DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
                int ID = TNDAO.lastID() + 1;
                if(DAO.clsThiNghiemDAO.insertCopy(ID,Convert.ToInt32(idCopy.Text), Session["TenHienThi"].ToString()))
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
            if(e.CommandName== "btn_XuatBaoCao")
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
                    if(tbl_ND["TaoThiNghiem"].ToString()=="0")
                    {
                        btnTaoThiNghiem.Visible = false;
                    }
                    if(tbl_ND["SuaThiNghiem"].ToString()=="0")
                    {
                        btnSua.Visible = false;
                    }
                    if(tbl_ND["XuatBaoCao"].ToString()=="0")
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

        protected void btn_previous_Click(object sender, EventArgs e)
        {
            int curPage;
            if (Request.QueryString["page"] == null)
                curPage = 1;
            else
                curPage = Convert.ToInt32(Request.QueryString["page"]) - 1;
            Response.Redirect("ThiNghiem.aspx?page=" + curPage);
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            int curPage;
            if (Request.QueryString["page"] == null)
                curPage = 2;
            else
                curPage = Convert.ToInt32(Request.QueryString["page"]) + 1;
            Response.Redirect("ThiNghiem.aspx?page=" + curPage);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string key = DAO.clsString.convertToUnSign3(txtSearch.Text).ToLower();
            Response.Redirect("SearchThiNghiem.aspx?q=" + key);
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
        }
    }
}