using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsQueryDNCNDAO
    {
        public static DataTable getList()
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT ID AS ID1, NoiDung AS NoiDung1, ID_DacTinh AS ID_DacTinh1, ID_LoaiKetQua AS ID_LoaiKetQua1, ID_ThiNghiem AS ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=1)  AS KQ1 INNER JOIN DacTinh ON KQ1.ID_DacTinh1=DacTinh.ID)  AS KQ2 INNER JOIN (SELECT ID, TenHienThi FROM NguoiDung)  AS ND ON KQ2.ID_NguoiDung=ND.ID;";
            OleDbParameter[] paras = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
        public static DataTable getListByIDThiNghiem(int ID_ThiNghiem)
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT ID AS ID1, NoiDung AS NoiDung1, ID_DacTinh AS ID_DacTinh1, ID_LoaiKetQua AS ID_LoaiKetQua1, ID_ThiNghiem AS ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=1 AND ID_ThiNghiem=@ID_ThiNghiem) AS KQ1 INNER JOIN DacTinh ON KQ1.ID_DacTinh1=DacTinh.ID)  AS KQ2 INNER JOIN (SELECT ID, TenHienThi FROM NguoiDung)  AS ND ON KQ2.ID_NguoiDung=ND.ID ORDER BY ID_DacTinh1;";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
        public static DataTable getListByIDThiNghiem_Session(int ID_ThiNghiem,int ID_NguoiDung)
        {
            string query = "SELECT * FROM (SELECT * FROM (SELECT ID AS ID1, NoiDung AS NoiDung1, ID_DacTinh AS ID_DacTinh1, ID_LoaiKetQua AS ID_LoaiKetQua1, ID_ThiNghiem AS ID_ThiNghiem1 FROM KetQua WHERE ID_LoaiKetQua=1 AND ID_ThiNghiem=@ID_ThiNghiem)  AS KQ1 INNER JOIN DacTinh ON KQ1.ID_DacTinh1=DacTinh.ID)  AS KQ2 INNER JOIN (SELECT ID, TenHienThi FROM NguoiDung)  AS ND ON KQ2.ID_NguoiDung=ND.ID WHERE ID_NguoiDung=@ID_NguoiDung ORDER BY ID_DacTinh1;";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            paras[1] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
    }
}