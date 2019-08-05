using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Globalization;
namespace Project_HD
{
    public partial class Report_DCD : System.Web.UI.Page
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
                rptDCDBind();
                lblThiNghiemBind();
            }
        }
        private void lblThiNghiemBind()
        {
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow t = TNDAO.getThiNghiemByID(Convert.ToInt32(Request.QueryString["ID"]));
            lbl_kqxuatxu.Text = t["XuatXu"].ToString();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            lbl_kqngaylaymau.Text = Convert.ToDateTime(t["NgayLayMau"]).ToString("d/M/yyyy");
            lbl_kqngaynhanmau.Text = Convert.ToDateTime(t["NgayNhanMau"]).ToString("d/M/yyyy");
            lbl_kqngaythumau.Text = Convert.ToDateTime(t["NgayThuMau"]).ToString("d/M/yyyy");
            lbl_kqlydothinghiem.Text = t["LyDoThiNghiem"].ToString();
            lbl_kqphutrachlaymau.Text = t["PhuTrachLayMau"].ToString();
            lbl_kqghichu.Text = t["GhiChu"].ToString();
        }
        private void rptDCDBind()
        {
            lblSoCot.Text = countCol().ToString();
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow rowThiNghiem = TNDAO.getThiNghiemByID(ID);
            int ID_LoaiThiNghiem = Convert.ToInt32(rowThiNghiem["ID_LoaiThiNghiem"]);
            lbl_DCD_title4.Text = DAO.clsLoaiThiNghiemDAO.getTenThiNghiemByID(ID_LoaiThiNghiem).Rows[0][0].ToString();
            rptCot.DataSource = DAO.clsCotThiNghiem_Mapping.getCotByIDLoai(ID_LoaiThiNghiem);
            rptCot.DataBind();
            rptThiNghiem.DataSource = DAO.clsNhapLieuDAO.selectNhapLieuByIDTN(ID);
            rptThiNghiem.DataBind();
        }
        public int countCol()
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow rowThiNghiem = TNDAO.getThiNghiemByID(ID);
            int ID_LoaiThiNghiem = Convert.ToInt32(rowThiNghiem["ID_LoaiThiNghiem"]);
            return DAO.clsCotThiNghiem_Mapping.countCot(ID_LoaiThiNghiem);
        }
    }
}