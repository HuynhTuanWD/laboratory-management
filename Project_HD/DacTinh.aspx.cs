using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class DacTinh : System.Web.UI.Page
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
            if(!Page.IsPostBack)
            {
                ddlLoaiThiNghiem.DataSource = DAO.clsLoaiThiNghiemDAO.getListLoaiThiNghiem();
                ddlLoaiThiNghiem.DataTextField = "TenLoai";
                ddlLoaiThiNghiem.DataValueField = "ID";
                ddlLoaiThiNghiem.DataBind();
                rptDacTinhBind();
            }
        }

        private void rptDacTinhBind()
        {
            DataTable t = DAO.clsDacTinhDAO.getListByID_LoaiThiNghiem(Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue));
            rptDacTinh.DataSource = t;
            rptDacTinh.DataBind();
            if (rptDacTinh.Items.Count > 0)
            {
                HyperLink hyperXoa = rptDacTinh.Items[rptDacTinh.Items.Count - 1].FindControl("hyperXoa") as HyperLink;
                hyperXoa.Visible = true;
            }
        }

        protected void ddlLoaiThiNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptDacTinhBind();
        }

        protected void btnThemDacTinh_Click(object sender, EventArgs e)
        {
            int chiso = DAO.clsDacTinhDAO.countDacTinh(Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue))+1;
            if (DAO.clsDacTinhDAO.insertNew(Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue),chiso))
            {
                int ID = DAO.clsDacTinhDAO.lastID(Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue));
                DAO.clsPhanQuyenDAO.insertNewDacTinh(ID);
                rptDacTinhBind();
            }
        }

        protected void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string tendactinh = CKEditorTenDacTinh.Text;
            string tenphuongphap = CKEditorTenPhuongPhap.Text;
            int id = Convert.ToInt32(txtIDDacTinh.Text);
            if (DAO.clsDacTinhDAO.updateDacTinh(id, tendactinh, tenphuongphap))
            {
                rptDacTinhBind();
            }
        }

        protected void rptDacTinh_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName== "btn_Xoa")
            {
                if(DAO.clsDacTinhDAO.deleteDacTinh(Convert.ToInt32(e.CommandArgument)) && DAO.clsPhanQuyenDAO.deleteDacTinh(Convert.ToInt32(e.CommandArgument)))
                {
                    rptDacTinhBind();
                }
            }
        }
    }
}