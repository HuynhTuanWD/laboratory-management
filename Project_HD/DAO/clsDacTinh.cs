using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Project_HD.DAO
{
    public class clsDacTinhDAO
    {
        public static DataTable getList()
        {
            string query = "SELECT * FROM DacTinh WHERE TrangThai=1";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static DataTable getListByID_LoaiThiNghiem(int ID_LoaiThiNghiem)
        {
            string query = "SELECT * FROM DacTinh WHERE TrangThai=1 AND ID_LoaiThiNghiem=@ID_LoaiThiNghiem ORDER BY ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem",ID_LoaiThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static int getID_NguoiDungByID(int ID)
        {
            string query = "SELECT ID_NguoiDung FROM DacTinh WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            return Convert.ToInt32(DAO.DataProvider.ExecuteSelectQuery(query,para).Rows[0][0]);
        }
        public static bool updateID_ID_NguoiDung(int ID,int ID_NguoiDung)
        {
            string query = "UPDATE DacTinh SET ID_NguoiDung=@ID_NguoiDung WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            para[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para)==1;
        }
        public static bool insertNew(int ID_LoaiThiNghiem,int ChiSo)
        {
            string query = "INSERT INTO DacTinh(ID_LoaiThiNghiem,ChiSo) VALUES (@ID_LoaiThiNghiem,@ChiSo)";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            para[1] = new OleDbParameter("@ChiSo", ChiSo);
            return DAO.DataProvider.ExecuteInsertQuery(query, para)==1;
        }
        public static bool updateDacTinh(int ID,string Ten,string PhuongPhap)
        {
            string query = "UPDATE DacTinh SET Ten=@Ten,PhuongPhap=@PhuongPhap WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[3];
            para[0] = new OleDbParameter("@Ten", Ten);
            para[1] = new OleDbParameter("@PhuongPhap", PhuongPhap);
            para[2] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para)==1;
        }
        public static bool deleteDacTinh(int ID)
        {
            string query = "UPDATE DacTinh SET TrangThai=0 WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para)==1;
        }
        public static int countDacTinh(int ID_LoaiThiNghiem)
        {
            string query = "SELECT COUNT(*) FROM DacTinh WHERE TrangThai=1 AND ID_LoaiThiNghiem=@ID_LoaiThiNghiem";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t == null)
                return 0;
            return Convert.ToInt32(t.Rows[0][0]);
        }
        public static int lastID(int ID_LoaiThiNghiem)
        {
            string query = "SELECT ID FROM DacTinh WHERE TrangThai=1 AND ID_LoaiThiNghiem=@ID_LoaiThiNghiem ORDER BY ID DESC";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t == null)
                return 0;
            return Convert.ToInt32(t.Rows[0][0]);
        }
    }
}