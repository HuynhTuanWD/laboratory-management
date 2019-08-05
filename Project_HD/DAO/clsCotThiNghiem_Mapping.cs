using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Project_HD.DAO
{
    public class clsCotThiNghiem_Mapping
    {
        public DataTable getFullCotThiNghiem()
        {
            string query = "SELECT * FROM Mapping_CotThiNghiem WHERE TrangThai=1 ORDER BY Cot";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query,para);
        }
        public bool insertNew(int ID_LoaiThiNghiem)
        {
            string query = "INSERT INTO Mapping_CotThiNghiem (ID_LoaiThiNghiem, Cot) SELECT "+ ID_LoaiThiNghiem + ", Cot FROM Mapping_Temp";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteInsertQuery(query, para)>0;
        }
        public static bool deleteCot(int ID_LoaiThiNghiem,int Cot)
        {
            string query = "UPDATE Mapping_CotThiNghiem SET TenCot='',TrangThai=0 WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND Cot=@Cot";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            para[1] = new OleDbParameter("@Cot", Cot);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) == 1;
        }
        public static bool themCot(int ID_LoaiThiNghiem)
        {
            string query1 = "SELECT COUNT(*) FROM Mapping_CotThiNghiem WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND TrangThai=1";
            OleDbParameter[] para1 = new OleDbParameter[1];
            para1[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            int soCot = Convert.ToInt32(DAO.DataProvider.ExecuteSelectQuery(query1, para1).Rows[0][0]);
            soCot++;
            if (soCot > 4)
                soCot = 0;
            string query2 = "UPDATE Mapping_CotThiNghiem SET TrangThai=1 WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND Cot=@Cot";
            OleDbParameter[] para2 = new OleDbParameter[2];
            para2[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            para2[1] = new OleDbParameter("@Cot", soCot);
            return DAO.DataProvider.ExecuteUpdateQuery(query2, para2) == 1;
        }
        public static bool suaTenCot(int ID_LoaiThiNghiem, int Cot, string TenCot)
        {
            string query = "UPDATE Mapping_CotThiNghiem SET TenCot=@TenCot WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND Cot=@Cot";
            OleDbParameter[] para = new OleDbParameter[3];
            para[0] = new OleDbParameter("@TenCot", TenCot);
            para[1] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            para[2] = new OleDbParameter("@Cot", Cot);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) == 1;
        }
        public static int countCot(int ID_LoaiThiNghiem)
        {
            string query = "SELECT COUNT(*) FROM Mapping_CotThiNghiem WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND TrangThai=1";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            return Convert.ToInt32(DAO.DataProvider.ExecuteSelectQuery(query, para).Rows[0][0]);
        }
        public static DataTable getCotByIDLoai(int ID_LoaiThiNghiem)
        {
            string query = "SELECT * FROM Mapping_CotThiNghiem WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem AND TrangThai=1 ORDER BY Cot";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
    }
}