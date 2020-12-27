using QL_BanHang_AdoDotNet.DB_Layer;
using QL_BanHang_AdoDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public static class BLL_TaiKhoan
    {
        public static int findRole(string username)
        {
            string sql = $"select LoaiTaiKhoan from dbo.TaiKhoan " +
               $"Where TenDangNhap=N'{username.Trim()}' ";
            int Quyen=Query_DAL.findRole(sql);
            return Quyen;
        }
        public static bool CheckTaiKhoan(TaiKhoan tk)
        {
            string sql = $"select * from dbo.TaiKhoan " +
                $"Where TenDangNhap=N'{tk.TenTaiKhoan.Trim()}' and MatKhau=N'{tk.MatKhau.Trim()}'";
            return Query_DAL.KiemTraTaiKhoan(sql);
        }
        public static bool CheckError(TaiKhoan tk)
        {
            string sql = $"select * from dbo.TaiKhoan " +
                $"Where TenDangNhap=N'{tk.TenTaiKhoan.Trim()}'";
            return Query_DAL.KiemTraTaiKhoan(sql);
        }
    }
}
