using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class clsVaiTroDAO
    {
        public static DataTable getList(){
            string query = "SELECT * FROM VaiTro";
            OleDbParameter[] paras = new OleDbParameter[0];
            return DAO.DataProvider.ExecuteSelectQuery(query, paras);
        }
    }
}