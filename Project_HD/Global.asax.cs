using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Project_HD
{
    public class Global : System.Web.HttpApplication
    {
        public static DataTable DacTinh;
        public static DataView DacTinh_DCD;
        public static DataView DacTinh_DNCN;
        public static int numbMaxRow_ThiNghiem;
        //private void DacTinh_DCD_DNCN_EditView()
        //{
        //    DacTinh_DCD = new DataView(DacTinh);
        //    DacTinh_DCD.RowFilter = "ID_LoaiThiNghiem=1";
        //    DacTinh_DCD.Sort = "ChiSo ASC";
        //    DacTinh_DCD.AllowEdit = true;
        //    foreach (DataRowView item in DacTinh_DCD)
        //    {
        //        item.BeginEdit();
        //        item["PhuongPhap"] = (item["PhuongPhap"].ToString()).Replace("<br/>", " ");
        //        item.EndEdit();
        //    }
        //    DacTinh_DNCN = new DataView(DacTinh);
        //    DacTinh_DNCN.RowFilter = "ID_LoaiThiNghiem=2";
        //    DacTinh_DNCN.Sort = "ChiSo ASC";
        //    DacTinh_DNCN.AllowEdit = true;
        //    foreach (DataRowView item in DacTinh_DNCN)
        //    {
        //        item.BeginEdit();
        //        item["PhuongPhap"] = (item["PhuongPhap"].ToString()).Replace("<br/>", " ");
        //        item.EndEdit();
        //    }
        //}
        protected void Application_Start(object sender, EventArgs e)
        {
            DacTinh = DAO.clsDacTinhDAO.getList();
            //DacTinh_DCD_DNCN_EditView();
            DAO.clsThiNghiemDAO TNDAO = new DAO.clsThiNghiemDAO();
            numbMaxRow_ThiNghiem = TNDAO.getNumbMaxPage();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}