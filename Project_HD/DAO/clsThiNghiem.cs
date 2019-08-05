using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsThiNghiemDAO
    {
        public DataTable getListDSThiNghiemPaging(int numbItem,int fromRowPrevious)
        {
            string query = "SELECT * FROM (SELECT ThiNghiem.ID AS ID, XuatXu, TenLoai, Created_at, Created_by, Updated_by, ID_LoaiThiNghiem, QuyenSua,Copy,BaoCao FROM ThiNghiem INNER JOIN LoaiThiNghiem ON LoaiThiNghiem.ID=ThiNghiem.ID_LoaiThiNghiem WHERE TrangThai=1 AND LTN_TrangThai=1)  AS sub1 INNER JOIN (SELECT TOP " + numbItem + " sub.ID FROM (SELECT TOP " + fromRowPrevious + " ThiNghiem.ID FROM ThiNghiem WHERE TrangThai=1 ORDER BY ThiNghiem.ID DESC)  AS sub ORDER BY sub.ID)  AS sub2 ON sub1.ID=sub2.ID ORDER BY sub1.ID DESC";
            OleDbParameter[] para = new OleDbParameter[0];
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t != null)
                return t;
            return null;
        }
        public DataTable getListSearchDSThiNghiemByString(string KeyWord)
        {
            string query = "SELECT TOP 100 * FROM (SELECT * FROM (SELECT * FROM ThiNghiem WHERE TrangThai=1 AND SearchXuatXu LIKE '%" + KeyWord + "%') AS TN INNER JOIN LoaiThiNghiem ON LoaiThiNghiem.ID=TN.ID_LoaiThiNghiem ORDER BY TN.ID DESC)";
            OleDbParameter[] para = new OleDbParameter[0];
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t != null)
                return t;
            return null;
        }
        public DataTable getListSearchDSThiNghiemByDate(DateTime a, DateTime b)
        {
            string query = "SELECT TOP 100 * FROM (SELECT * FROM (SELECT * FROM ThiNghiem WHERE TrangThai=1 AND Created_at>=@a AND Created_at<@b) AS TN INNER JOIN LoaiThiNghiem ON LoaiThiNghiem.ID=TN.ID_LoaiThiNghiem ORDER BY TN.ID DESC)";
            OleDbParameter[] para = new OleDbParameter[2];
            para[0] = new OleDbParameter("@a", OleDbType.DBDate);
            para[0].Value = a;
            para[1] = new OleDbParameter("@b", OleDbType.DBDate);
            para[1].Value = b;
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, para);
            if (t != null)
                return t;
            return null;
        }
        public int getNumbMaxPage()
        {
            string query = "SELECT COUNT(*) FROM ThiNghiem WHERE TrangThai=1";
            OleDbParameter[] para = new OleDbParameter[0];
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query,para);
            if (t == null)
                return 1;
            if (Convert.ToInt32(t.Rows[0][0]) == 0)
                return 1;
            return Convert.ToInt32(t.Rows[0][0]);
        }
        public int lastID()
        {
            string query = "SELECT TOP 1 ID FROM ThiNghiem ORDER BY ID DESC";
            OleDbParameter[] paras = new OleDbParameter[0];
            DataTable t = DAO.DataProvider.ExecuteSelectQuery(query, paras);
            if (t.Rows.Count == 0)
                return 0;
            return Convert.ToInt32(t.Rows[0][0]);
        }
        public static bool addThiNghiem(DTO.clsThiNghiemDTO TN)
        {
            string query = "INSERT INTO ThiNghiem(ID,XuatXu,SearchXuatXu,NgayLayMau,NgayNhanMau,NgayThuMau,LyDoThiNghiem,PhuTrachLayMau,GhiChu,ID_LoaiThiNghiem,Created_at,Created_by) VALUES (@ID,@XuatXu,@SearchXuatXu,@NgayLayMau,@NgayNhanMau,@NgayThuMau,@LyDoThiNghiem,@PhuTrachLayMau,@GhiChu,@ID_LoaiThiNghiem,@Created_at,@Created_by)";
            OleDbParameter[] para = new OleDbParameter[12];
            para[0] = new OleDbParameter("@ID", TN.ID);
            para[1] = new OleDbParameter("@XuatXu", TN.XuatXu);
            para[2] = new OleDbParameter("@SearchXuatXu", TN.SearchXuatXu);
            para[3] = new OleDbParameter("@NgayLayMau",OleDbType.DBDate);
            para[3].Value = TN.NgayLayMau;
            para[4] = new OleDbParameter("@NgayNhanMau", OleDbType.DBDate);
            para[4].Value = TN.NgayNhanMau;
            para[5] = new OleDbParameter("@NgayThuMau", OleDbType.DBDate);
            para[5].Value = TN.NgayThuMau;
            para[6] = new OleDbParameter("@LyDoThiNghiem", TN.LyDoThiNghiem);
            para[7] = new OleDbParameter("@PhuTrachLayMau", TN.PhuTrachLayMau);
            para[8] = new OleDbParameter("@GhiChu", TN.GhiChu);
            para[9] = new OleDbParameter("@ID_LoaiThiNghiem", TN.ID_LoaiThiNghiem);
            para[10] = new OleDbParameter("@Created_at", OleDbType.Date);
            para[10].Value = TN.Created_at;
            para[11] = new OleDbParameter("@Created_by", TN.Created_by);
            return DAO.DataProvider.ExecuteInsertQuery(query, para) == 1;
        }
        public DataRow getThiNghiemByID(int ID)
        {
            string query = "SELECT * FROM ThiNghiem WHERE ID=@ID";
            OleDbParameter[] para = new OleDbParameter[1];
            para[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteSelectQuery(query, para).Rows[0];
        }
        public static bool updateThiNghiemByID(DTO.clsThiNghiemDTO TN)
        {
            string query = "UPDATE ThiNghiem SET XuatXu=@XuatXu,SearchXuatXu=@SearchXuatXu,NgayLayMau=@NgayLayMau,NgayNhanMau=@NgayNhanMau,NgayThuMau=@NgayThuMau,LyDoThiNghiem=@LyDoThiNghiem,PhuTrachLayMau=@PhuTrachLayMau,GhiChu=@GhiChu,Updated_at=@Updated_at,Updated_by=@Updated_by,Copy=0 WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[11];
            paras[0] = new OleDbParameter("@XuatXu",TN.XuatXu);
            paras[1] = new OleDbParameter("@SearchXuatXu", TN.SearchXuatXu);
            paras[2] = new OleDbParameter("@NgayLayMau",OleDbType.DBDate);
            paras[2].Value = TN.NgayLayMau;
            paras[3] = new OleDbParameter("@NgayNhanMau", OleDbType.DBDate);
            paras[3].Value = TN.NgayNhanMau;
            paras[4] = new OleDbParameter("@NgayThuMau", OleDbType.DBDate);
            paras[4].Value = TN.NgayThuMau;
            paras[5] = new OleDbParameter("@LyDoThiNghiem",TN.LyDoThiNghiem);
            paras[6] = new OleDbParameter("@PhuTrachLayMau",TN.PhuTrachLayMau);
            paras[7] = new OleDbParameter("@GhiChu", TN.GhiChu);
            paras[8] = new OleDbParameter("@Updated_at",OleDbType.Date);
            paras[8].Value = DateTime.Now;
            paras[9] = new OleDbParameter("@Updated_by", TN.Updated_by);
            paras[10] = new OleDbParameter("@ID",TN.ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras) == 1;
        }
        public static bool updateQuyen(int ID,int QuyenSua)
        {
            string query = "UPDATE ThiNghiem SET QuyenSua=@QuyenSua WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@QuyenSua", QuyenSua);
            paras[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query,paras)==1;
        }
        public static bool updateTrangThai(int ID, int TrangThai)
        {
            string query = "UPDATE ThiNghiem SET TrangThai=@TrangThai WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@TrangThai", TrangThai);
            paras[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras) == 1;
        }
        public static bool insertCopy(int ID,int idCopy,string Created_by)
        {
            string query = "INSERT INTO ThiNghiem(ID,XuatXu,SearchXuatXu,NgayLayMau,NgayNhanMau,NgayThuMau,LyDoThiNghiem,PhuTrachLayMau,GhiChu,ID_LoaiThiNghiem,Created_at,Created_by,Copy) SELECT @ID,XuatXu,SearchXuatXu,NgayLayMau,NgayNhanMau,NgayThuMau,LyDoThiNghiem,PhuTrachLayMau,GhiChu,ID_LoaiThiNghiem,@Created_at,@Created_by,1 FROM ThiNghiem WHERE ID=@idCopy";
            OleDbParameter[] paras = new OleDbParameter[4];
            paras[0] = new OleDbParameter("@ID", ID);
            paras[1] = new OleDbParameter("@Created_at", OleDbType.Date);
            paras[1].Value = DateTime.Now;
            paras[2] = new OleDbParameter("@Created_by", Created_by);
            paras[3] = new OleDbParameter("@idCopy", idCopy);
            return DAO.DataProvider.ExecuteInsertQuery(query, paras) == 1;
        }
        public static bool updateBaoCao(int ID)
        {
            string query = "UPDATE ThiNghiem SET BaoCao=1 WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras)==1;
        }
        //public static bool addThiNghiem(DTO.clsThiNghiem TN)
        //{
        //    string query = "INSERT INTO ThiNghiem(NgayLayMau) VALUES (@NgayLayMau)";
        //    OleDbParameter[] para = new OleDbParameter[1];
        //    para[0] = new OleDbParameter("@NgayLayMau", TN.NgayLayMau);
        //    return DAO.DataProvider.ExecuteInsertQuery(query, para) == 1;
        //}
        //public static bool addThiNghiem(DTO.clsThiNghiem TN)
        //{
        //    string query = "INSERT INTO ThiNghiem(XuatXu,LyDoThiNghiem,PhuTrachLayMau,GhiChu,ID_LoaiThiNghiem,ID_NguoiDung) VALUES (@XuatXu,@LyDoThiNghiem,@PhuTrachLayMau,@GhiChu,@ID_LoaiThiNghiem,@ID_NguoiDung)";
        //    OleDbParameter[] para = new OleDbParameter[6];
        //    para[0] = new OleDbParameter("@XuatXu", TN.XuatXu);
        //    para[1] = new OleDbParameter("@LyDoThiNghiem", TN.LyDoThiNghiem);
        //    para[2] = new OleDbParameter("@PhuTrachLayMau", TN.PhuTrachLayMau);
        //    para[3] = new OleDbParameter("@GhiChu", TN.GhiChu);
        //    para[4] = new OleDbParameter("@ID_LoaiThiNghiem", TN.ID_LoaiThiNghiem);
        //    para[5] = new OleDbParameter("@ID_NguoiDung", TN.ID_NguoiDung);
        //    return DAO.DataProvider.ExecuteInsertQuery(query, para) == 1;
        //}
    }
}