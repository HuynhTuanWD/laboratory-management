using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Project_HD.DTO
{
    public class clsThiNghiemDTO
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _XuatXu;

        public string XuatXu
        {
            get { return _XuatXu; }
            set { _XuatXu = value; }
        }

        string _SearchXuatXu;

        public string SearchXuatXu
        {
            get { return _SearchXuatXu; }
            set { _SearchXuatXu = value; }
        }

        DateTime _NgayLayMau;

        public DateTime NgayLayMau
        {
            get { return _NgayLayMau; }
            set { _NgayLayMau = value; }
        }
        DateTime _NgayNhanMau;

        public DateTime NgayNhanMau
        {
            get { return _NgayNhanMau; }
            set { _NgayNhanMau = value; }
        }
        DateTime _NgayThuMau;

        public DateTime NgayThuMau
        {
            get { return _NgayThuMau; }
            set { _NgayThuMau = value; }
        }
        string _LyDoThiNghiem;

        public string LyDoThiNghiem
        {
            get { return _LyDoThiNghiem; }
            set { _LyDoThiNghiem = value; }
        }
        string _PhuTrachLayMau;

        public string PhuTrachLayMau
        {
            get { return _PhuTrachLayMau; }
            set { _PhuTrachLayMau = value; }
        }
        string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        int _ID_LoaiThiNghiem;

        public int ID_LoaiThiNghiem
        {
            get { return _ID_LoaiThiNghiem; }
            set { _ID_LoaiThiNghiem = value; }
        }
        int _TrangThai;

        public int TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        DateTime _Created_at;

        public DateTime Created_at
        {
            get { return _Created_at; }
            set { _Created_at = value; }
        }
        DateTime _Updated_at;

        public DateTime Updated_at
        {
            get { return _Updated_at; }
            set { _Updated_at = value; }
        }
        string _Created_by; // người tạo thí nghiệm

        public string Created_by
        {
            get { return _Created_by; }
            set { _Created_by = value; }
        }
        string _Updated_by;

        public string Updated_by
        {
            get { return _Updated_by; }
            set { _Updated_by = value; }
        }
        int _Copy;
        public int Copy {
            get { return _Copy; }
            set { _Copy = value; }
        }

        public DateTime FormatDate(string d)
        {
            DateTime a = Convert.ToDateTime(d);
            string t = "#"+a.ToString("yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture)+"#";
            return Convert.ToDateTime(t);
        }
    }
}