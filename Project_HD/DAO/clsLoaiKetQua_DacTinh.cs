using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsLoaiKetQua_DacTinhDAO
    {
        public static DataTable getList(int ID_LoaiThiNghiem)
        {
            string query = "SELECT LKQ.ID AS ID_LoaiKetQua,DacTinh.ID AS ID_DacTinh FROM (SELECT * FROM LoaiKetQua WHERE ID_LoaiThiNghiem=@ID_LoaiThiNghiem) AS LKQ INNER JOIN DacTinh ON LKQ.ID_LoaiThiNghiem=DacTinh.ID_LoaiThiNghiem";
            OleDbParameter[] paras = new OleDbParameter[1];
            paras[0] = new OleDbParameter("@ID_LoaiThiNghiem", ID_LoaiThiNghiem);
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
    }
}