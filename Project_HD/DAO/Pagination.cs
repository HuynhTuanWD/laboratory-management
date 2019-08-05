using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project_HD.DAO
{
    public class Pagination
    {
        private DataTable TableCurrentPage;
        private static int numbMaxPage;

        public int NumbMaxPage
        {
            get { return numbMaxPage; }
        }
        private static int numbItem = 1;
        private static int numbCurrentPage = 1;

        public int NumbCurrentPage
        {
            get { return numbCurrentPage; }
        }
        private void BindNumbMaxPage(DataTable YourFullTable)
        {
            int maxRow = YourFullTable.Rows.Count; //0
            int temp = maxRow % numbItem;
            numbMaxPage = (temp > 0 ? (maxRow / numbItem + 1) : (maxRow / numbItem));
            if (maxRow == 0)
                numbMaxPage = 1;
        }
        private void BindToCurrentPage(DataTable YourFullTable)
        {
            if (numbCurrentPage < 1)
                numbCurrentPage = 1;
            if (numbCurrentPage > numbMaxPage)
                numbCurrentPage = numbMaxPage;
            int start = (numbCurrentPage - 1) * numbItem;
            int end = start + numbItem;
            if (numbCurrentPage == numbMaxPage && numbMaxPage > 1 && YourFullTable.Rows.Count % numbItem!=0)
                end = start + YourFullTable.Rows.Count % numbItem;
            if (numbMaxPage == 1)
                end = YourFullTable.Rows.Count;
            TableCurrentPage = new DataTable();
            TableCurrentPage = YourFullTable.Clone();
            for (int i = start; i < end; i++)
            {
                TableCurrentPage.Rows.Add(YourFullTable.Rows[i].ItemArray);
            }
        }
        public DataTable PaginationTableNew(DataTable YourTable,int numbItemPerPage)
        {
            numbItem = numbItemPerPage;
            BindNumbMaxPage(YourTable);
            BindToCurrentPage(YourTable);
            return TableCurrentPage;
        }
        public DataTable PaginationTable(DataTable YourTable,int NextOrPrevious) // -1 0 1
        {
            numbCurrentPage += NextOrPrevious;
            BindToCurrentPage(YourTable);
            return TableCurrentPage;
        }
    }
}