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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa frm = new frmDMHangHoa();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frm = new frmDMKhachHang();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            frmDMNhanVien frm = new frmDMNhanVien();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {

            frmDMLoaiHang frm = new frmDMLoaiHang();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDonBanHang frm = new frmHoaDonBanHang();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            frmBieuDo frm = new frmBieuDo();
            frm.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            Cons.Quyen = BLL_TaiKhoan.findRole(Cons.username);
            nv = BLL_NhanVien.findEmployeeByUsername(Cons.username);
            lblTenNhanVien.Text = nv.TenNhanVien;
            lblChucVu.Text = nv.ChucVu;
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            Application.Exit();
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            frmDMNhaCungCap frm = new frmDMNhaCungCap();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
