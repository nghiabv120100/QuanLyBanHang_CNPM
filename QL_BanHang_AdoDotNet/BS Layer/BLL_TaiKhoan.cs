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

        public static int InsertTaiKhoan(TaiKhoan tk)
        {
            string sql = "Insert into dbo.TaiKhoan "
                + "Values"
                + $"('{tk.TenTaiKhoan}','{tk.MatKhau}',{tk.LoaiTaiKhoan},'{tk.MaNV}')";
            return Query_DAL.InsertData(sql);
        }
        public static int UpdateTaiKhoan(TaiKhoan tk)
        {
            string sql = "Update dbo.TaiKhoan "
                + $"set MatKhau='{tk.MatKhau}',LoaiTaiKhoan={tk.LoaiTaiKhoan},MaNV='{tk.MaNV}' "
                + $"Where TenDangNhap='{tk.TenTaiKhoan}'";
            return Query_DAL.UpdateData(sql);
        }

        public static int DeleteTaiKhoan(string TenDangNhap)
        {
            string sql = "Delete dbo.TaiKhoan "
                + $"Where TenDangNhap='{TenDangNhap}'";
            return Query_DAL.DeleteData(sql);
        }

    }
}
