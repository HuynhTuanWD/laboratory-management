using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsKetQuaDAO
    {
        public static bool addItem(int ID_DacTinh,int ID_LoaiKetQua,int ID_ThiNghiem)
        {
            string query = "INSERT INTO KetQua(ID_DacTinh,ID_LoaiKetQua,ID_ThiNghiem) VALUES(@ID_DacTinh,@ID_LoaiKetQua,@ID_ThiNghiem)";
            OleDbParameter[] paras = new OleDbParameter[3];
            paras[0] = new OleDbParameter("@ID_DacTinh", ID_DacTinh);
            paras[1] = new OleDbParameter("@ID_LoaiKetQua", ID_LoaiKetQua);
            paras[2] = new OleDbParameter("@ID_ThiNghiem", ID_ThiNghiem);
            return DAO.DataProvider.ExecuteInsertQuery(query, paras)==1;
        }
        public static bool updateItem(int ID,string NoiDung)
        {
            string query = "UPDATE KetQua SET NoiDung=@NoiDung WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[2];
            paras[0] = new OleDbParameter("@NoiDung", NoiDung);
            paras[1] = new OleDbParameter("@ID", ID);
            return DAO.DataProvider.ExecuteUpdateQuery(query, paras)==1;
        }
    }
}