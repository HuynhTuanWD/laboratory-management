using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class BangPhanQuyen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if(Session["VaiTro"].ToString()!="1")
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            // rptPhanQuyenBind
            lblID_NguoiDung.Text = Request.QueryString["ID"].ToString();
            DAO.clsPhanQuyenDAO PQDAO = new DAO.clsPhanQuyenDAO();
            DataRow tblND = PQDAO.getQuyen(Convert.ToInt32(lblID_NguoiDung.Text));
            lblTenNV1.InnerText = "Phân quyền nhân viên " + tblND["TenHienThi"];
            lblTenNV2.InnerText = "Tên tài khoản: " + tblND["TaiKhoan"];
            chkTaoThiNghiem.Checked = Convert.ToBoolean(Convert.ToInt32(tblND["TaoThiNghiem"]));
            chkSuaThiNghiem.Checked = Convert.ToBoolean(Convert.ToInt32(tblND["SuaThiNghiem"]));
            chkXuatBaoCao.Checked = Convert.ToBoolean(Convert.ToInt32(tblND["XuatBaoCao"]));
            DataTable listLTN = DAO.clsLoaiThiNghiemDAO.getListLoaiThiNghiem();
            rptPhanQuyen.DataSource = listLTN;
            rptPhanQuyen.DataBind();
            DataTable listThiNghiem = DAO.clsPhanQuyenDAO.getList(Convert.ToInt32(lblID_NguoiDung.Text));
            foreach(RepeaterItem item in rptPhanQuyen.Items)
            {
                Repeater rptThiNghiem = item.FindControl("rptThiNghiem") as Repeater;
                Label ID_LoaiThiNghiem = item.FindControl("lblID_LoaiThiNghiem") as Label;
                DataView tn = new DataView(listThiNghiem);
                tn.RowFilter = "ID_LoaiThiNghiem="+Convert.ToInt32(ID_LoaiThiNghiem.Text);
                tn.Sort = "ChiSo ASC";
                rptThiNghiem.DataSource = tn;
                rptThiNghiem.DataBind();
            }

            // ddlVaiTroBind
            DataTable t = DAO.clsVaiTroDAO.getList();
            ddlVaiTro.DataSource = t;
            ddlVaiTro.DataTextField = "Ten";
            ddlVaiTro.DataValueField = "VaiTro";
            ddlVaiTro.SelectedValue = tblND["VaiTro"].ToString();
            ddlVaiTro.DataBind();
        }
        protected void btn_CapNhatQuyen_Click(object sender, EventArgs e)
        {
            int size = 0;
            foreach (RepeaterItem item in rptPhanQuyen.Items)
            {
                Repeater rptThiNghiem = item.FindControl("rptThiNghiem") as Repeater;
                size += rptThiNghiem.Items.Count;
            }
            int[] ID_DacTinh = new int[size];
            int[] Quyen = new int[size];
            int i = 0;
            foreach (RepeaterItem itemPQ in rptPhanQuyen.Items)
            {
                Repeater rptThiNghiem = itemPQ.FindControl("rptThiNghiem") as Repeater;
                foreach(RepeaterItem itemTN in rptThiNghiem.Items)
                {
                    Label ID_DT = itemTN.FindControl("lblID") as Label;
                    CheckBox chkQuyen = itemTN.FindControl("chkQuyen") as CheckBox;
                    ID_DacTinh[i] = Convert.ToInt32(ID_DT.Text);
                    Quyen[i] = Convert.ToInt32(chkQuyen.Checked);
                    i++;
                }
            }
            DAO.clsNguoiDungDAO.updateQuyen(Convert.ToInt32(lblID_NguoiDung.Text), Convert.ToInt32(ddlVaiTro.SelectedValue), Convert.ToInt32(chkTaoThiNghiem.Checked), Convert.ToInt32(chkSuaThiNghiem.Checked), Convert.ToInt32(chkXuatBaoCao.Checked));
            if(DAO.clsPhanQuyenDAO.updateQuyen(Convert.ToInt32(lblID_NguoiDung.Text),ID_DacTinh,Quyen,size))
            {

            }
        }

        //private void rptChaBind()
        //{
        //    DataTable cha = new DataTable();
        //    cha.Columns.Add("cot1");
        //    cha.Rows.Add("123");
        //    cha.Rows.Add("456");
        //    rptCha.DataSource = cha;
        //    rptCha.DataBind();
        //    DataTable con = new DataTable();
        //    con.Columns.Add("cot2");
        //    con.Rows.Add("abc");
        //    con.Rows.Add("xyz");
        //    foreach(RepeaterItem rpt in rptCha.Items)
        //    {
        //        Repeater t = rpt.FindControl("rptCon") as Repeater;
        //        t.DataSource = con;
        //        t.DataBind();
        //    }
        //}
    }
}