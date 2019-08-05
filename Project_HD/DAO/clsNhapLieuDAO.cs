using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Project_HD.DAO
{
    public class clsNhapLieuDAO
    {
        public static DataTable selectNhapLieuByIDTN(int ID_ThiNghiem)
        {
            string query = "SELECT* FROM(SELECT * FROM NhapLieu WHERE ID_ThiNghiem= @ID_ThiNghiem) AS DT INNER JOIN DacTinh ON DT.ID_DacTinh = DacTinh.ID ORDER BY DT.ChiSo";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static DataTable selectNhapLieuByIDTN_IDND(int ID_ThiNghiem,int ID_NguoiDung)
        {
            string query = "SELECT * FROM(SELECT * FROM NhapLieu WHERE ID_ThiNghiem= @ID_ThiNghiem) AS DT INNER JOIN (DacTinh INNER JOIN PhanQuyen ON DacTinh.ID=PhanQuyen.ID_DacTinh) ON DT.ID_DacTinh = DacTinh.ID WHERE ID_NguoiDung=@ID_NguoiDung AND TrangThai=1 AND Quyen=1 ORDER BY DT.ChiSo";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            para[1] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public bool insertNhapLieu(int ID_ThiNghiem, int ID_LoaiThiNghiem)
        {
            string query = "INSERT INTO NhapLieu(ID_ThiNghiem,ID_DacTinh,ChiSo) SELECT " + ID_ThiNghiem + ",ID,ChiSo FROM DacTinh WHERE TrangThai=1 AND ID_LoaiThiNghiem=@ID_LoaiThiNghiem";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            return DAO.DataProvider.ExecuteInsertQuery(query, para) > 0;
        }
        public bool insertNhapLieu_DNCN(int ID_ThiNghiem)
        {
            string query = "INSERT INTO NhapLieu_DNCN(ID_ThiNghiem,ID_DacTinh,ChiSo) SELECT " + ID_ThiNghiem + ",ID,ChiSo FROM DacTinh WHERE ID_LoaiThiNghiem=2";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteInsertQuery(query, para) > 0;
        }
        public DataTable selectNhapLieu_DCD(int ID_ThiNghiem)
        {
            string query = "SELECT * FROM (SELECT * FROM NhapLieu_DCD WHERE ID_ThiNghiem=@ID_ThiNghiem) AS DT INNER JOIN DacTinh ON DT.ID_DacTinh=DacTinh.ID ORDER BY DT.ChiSo";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            return t;
        }
        public bool updateNhapLieu_DCD(int ID_ThiNghiem, int ID_DacTinh, string TM, string BCN, string NguoiNhap)
        {
            string query = "UPDATE NhapLieu_DCD SET TM=@TM,BCN=@BCN,NguoiNhap=@NguoiNhap WHERE ID_ThiNghiem=@ID_ThiNghiem AND ID_DacTinh=@ID_DacTinh";
            OleDbParameter[] para = new OleDbParameter[5];
            para[0] = new OleDbParameter("@TM", TM);
            para[1] = new OleDbParameter("@BCN", BCN);
            para[2] = new OleDbParameter("@NguoiNhap", NguoiNhap);
            para[3] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            para[4] = new OleDbParameter("@ID_DacTinh", ID_DacTinh);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) == 1;
        }
        public DataTable selectNhapLieu_DNCN(int ID_ThiNghiem)
        {
            string query = "SELECT * FROM (SELECT * FROM NhapLieu_DNCN WHERE ID_ThiNghiem=@ID_ThiNghiem) AS DT INNER JOIN DacTinh ON DT.ID_DacTinh=DacTinh.ID ORDER BY DT.ChiSo";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            return t;
        }
        public bool updateNhapLieu_DNCN(int ID_ThiNghiem, int ID_DacTinh, string NoiDung, string NguoiNhap)
        {
            string query = "UPDATE NhapLieu_DNCN SET NoiDung=@NoiDung,NguoiNhap=@NguoiNhap WHERE ID_ThiNghiem=@ID_ThiNghiem AND ID_DacTinh=@ID_DacTinh";
            OleDbParameter[] para = new OleDbParameter[4];
            para[0] = new OleDbParameter("@NoiDung", NoiDung);
            para[1] = new OleDbParameter("@NguoiNhap", NguoiNhap);
            para[2] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            para[3] = new OleDbParameter("@ID_DacTinh", ID_DacTinh);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) == 1;
        }
        public static bool updateNhapLieu(int[] ID_ThiNghiem, int[] ID_DacTinh, string[] Cot1, string[] Cot2, string[] Cot3, string[] Cot4, string[] NguoiNhap, int size)
        {
            string query = "UPDATE NhapLieu SET Cot1=@Cot1,Cot2=@Cot2,Cot3=@Cot3,Cot4=@Cot4,NguoiNhap=@NguoiNhap WHERE ID_ThiNghiem=@ID_ThiNghiem AND ID_DacTinh=@ID_DacTinh";
            OleDbParameter[][] para = new OleDbParameter[size][];
            for (int i = 0; i < size; i++)
            {
                para[i] = new OleDbParameter[7];
                para[i][0] = new OleDbParameter("@Cot1", Cot1[i]);
                para[i][1] = new OleDbParameter("@Cot2", Cot2[i]);
                para[i][2] = new OleDbParameter("@Cot3", Cot3[i]);
                para[i][3] = new OleDbParameter("@Cot4", Cot4[i]);
                para[i][4] = new OleDbParameter("@NguoiNhap", NguoiNhap[i]);
                para[i][5] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem[i]);
                para[i][6] = new OleDbParameter("@ID_DacTinh", ID_DacTinh[i]);
            }
            return DAO.DataProvider.ExecuteArrayUpdateQuery(query, para) > 0;
        }
        public static bool updateNhapLieu1(int ID_ThiNghiem, int ID_DacTinh, string Cot1, string Cot2, string Cot3, string Cot4, string NguoiNhap)
        {
            string query = "UPDATE NhapLieu SET Cot1=@Cot1,Cot2=@Cot2,Cot3=@Cot3,Cot4=@Cot4,NguoiNhap=@NguoiNhap WHERE ID_ThiNghiem=@ID_ThiNghiem AND ID_DacTinh=@ID_DacTinh";
            OleDbParameter[] para = new OleDbParameter[7];
            para[0] = new OleDbParameter("@Cot1", Cot1);
            para[1] = new OleDbParameter("@Cot2", Cot2);
            para[2] = new OleDbParameter("@Cot3", Cot3);
            para[3] = new OleDbParameter("@Cot4", Cot4);
            para[4] = new OleDbParameter("@NguoiNhap", NguoiNhap);
            para[5] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            para[6] = new OleDbParameter("@ID_DacTinh", ID_DacTinh);
            return DAO.DataProvider.ExecuteUpdateQuery(query, para) > 0;
        }
    }
}