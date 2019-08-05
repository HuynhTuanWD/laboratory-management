using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsQueryDCDDAO
    {
        public static DataTable getList()
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT * FROM (SELECT ID as ID1,NoiDung as NoiDung1,ID_DacTinh as ID_DacTinh1,ID_LoaiKetQua as ID_LoaiKetQua1,ID_ThiNghiem as ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=2) AS KQ INNER JOIN (SELECT ID as ID2,NoiDung as NoiDung2,ID_DacTinh as ID_DacTinh2,ID_LoaiKetQua AS ID_LoaiKetQua2,ID_ThiNghiem as ID_ThiNghiem2 FROM KetQua WHERE ID_LoaiKetQua=3) as KQ1 ON KQ.ID_DacTinh1=KQ1.ID_DacTinh2) AS KQ2 INNER JOIN DacTinh ON KQ2.ID_DacTinh1=DacTinh.ID) as KQ3 INNER JOIN (SELECT ID,TenHienThi FROM NguoiDung) as ND ON KQ3.ID_NguoiDung=ND.ID;";
            OleDbParameter[] paras = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
        public static DataTable getListByIDThiNghiem(int ID_ThiNghiem)
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT * FROM (SELECT ID as ID1,NoiDung as NoiDung1,ID_DacTinh as ID_DacTinh1,ID_LoaiKetQua as ID_LoaiKetQua1,ID_ThiNghiem as ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=2 AND ID_ThiNghiem=@ID_ThiNghiem) AS KQ INNER JOIN (SELECT ID as ID2,NoiDung as NoiDung2,ID_DacTinh as ID_DacTinh2,ID_LoaiKetQua AS ID_LoaiKetQua2,ID_ThiNghiem as ID_ThiNghiem2 FROM KetQua WHERE ID_LoaiKetQua=3 AND ID_ThiNghiem=@ID_ThiNghiem) as KQ1 ON KQ.ID_DacTinh1=KQ1.ID_DacTinh2) AS KQ2 INNER JOIN DacTinh ON KQ2.ID_DacTinh1=DacTinh.ID) as KQ3 INNER JOIN (SELECT ID,TenHienThi FROM NguoiDung) as ND ON KQ3.ID_NguoiDung=ND.ID ORDER BY ID_DacTinh1;";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
        public static DataTable getListByIDThiNghiem_Session(int ID_ThiNghiem,int ID_NguoiDung)
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT * FROM (SELECT ID as ID1,NoiDung as NoiDung1,ID_DacTinh as ID_DacTinh1,ID_LoaiKetQua as ID_LoaiKetQua1,ID_ThiNghiem as ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=2 AND ID_ThiNghiem=@ID_ThiNghiem) AS KQ INNER JOIN (SELECT ID as ID2,NoiDung as NoiDung2,ID_DacTinh as ID_DacTinh2,ID_LoaiKetQua AS ID_LoaiKetQua2,ID_ThiNghiem as ID_ThiNghiem2 FROM KetQua WHERE ID_LoaiKetQua=3 AND ID_ThiNghiem=@ID_ThiNghiem) as KQ1 ON KQ.ID_DacTinh1=KQ1.ID_DacTinh2) AS KQ2 INNER JOIN DacTinh ON KQ2.ID_DacTinh1=DacTinh.ID) as KQ3 INNER JOIN (SELECT ID,TenHienThi FROM NguoiDung) as ND ON KQ3.ID_NguoiDung=ND.ID WHERE ID_NguoiDung=@ID_NguoiDung ORDER BY ID_DacTinh1;";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            paras[1] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
    }
}