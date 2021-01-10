using QL_BanHang_AdoDotNet.DB_Layer;
using QL_BanHang_AdoDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public class BLL_NhaCungCap
    {
        public static List<NhaCungCap> LayToanBoNhaCungCap()
        {
            return Query_DAL.LayToanBoNhaCungCap();
        }



        /*public static DataTable FindNhaCungCap(NhaCungCap HH)
        {
            string sql = "SELECT * from dbo.NhaCungCap WHERE 1=1";
            if (HH.MaHang != "")
                sql += " AND MaHang LIKE '%" + HH.MaHang.Trim() + "%'";
            if (HH.TenHang != "")
                sql += " AND TenHang LIKE N'%" + HH.TenHang.Trim() + "%'";
            if (HH.LoaiHang != "")
                sql += " AND LoaiHang LIKE '%" + HH.LoaiHang.Trim() + "%'";
            return Query_DAL.GetDataToTable(sql);
        }*/
        public static int InsertNhaCungCap(NhaCungCap NCC)
        {

            string sql = "Insert into dbo.NhaCungCap(TenNhaCungCap,DiaChi,SoDienThoai,Email) "
                + "Values"
                + $"(N'{NCC.TenNhaCungCap}',N'{NCC.DiaChi}',N'{NCC.SoDienThoai}',N'{NCC.Email}' )";
               
            return Query_DAL.InsertData(sql);
        }
       /* private static bool CheckKeyHH(string MaNhaCungCap)
        {
            List<NhaCungCap> dsHH = LayToanBoNhaCungCap();
            foreach (NhaCungCap hh in dsHH)
            {
                if (hh.MaHang == MaNhaCungCap)
                    return true;
            }
            return false;
        }*/

        /*      MaHang, TenHang, SoLuong,  DonGiaNhap, DonGiaBan,  Anh , 
         GhiChu ,ThoiGianBaoHanh, XuatXu , LoaiHang
      */
        public static int UpdateNhaCungCap(NhaCungCap NCC)
         {
             string sql = $"Update dbo.NhaCungCap " +
                 $"Set TenNhaCungCap=N'{NCC.TenNhaCungCap}',DiaChi=N'{NCC.DiaChi}', " +
                 $"SoDienThoai='{NCC.SoDienThoai}',Email='{NCC.Email}' "+
                 $"Where MaNCC='{NCC.MaNhaCungCap}'";
             
             return Query_DAL.UpdateData(sql);
         }
         public static int DeleteNhaCungCap(int MaNCC)
         {
             string sql = "Delete from dbo.NhaCungCap " +
                 $"Where MaNCC={MaNCC}";
             return Query_DAL.DeleteData(sql);
         }
    }
}
