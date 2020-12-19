using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang_AdoDotNet.DTO
{
    public class HangHoa
    {
        public string MaHangHoa { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGiaNhap { get; set; }
        public float DonGiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
        public int BaoHanh { get; set; }
        public string XuatXu { get; set; }
        public string MaLoaiHang { get; set; }
    }
}
