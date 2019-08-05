using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class LoaiThiNghiem : System.Web.UI.Page
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
            }
            if (!Page.IsPostBack)
            {
                rptLoaiThiNghiemBind();
            }
        }

        private void rptLoaiThiNghiemBind()
        {
            rptLoaiThiNghiem.DataSource = DAO.clsLoaiThiNghiemDAO.getListLoaiThiNghiem();
            rptLoaiThiNghiem.DataBind();
            DAO.clsCotThiNghiem_Mapping CTN = new DAO.clsCotThiNghiem_Mapping();
            DataTable TableCTN = CTN.getFullCotThiNghiem();
            foreach (RepeaterItem item in rptLoaiThiNghiem.Items)
            {
                Repeater CotTN = item.FindControl("rptCotThiNghiem") as Repeater;
                Label ID = item.FindControl("lblID_LoaiThiNghiem") as Label;
                Button btnThemCot = item.FindControl("btn_ThemCot") as Button;
                DataView t = new DataView(TableCTN);
                btnThemCot.Visible = true;
                t.RowFilter = "ID_LoaiThiNghiem=" + ID.Text;
                if (t.Count == 4)
                {
                    btnThemCot.Visible = false;
                }
                CotTN.DataSource = t;
                CotTN.DataBind();
                if (t.Count > 0)
                {
                    Button btnXoa = CotTN.Items[t.Count - 1].FindControl("btn_XoaCot") as Button;
                    btnXoa.Visible = true;
                }
            }
        }

        protected void rptLoaiThiNghiem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }

        protected void btn_ThemLoaiThiNghiem_Click(object sender, EventArgs e)
        {
            DAO.clsCotThiNghiem_Mapping CTNDAO = new DAO.clsCotThiNghiem_Mapping();
            int lastID = DAO.clsLoaiThiNghiemDAO.insertThiNghiemNewLastID();
            if(CTNDAO.insertNew(lastID))
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void rptLoaiThiNghiem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "btn_CapNhatLoaiThiNghiem")
            {
                Label _ID = e.Item.FindControl("lblID_LoaiThiNghiem") as Label;
                TextBox _TenLoai = e.Item.FindControl("txtTenLoaiThiNghiem") as TextBox;
                int ID = Convert.ToInt32(_ID.Text);
                string TenLoai = _TenLoai.Text;
                DAO.clsLoaiThiNghiemDAO.updateTenLoaiThiNghiem(ID, TenLoai);
            }
            if(e.CommandName == "btn_XoaLoaiThiNghiem")
            {
                Label id = e.Item.FindControl("lblID_LoaiThiNghiem") as Label;
                if(DAO.clsLoaiThiNghiemDAO.deleteLoaiThiNghiem(Convert.ToInt32(id.Text)))
                {
                    rptLoaiThiNghiemBind();
                }
            }
            if(e.CommandName == "btn_ThemCot")
            {
                Label id = e.Item.FindControl("lblID_LoaiThiNghiem") as Label;
                if(DAO.clsCotThiNghiem_Mapping.themCot(Convert.ToInt32(id.Text)))
                {
                    rptLoaiThiNghiemBind();
                }
            }
        }
        protected void rptCotThiNghiem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "btn_CapNhatCot")
            {
                Label _IDLoaiTN = e.Item.FindControl("lblID_LoaiThiNghiem") as Label;
                Label _Cot = e.Item.FindControl("lblCot") as Label;
                TextBox _TenCot = e.Item.FindControl("txtTenCot") as TextBox;
                int ID = Convert.ToInt32(_IDLoaiTN.Text);
                int Cot = Convert.ToInt32(_Cot.Text);
                string TenCot = _TenCot.Text;
                DAO.clsCotThiNghiem_Mapping.suaTenCot(ID, Cot, TenCot);
            }
            if(e.CommandName == "btn_XoaCot")
            {
                Label _IDLoaiTN = e.Item.FindControl("lblID_LoaiThiNghiem") as Label;
                Label _Cot = e.Item.FindControl("lblCot") as Label;
                int ID = Convert.ToInt32(_IDLoaiTN.Text);
                int Cot = Convert.ToInt32(_Cot.Text);
                if(DAO.clsCotThiNghiem_Mapping.deleteCot(ID, Cot))
                {
                    rptLoaiThiNghiemBind();
                }
            }
        }
        
    }
}