using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_BanHang_AdoDotNet.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QL_BanHang_AdoDotNet.DB_Layer;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public class BLL_HangHoa
    {
        public static List<HangHoa> LayToanBoHangHoa()
        {
            return Query_DAL.LayToanBoHangHoa();
        }

        public static DataTable LayToanBoHangHoaHienThi()
        {
            string sql = "Select HangHoa.*,TenLoaiHang,TenNhaCungCap from dbo.HangHoa,LoaiHang,NhaCungCap where HangHoa.LoaiHang = LoaiHang.MaLoaiHang and HangHoa.MaNCC=NhaCungCap.MaNCC";
            return Query_DAL.GetDataToTable(sql);
        }
        public static DataTable TimKiemHangHoa(string para)
        {
            string sql = "Select HangHoa.*,TenLoaiHang,TenNhaCungCap from dbo.HangHoa,LoaiHang,NhaCungCap where HangHoa.LoaiHang = LoaiHang.MaLoaiHang and HangHoa.MaNCC=NhaCungCap.MaNCC "
                         + "and (TenLoaiHang LIKE '%" + para.Trim() + "%' or TenNhaCungCap LIKE '%" + para.Trim() + "%' or TenHang LIKE '%" + para.Trim() + "%' )";
           
            return Query_DAL.GetDataToTable(sql);
        }

        public static DataTable FindHangHoa(HangHoa HH)
        {
            string sql = "Select HangHoa.*,TenLoaiHang,TenNhaCungCap from dbo.HangHoa,LoaiHang,NhaCungCap where HangHoa.LoaiHang = LoaiHang.MaLoaiHang and HangHoa.MaNCC=NhaCungCap.MaNCC";
            if (HH.MaHang != "")
                sql += " AND MaHang LIKE '%" + HH.MaHang.Trim() + "%'";
            if (HH.TenHang != "")
                sql += " AND TenHang LIKE N'%" + HH.TenHang.Trim() + "%'";
            if (HH.LoaiHang != "")
                sql += " AND LoaiHang LIKE '%" + HH.LoaiHang.Trim() + "%'";
            if (HH.MaNCC != -1)
                sql += " AND HangHoa.MaNCC=" +HH.MaNCC;
            return Query_DAL.GetDataToTable(sql);
        }
        public static int InsertHangHoa(HangHoa HH)
        {
            if (CheckKeyHH(HH.MaHang.Trim()))
                return 0;
                

            string sql = "Insert into dbo.HangHoa(MaHang, TenHang, SoLuong,  DonGiaNhap, DonGiaBan,  Anh , "
                + "GhiChu ,ThoiGianBaoHanh, XuatXu , LoaiHang, MaNCC )"
                + "Values"
                + $"('{HH.MaHang}',N'{HH.TenHang}',{HH.SoLuong},"
                + $"'{HH.DonGiaNhap}','{HH.DonGiaBan}',N'{HH.Anh}',N'{HH.GhiChu }',{HH.ThoiGianBaoHanh},N'{HH.XuatXu}','{HH.LoaiHang}',{HH.MaNCC})";
            return Query_DAL.InsertData(sql);
        }
        private static bool CheckKeyHH(string MaHangHoa)
        {
            List<HangHoa> dsHH = LayToanBoHangHoa();
            foreach (HangHoa hh in dsHH)
            {
                if (hh.MaHang == MaHangHoa)
                    return true;
            }
            return false;
        }
        /*
  MaHang, TenHang, SoLuong,  DonGiaNhap, DonGiaBan,  Anh , 
  GhiChu ,ThoiGianBaoHanh, XuatXu , LoaiHang 
         */
        public static int UpdateHangHoa(HangHoa HH)
        {
            string sql = $"Update dbo.HangHoa " +
                $"Set TenHang=N'{HH.TenHang}',SoLuong={HH.SoLuong}," +
                $"DonGiaNhap='{HH.DonGiaNhap}',DonGiaBan='{HH.DonGiaBan}',Anh=N'{HH.Anh}',GhiChu='{HH.GhiChu}'," +
                $"ThoiGianBaoHanh={HH.ThoiGianBaoHanh},XuatXu=N'{HH.XuatXu}',LoaiHang='{HH.LoaiHang}' " +
                $"Where MaHang='{HH.MaHang.Trim()}'";
            return Query_DAL.UpdateData(sql);
        }
        public static int DeleteHangHoa(string MaHH)
        {
            string sql = "Delete from dbo.HangHoa " +
                $"Where MaHang='{MaHH}'";
            return Query_DAL.DeleteData(sql);
        }
    }
}

