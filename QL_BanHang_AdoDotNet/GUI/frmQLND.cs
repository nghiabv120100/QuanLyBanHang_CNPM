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
    public partial class frmQLND : Form
    {
        public frmQLND()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            cmbMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtChucVu.Text = "";
            txtLuong.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            mtbDienThoai.Text = "";
            cmbMaNhanVien.Focus(); // Đưa con trỏ tới MaNhanVien
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            cmbMaNhanVien.Text = "NV" + (dgvThongTin.Rows.Count + 1).ToString();
            cmbMaNhanVien.Enabled = false;
            txtTenNhanVien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            this.Close();
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {

            if (chkNam.Checked == true)
            {
                chkNu.Checked = false;
            }
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {

            if (chkNu.Checked == true)
            {
                chkNam.Checked = false;
            }
        }
    }
}
