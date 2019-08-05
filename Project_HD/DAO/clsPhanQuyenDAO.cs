using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Project_HD.DAO
{
    public class clsPhanQuyenDAO
    {
        public static bool createNew(int ID)
        {
            string query = "INSERT INTO NguoiDung(ID) VALUES(@ID)";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID", ID);
            return Convert.ToInt32(DAO.DataProvider.ExecuteInsertQuery(query, paras))==1;
        }
        public DataRow getQuyen(int ID_NguoiDung)
        {
            string query = "SELECT * FROM NguoiDung WHERE ID=@ID_NguoiDung";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras).Rows[0];
        }
        public static bool insertNew(int ID_NguoiDung)
        {
            string query = "INSERT INTO PhanQuyen(ID_NguoiDung,ID_DacTinh) SELECT +" + ID_NguoiDung + ",ID FROM DacTinh WHERE TrangThai=1";
            OleDbParameter[] paras = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteInsertQuery(query, paras)>0;
        }
        public static DataTable getList(int ID_NguoiDung)
        {
            string query = "SELECT * FROM PhanQuyen INNER JOIN DacTinh ON PhanQuyen.ID_DacTinh=DacTinh.ID WHERE ID_NguoiDung=@ID_NguoiDung AND TrangThai=1";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
        public static bool updateQuyen1(int ID_NguoiDung, int TaoThiNghiem, int SuaThiNghiem, int XuatBaoCao, string NhapLieu_DCD, string NhapLieu_DNCN)
        {
            string query = "UPDATE NguoiDung SET TaoThiNghiem=@TaoThiNghiem,SuaThiNghiem=@SuaThiNghiem,XuatBaoCao=@XuatBaoCao,NhapLieu_DCD=@NhapLieu_DCD,NhapLieu_DNCN=@NhapLieu_DNCN WHERE ID=@ID_NguoiDung";
            OleDbParameter[] paras = new OleDbParameter[6];
            paras[0] = new OleDbParameter("@TaoThiNghiem", TaoThiNghiem);
            paras[1] = new OleDbParameter("@SuaThiNghiem", SuaThiNghiem);
            paras[2] = new OleDbParameter("@XuatBaoCao", XuatBaoCao);
            paras[3] = new OleDbParameter("@NhapLieu_DCD", NhapLieu_DCD);
            paras[4] = new OleDbParameter("@NhapLieu_DNCN", NhapLieu_DNCN);
            paras[5] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras)==1;
        }
        public static bool updateQuyen(int ID_NguoiDung,int[] ID_DacTinh,int[] Quyen,int size)
        {
            string query = "UPDATE PhanQuyen SET Quyen=@Quyen WHERE ID_NguoiDung=@ID_NguoiDung AND ID_DacTinh=@ID_DacTinh";
            OleDbParameter[][] para = new OleDbParameter[size][];
            for (int i = 0; i < size; i++)
            {
                para[i] = new OleDbParameter[3];
                para[i][0] = new OleDbParameter("@Quyen", Quyen[i]);
                para[i][1] = new OleDbParameter("@ID_NguoiDung", ID_NguoiDung);
                para[i][2] = new OleDbParameter("@ID_DacTinh", ID_DacTinh[i]);
            }
            return DAO.DataProvider.ExecuteArrayUpdateQuery(query, para) > 0;
        }
        public static bool insertNewDacTinh(int ID_DacTinh)
        {
            string query = "INSERT INTO PhanQuyen(ID_NguoiDung,ID_DacTinh) SELECT ID," + ID_DacTinh + " FROM NguoiDung WHERE TrangThai=1";
            OleDbParameter[] paras = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteInsertQuery(query, paras)>0;
        }
        public static bool deleteDacTinh(int ID_DacTinh)
        {
            string query = "DELETE FROM PhanQuyen WHERE ID_DacTinh=@ID_DacTinh";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_DacTinh", ID_DacTinh);
            return DAO.DataProvider.ExecuteDeleteQuery(query, paras) > 0;
        }
    }
}