using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_HD
{
    public partial class quantri : System.Web.UI.Page
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
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
            }
            if (!Page.IsPostBack)
            {
                ddlLoaiThiNghiemBind();
            }
        }

        private void ddlLoaiThiNghiemBind()
        {
            DataTable t = DAO.clsLoaiThiNghiemDAO.getListLoaiThiNghiem();
            DataRow a = t.NewRow();
            a["TenLoai"] = "";
            a["ID"] = 0;
            t.Rows.Add(a);
            ddlLoaiThiNghiem.DataSource = t;
            ddlLoaiThiNghiem.DataTextField = "TenLoai";
            ddlLoaiThiNghiem.DataValueField = "ID";
            ddlLoaiThiNghiem.SelectedValue = "0";
            ddlLoaiThiNghiem.DataBind();
        }

        private void rptPhanQuyenBind()
        {
            rptPhanQuyen.DataSource = DAO.clsDacTinhDAO.getListByID_LoaiThiNghiem(Convert.ToInt32(ddlLoaiThiNghiem.SelectedValue));
            rptPhanQuyen.DataBind();
        }
        protected void ddlLoaiThiNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptPhanQuyenBind();
        }
        protected void rptPhanQuyen_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var ddl = (DropDownList)e.Item.FindControl("ddlNguoiDung");
                //Response.Write(Convert.ToInt32(((Label)e.Item.FindControl("lblID")).Text) - 1);
                ddl.DataSource = DAO.clsNguoiDungDAO.getListNhanVien();//Or any other datasource.
                ddl.DataTextField = "TaiKhoan";
                ddl.DataValueField = "ID";
                ddl.DataBind();
                //var a =Convert.ToInt32(((Label)e.Item.FindControl("lblID")).Text) - 1;
                int x = Convert.ToInt32(((Label)e.Item.FindControl("lblID")).Text);
                ddl.DataMember = x.ToString();
                int id = DAO.clsDacTinhDAO.getID_NguoiDungByID(x);
                int VaiTro = DAO.clsNguoiDungDAO.getVaiTroByID(id);
                if(VaiTro == 1)
                {
                    ddl.SelectedValue = "1";
                }
                else
                {
                    ddl.SelectedValue = id.ToString();
                }
            }
        }

        protected virtual void rptPhanQuyen_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var MyList = (DropDownList)e.Item.FindControl("ddlNguoiDung");
            if(MyList!=null)
                MyList.SelectedIndexChanged += ddlNguoiDung_SelectedIndexChanged;
        }

        private void ddlNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["VaiTro"].ToString() != "1")
            {
                Response.Write("<script>alert(\"Bạn không có quyền truy cập\")</script>");
                Server.Transfer("index.aspx", true);
            }
            else
            {
                DropDownList d = (DropDownList)sender;
                int ID_NguoiDung = Convert.ToInt32(d.SelectedValue);
                int ID = Convert.ToInt32(d.DataMember);
                DAO.clsDacTinhDAO.updateID_ID_NguoiDung(ID, ID_NguoiDung);
            }
        }
    }
}