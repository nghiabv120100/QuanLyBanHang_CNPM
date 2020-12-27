using QL_BanHang_AdoDotNet.BS_Layer;
using QL_BanHang_AdoDotNet.DTO;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.TenTaiKhoan = txtTenDangNhap.Text;
            tk.MatKhau = txtMatKhau.Text;
            bool res = BLL_TaiKhoan.CheckTaiKhoan(tk);
            bool err = BLL_TaiKhoan.CheckError(tk);
            if (res)
            {      
                this.Hide();
                frmMain frm = new frmMain();
                Cons.username = tk.TenTaiKhoan;
                frm.Show();
            }
            else
            {
               if(string.IsNullOrEmpty(tk.TenTaiKhoan) || string.IsNullOrEmpty(tk.MatKhau))
                {
                    MessageBox.Show("Chưa nhập kìa bạn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
               else if(err)
                {
                    MessageBox.Show("Sai mật khẩu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
