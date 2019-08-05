using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace Project_HD
{
    public partial class NhapLieu_DCD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Server.Transfer("Login.aspx", true);
                return;
            }
            if(!Page.IsPostBack)
            {
                rptThiNghiemBind();
            }
        }

        private void rptThiNghiemBind()
        {
            lblIDThiNghiem.Text = Request.QueryString["ID"];
            lblSoCot.Text = countCol().ToString();
            int ID = Convert.ToInt32(lblIDThiNghiem.Text);
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow rowThiNghiem = TNDAO.getThiNghiemByID(ID);
            lblID_ThiNghiem.Text = ID.ToString();
            lblTenThiNghiem.Text = DAO.clsLoaiThiNghiemDAO.getTenThiNghiemByID(Convert.ToInt32(rowThiNghiem["ID_LoaiThiNghiem"])).Rows[0][0].ToString();
            lblXuatXu.Text = rowThiNghiem["XuatXu"].ToString();
            int ID_LoaiThiNghiem = Convert.ToInt32(rowThiNghiem["ID_LoaiThiNghiem"]);
            rptCot.DataSource = DAO.clsCotThiNghiem_Mapping.getCotByIDLoai(ID_LoaiThiNghiem);
            rptCot.DataBind();
            if (Session["VaiTro"].ToString() == "1")
                rptThiNghiem.DataSource = DAO.clsNhapLieuDAO.selectNhapLieuByIDTN(ID);
            else
                rptThiNghiem.DataSource = DAO.clsNhapLieuDAO.selectNhapLieuByIDTN_IDND(ID, Convert.ToInt32(Session["ID"]));
            rptThiNghiem.DataBind();
            if(rptThiNghiem.Items.Count == 0)
            {
                lblPhanCong.Visible = true;
                btnCapNhat.Visible = false;
            }

        }
        public int countCol()
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            DataRow rowThiNghiem = TNDAO.getThiNghiemByID(ID);
            int ID_LoaiThiNghiem = Convert.ToInt32(rowThiNghiem["ID_LoaiThiNghiem"]);
            return DAO.clsCotThiNghiem_Mapping.countCot(ID_LoaiThiNghiem);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            int size = rptThiNghiem.Items.Count;
            int[] ID_ThiNghiem = new int[size];
            int[] ID_DacTinh = new int[size];
            string[] Cot1 = new string[size];
            string[] Cot2 = new string[size];
            string[] Cot3 = new string[size];
            string[] Cot4 = new string[size];
            string[] NguoiNhap = new string[size];
            string TenHienThi = Session["TenHienThi"].ToString();
            int id_thinghiem = Convert.ToInt32(lblIDThiNghiem.Text);
            for(int i=0;i<size;i++)
            {
                Label id_dactinh = rptThiNghiem.Items[i].FindControl("lblID_DacTinh") as Label;
                TextBox cot1 = rptThiNghiem.Items[i].FindControl("txtCot1") as TextBox;
                TextBox cot2 = rptThiNghiem.Items[i].FindControl("txtCot2") as TextBox;
                TextBox cot3 = rptThiNghiem.Items[i].FindControl("txtCot3") as TextBox;
                TextBox cot4 = rptThiNghiem.Items[i].FindControl("txtCot4") as TextBox;
                ID_ThiNghiem[i] = id_thinghiem;
                ID_DacTinh[i] = Convert.ToInt32(id_dactinh.Text);
                Cot1[i] = cot1.Text;
                Cot2[i] = cot2.Text;
                Cot3[i] = cot3.Text;
                Cot4[i] = cot4.Text;
                NguoiNhap[i] = TenHienThi;
            }
            if (DAO.clsNhapLieuDAO.updateNhapLieu(ID_ThiNghiem, ID_DacTinh, Cot1, Cot2, Cot3, Cot4, NguoiNhap, size))
            {

            }
        }
    }
}