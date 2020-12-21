using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang_AdoDotNet.GUI
{
    public partial class ThongTinTaiKhoan : Form
    {
        public string ten = "";
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            this.txtTaiKhoan.Text = ten;
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
