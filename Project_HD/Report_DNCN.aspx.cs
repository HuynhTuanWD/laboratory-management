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
    public partial class Report_DNCN : System.Web.UI.Page
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
                rptDNCNBind();
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
        private void rptDNCNBind()
        {
            DAO.clsNhapLieuDAO NLDAO = new DAO.clsNhapLieuDAO();
            DataTable tblDNCN = new DataTable();
            tblDNCN = NLDAO.selectNhapLieu_DNCN(Convert.ToInt32(Request.QueryString["ID"]));
            rptDNCN.DataSource = tblDNCN;
            rptDNCN.DataBind();
        }
    }
}