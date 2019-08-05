using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class NhapLieu_DNCN : System.Web.UI.Page
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
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                rptDNCNBind(id);
            }
        }

        private void rptDNCNBind(int id)
        {
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow TN = TNDAO.getThiNghiemByID(id);
            if (TN["QuyenSua"].ToString() == "0" && Session["VaiTro"].ToString() != "1")
            {
                Server.Transfer("index.aspx");
                return;
            }
            else
            {
                lblID_ThiNghiem.Text = id.ToString();
                if (TN["ID_LoaiThiNghiem"].ToString() == "1")
                    lblTenThiNghiem.Text = "Dầu cách điện";
                else
                    lblTenThiNghiem.Text = "Dầu nhớt công nghiệp";
                lblXuatXu.Text = TN["XuatXu"].ToString();
                DAO.clsPhanQuyenDAO PQDAO = new DAO.clsPhanQuyenDAO();
                DataRow tblND = PQDAO.getQuyen(Convert.ToInt32(Session["ID"]));
                DAO.clsNhapLieuDAO NLDAO = new DAO.clsNhapLieuDAO();
                DataTable tblDNCN = new DataTable();
                tblDNCN = NLDAO.selectNhapLieu_DNCN(id);
                DataView view = new DataView(tblDNCN);
                if (tblND["VaiTro"].ToString() != "1")
                {
                    string filter = "ID_DacTinh IN (0,";
                    string[] arr = tblND["NhapLieu_DNCN"].ToString().Split(' ');
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        filter = filter + arr[i] + ",";
                    }
                    filter += ")";
                    view.RowFilter = filter;
                }
                rptDNCN.DataSource = view;
                rptDNCN.DataBind();
            }
        }

        protected void rptDNCN_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CapNhat")
            {
                RepeaterItem t = e.Item;
                Label lblIDDacTinh = t.FindControl("lblID_DacTinh") as Label;
                TextBox txtNoiDung = t.FindControl("txtNoiDung") as TextBox;
                int ID_ThiNghiem = Convert.ToInt32(lblID_ThiNghiem.Text);
                int ID_DacTinh = Convert.ToInt32(lblIDDacTinh.Text);
                string NoiDung = txtNoiDung.Text;
                string ND = Session["TenHienThi"].ToString();
                DAO.clsNhapLieuDAO NLDAO = new DAO.clsNhapLieuDAO();
                NLDAO.updateNhapLieu_DNCN(ID_ThiNghiem, ID_DacTinh, NoiDung, ND);
                rptDNCNBind(ID_ThiNghiem);
            }
        }
    }
}