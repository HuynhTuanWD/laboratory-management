using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsNguoiDungDAO
    {
        public static DataRow getAccount(string tk,string mk){
            string query = "SELECT * FROM NguoiDung WHERE TaiKhoan=@TaiKhoan AND MatKhau=@MatKhau AND TrangThai=1";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@TaiKhoan", tk);
            para[1] = new OleDbParameter("@MatKhau", mk);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t.Rows.Count > 0)
            {
                return t.Rows[0];
            }
            return null;
        }
        public static DataRow getAccountByID(int ID)
        {
            string query = "SELECT * FROM NguoiDung WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t.Rows.Count > 0)
            {
                return t.Rows[0];
            }
            return null;
        }
        public static DataTable getListNhanVien()
        {
            string query = "SELECT * FROM NguoiDung WHERE VaiTro <> 1 ORDER BY ID";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static DataTable getList()
        {
            string query = "SELECT * FROM NguoiDung WHERE VaiTro <> 3 AND TrangThai=1 ORDER BY ID";
            OleDbParameter[] para = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, para);
        }
        public static int getVaiTroByID(int ID)
        {
            string query = "SELECT VaiTro FROM NguoiDung WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if(t.Rows.Count > 0)
                return Convert.ToInt32(t.Rows[0][0]);
            return 0;
        }
        public static bool isExistedTaiKhoan(string TaiKhoan)
        {
            string query = "SELECT count(*) FROM NguoiDung WHERE TaiKhoan=@TaiKhoan";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@TaiKhoan", TaiKhoan);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, paras);
            return Convert.ToInt32(t.Rows[0][0]) == 1;
        }
        public static bool addNguoiDung(string TaiKhoan,string MatKhau,string TenHienThi,string SDT,int VaiTro)
        {
            string query = "INSERT INTO NguoiDung(TaiKhoan,MatKhau,TenHienThi,SDT,VaiTro) VALUES(@TaiKhoan,@MatKhau,@TenHienThi,@SDT,@VaiTro)";
            OleDbParameter[] paras = new OleDbParameter[5];
            paras[0] = new OleDbParameter("@TaiKhoan", TaiKhoan);
            paras[1] = new OleDbParameter("@MatKhau", MatKhau);
            paras[2] = new OleDbParameter("@TenHienThi", TenHienThi);
            paras[3] = new OleDbParameter("@SDT", SDT);
            paras[4] = new OleDbParameter("@VaiTro", VaiTro);
            return DAO.DataProvider.ExecuteInsertQuery(query, paras) == 1;
        }
        public static bool updateNguoiDung(int ID,int VaiTro)
        {
            string query = "UPDATE NguoiDung SET VaiTro=@VaiTro WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@VaiTro", VaiTro);
            paras[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteInsertQuery(query, paras) == 1;
        }
        public static bool xoaNguoiDung(int ID)
        {
            string query = "UPDATE NguoiDung SET TrangThai=0 WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteDeleteQuery(query, paras) == 1;
        }
        public static bool updateTenHienThi(int ID,string TenHienThi,string SDT)
        {
            string query = "UPDATE NguoiDung SET TenHienThi=@TenHienThi,SDT=@SDT WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[3];
            paras[0] = new OleDbParameter("@TenHienThi", TenHienThi);
            paras[1] = new OleDbParameter("@SDT", SDT);
            paras[2] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteInsertQuery(query, paras) == 1;
        }
        public static bool checkMatKhau(int ID, string MatKhau)
        {
            string query = "SELECT count(*) from NguoiDung WHERE MatKhau=@MatKhau AND ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@MatKhau", MatKhau);
            paras[1] = new OleDbParameter("@ID", ID);
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, paras);
            if(t.Rows.Count>0)
                return Convert.ToInt32(t.Rows[0][0]) == 1;
            return false;
        }
        public static bool changeMatKhau(int ID,string MatKhau)
        {
            string query = "UPDATE NguoiDung SET MatKhau=@MatKhau WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@MatKhau", MatKhau);
            paras[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras)==1;
        }
        public static int getIDByTK(string tk)
        {
            string query = "SELECT TOP 1 ID FROM NguoiDung WHERE TaiKhoan=@TaiKhoan";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@TaiKhoan", tk);
            return Convert.ToInt32(DAO.DataProvider.ExecuteSelectQuery(query, paras).Rows[0][0]);
        }
        public static bool updateQuyen(int ID,int VaiTro,int TaoThiNghiem,int SuaThiNghiem,int XuatBaoCao)
        {
            string query = "UPDATE NguoiDung SET VaiTro=@VaiTro,TaoThiNghiem=@TaoThiNghiem,SuaThiNghiem=@SuaThiNghiem,XuatBaoCao=@XuatBaoCao WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[5];
            paras[0] = new OleDbParameter("@VaiTro", VaiTro);
            paras[1] = new OleDbParameter("@TaoThiNghiem", TaoThiNghiem);
            paras[2] = new OleDbParameter("@SuaThiNghiem", SuaThiNghiem);
            paras[3] = new OleDbParameter("@XuatBaoCao", XuatBaoCao);
            paras[4] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras) == 1;
        }
    }
}