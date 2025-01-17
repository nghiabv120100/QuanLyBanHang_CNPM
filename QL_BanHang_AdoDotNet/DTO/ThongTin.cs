﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang_AdoDotNet.DTO
{
    public class ThongTin
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int LoaiTaiKhoan { get; set; }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public int Luong { get; set; }
    }
}
