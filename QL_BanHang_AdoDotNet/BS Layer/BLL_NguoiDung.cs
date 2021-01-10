using QL_BanHang_AdoDotNet.DB_Layer;
using QL_BanHang_AdoDotNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang_AdoDotNet.BS_Layer
{
    public class BLL_NguoiDung
    {
        public static List<ThongTin> LayToanBoNguoiDung()
        {
            return Query_DAL.LayToanBoNguoiDung();
        }
    }
}
