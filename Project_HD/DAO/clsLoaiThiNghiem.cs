using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsLoaiThiNghiemDAO
    {
        public static DataTable getListLoaiThiNghiem()
        {
            string query = "SELECT * FROM LoaiThiNghiem WHERE LTN_TrangThai=1 ORDER BY ID";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query,para);
        }
        public static DataTable getTenThiNghiemByID(int ID)
        {
            string query = "SELECT TenLoai FROM LoaiThiNghiem WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static int insertThiNghiemNewLastID()
        {
            string query = "INSERT INTO LoaiThiNghiem(TenLoai) VALUES(@TenLoai)";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@TenLoai", "");
            return DAO.DataProvider.ExecuteInsertLastID(query, para);
        }
        public static bool deleteLoaiThiNghiem(int ID)
        {
            string query = "UPDATE LoaiThiNghiem SET LTN_TrangThai=0 WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para)==1;
        }
        public static bool updateTenLoaiThiNghiem(int ID,string TenLoai)
        {
            string query = "UPDATE LoaiThiNghiem SET TenLoai=@TenLoai WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@TenLoai", TenLoai);
            para[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) == 1;
        }
    }
}