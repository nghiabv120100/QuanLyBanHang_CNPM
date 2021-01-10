using QL_BanHang_AdoDotNet.BS_Layer;
using QL_BanHang_AdoDotNet.DB_Layer;
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
    public partial class frmDMNhaCungCap : Form
    {
        private void KhoaButton()
        {
            if (Cons.Quyen == 0)
            {
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnBoQua.Enabled = false;
            }
        }
        public frmDMNhaCungCap()
        {
            InitializeComponent();
        }
        List<NhaCungCap> dsNCC = new List<NhaCungCap>();
        private void frmDMNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhaCungCap();
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNhaCungCap.Columns[0].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Số điện thoại";
            dgvNhaCungCap.Columns[4].HeaderText = "Email";
            KhoaButton();
        }
        private void HienThiDanhSachNhaCungCap()
        {
            dsNCC = Query_DAL.LayToanBoNhaCungCap();
            dgvNhaCungCap.DataSource = dsNCC;
            txtMaNhaCungCap.Enabled = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNhaCungCap.Enabled = false;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaNhaCungCap.Enabled = false;
            txtTenNhaCungCap.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaCungCap NCC = new NhaCungCap();
          
            NCC.TenNhaCungCap = txtTenNhaCungCap.Text;
            NCC.DiaChi = txtDiaChi.Text;
            NCC.SoDienThoai = txtSoDienThoai.Text;
            NCC.Email = txtEmail.Text;
            int res = BLL_NhaCungCap.InsertNhaCungCap(NCC);
            if (res > 0)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công thành công");
                HienThiDanhSachNhaCungCap();
                ResetValues();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaCungCap NCC = new NhaCungCap();
            NCC.MaNhaCungCap = int.Parse(txtMaNhaCungCap.Text);
            NCC.TenNhaCungCap = txtTenNhaCungCap.Text;
            NCC.DiaChi = txtDiaChi.Text;
            NCC.SoDienThoai = txtSoDienThoai.Text;
            NCC.Email = txtEmail.Text;
            int res = BLL_NhaCungCap.UpdateNhaCungCap(NCC);
            if (res > 0)
            {
                MessageBox.Show("Sửa loại hàng thành công");
                HienThiDanhSachNhaCungCap();
            }
            else
            {
                MessageBox.Show("Sửa loại hàng thất bại");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            int res = BLL_NhaCungCap.DeleteNhaCungCap(int.Parse(txtMaNhaCungCap.Text.Trim()));
            if (res > 0)
            {
                HienThiDanhSachNhaCungCap();
                ResetValues();
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.Rows.Count < 1)
                return;
            if (btnThem.Enabled == false && Cons.Quyen == 1)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhaCungCap.Focus();
                return;
            }
            if (dgvNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Hiển thị thông tin lên bảng thông tin chi tiết
            int indexRow = dgvNhaCungCap.SelectedRows[0].Index;
            txtMaNhaCungCap.Text = dgvNhaCungCap[0, indexRow].Value.ToString();
            txtTenNhaCungCap.Text = dgvNhaCungCap[1, indexRow].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap[2, indexRow].Value.ToString();
            txtSoDienThoai.Text = dgvNhaCungCap[3, indexRow].Value.ToString();
            txtEmail.Text = dgvNhaCungCap[4, indexRow].Value.ToString();
           
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            KhoaButton();
        }

        
    }
}
