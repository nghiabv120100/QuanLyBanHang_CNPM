using QL_BanHang_AdoDotNet.DB_Layer;
using QL_BanHang_AdoDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public class BLL_NhaCungCap
    {
        public static List<NhaCungCap> LayToanBoNhaCungCap()
        {
            return Query_DAL.LayToanBoNhaCungCap();
        }



        /* public static DataTable FindNhaCungCap(NhaCungCap HH)
         {
             string sql = "SELECT * from dbo.NhaCungCap WHERE 1=1";
             if (HH.MaHang != "")
                 sql += " AND MaHang LIKE '%" + HH.MaHang.Trim() + "%'";
             if (HH.TenHang != "")
                 sql += " AND TenHang LIKE N'%" + HH.TenHang.Trim() + "%'";
             if (HH.LoaiHang != "")
                 sql += " AND LoaiHang LIKE '%" + HH.LoaiHang.Trim() + "%'";
             return Query_DAL.GetDataToTable(sql);
         }
         public static int InsertNhaCungCap(NhaCungCap HH)
         {
             if (CheckKeyHH(HH.MaHang.Trim()))
                 return 0;


             string sql = "Insert into dbo.NhaCungCap(MaHang, TenHang, SoLuong,  DonGiaNhap, DonGiaBan,  Anh , "
                 + "GhiChu ,ThoiGianBaoHanh, XuatXu , LoaiHang )"
                 + "Values"
                 + $"('{HH.MaHang}',N'{HH.TenHang}',{HH.SoLuong},"
                 + $"'{HH.DonGiaNhap}','{HH.DonGiaBan}',N'{HH.Anh}',N'{HH.GhiChu }',{HH.ThoiGianBaoHanh},N'{HH.XuatXu}','{HH.LoaiHang}')";
             return Query_DAL.InsertData(sql);
         }
         private static bool CheckKeyHH(string MaNhaCungCap)
         {
             List<NhaCungCap> dsHH = LayToanBoNhaCungCap();
             foreach (NhaCungCap hh in dsHH)
             {
                 if (hh.MaHang == MaNhaCungCap)
                     return true;
             }
             return false;
         }
         *//*
   MaHang, TenHang, SoLuong,  DonGiaNhap, DonGiaBan,  Anh , 
   GhiChu ,ThoiGianBaoHanh, XuatXu , LoaiHang 
          *//*
         public static int UpdateNhaCungCap(NhaCungCap HH)
         {
             string sql = $"Update dbo.NhaCungCap " +
                 $"Set TenHang=N'{HH.TenHang}',SoLuong={HH.SoLuong}," +
                 $"DonGiaNhap='{HH.DonGiaNhap}',DonGiaBan='{HH.DonGiaBan}',Anh=N'{HH.Anh}',GhiChu='{HH.GhiChu}'," +
                 $"ThoiGianBaoHanh={HH.ThoiGianBaoHanh},XuatXu=N'{HH.XuatXu}',LoaiHang='{HH.LoaiHang}' " +
                 $"Where MaHang='{HH.MaHang.Trim()}'";
             return Query_DAL.UpdateData(sql);
         }
         public static int DeleteNhaCungCap(string MaHH)
         {
             string sql = "Delete from dbo.NhaCungCap " +
                 $"Where MaHang='{MaHH}'";
             return Query_DAL.DeleteData(sql);
         }*/
    }
}
