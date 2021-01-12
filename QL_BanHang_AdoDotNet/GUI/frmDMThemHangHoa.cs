using QL_BanHang_AdoDotNet.BS_Layer;
using QL_BanHang_AdoDotNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang_AdoDotNet.GUI
{
    public partial class frmDMThemHangHoa : Form
    {
        public frmDMThemHangHoa()
        {
            InitializeComponent();
        }
        DataTable dsHHHienThi;
        List<HangHoa> dsHH = new List<HangHoa>();
        List<LoaiHang> dsLH = new List<LoaiHang>();
        List<NhaCungCap> dsNCC = new List<NhaCungCap>();
        private void KhoaButton()
        {        
            btnTimKiem.Enabled = false;
            btnHienThiDS.Enabled = false;
        }
        private void frmDMThemHangHoa_Load(object sender, EventArgs e)
        {
            txtMaHang.Enabled = false;
            HienThiDanhSachHangHoa();
            HienThiDanhSachLoaiHang();
            dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng hoá";
            dgvHangHoa.Columns[2].HeaderText = "Số lượng";
            dgvHangHoa.Columns[3].HeaderText = "Đơn giá nhập";
            dgvHangHoa.Columns[4].HeaderText = "Đơn giá bán";
            dgvHangHoa.Columns[5].HeaderText = "Ảnh";
            dgvHangHoa.Columns[6].HeaderText = "Ghi chú";
            dgvHangHoa.Columns[7].HeaderText = "Bảo hành";
            dgvHangHoa.Columns[8].HeaderText = "Xuất xứ";
            dgvHangHoa.Columns[9].HeaderText = "Loại hàng";
            dgvHangHoa.Columns[5].Visible = false;
            dgvHangHoa.Columns[9].Visible = false;
            dgvHangHoa.Columns[10].Visible = false;
        }
        private void HienThiDanhSachHangHoa()
        {
            dsHH = BLL_HangHoa.LayToanBoHangHoa();
            dsHHHienThi = BLL_HangHoa.LayToanBoHangHoaHienThi();
            dgvHangHoa.DataSource = dsHHHienThi;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void HienThiDanhSachLoaiHang()
        {
            dsLH = BLL_LoaiHang.LayToanBoLoaiHang();
            dsNCC = BLL_NhaCungCap.LayToanBoNhaCungCap();

            cmbMaLoaiHang.DataSource = dsLH;
            cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
            cmbMaLoaiHang.ValueMember = "MaLoaiHang";
            cmbMaLoaiHang.SelectedIndex = -1;

            cmbNhaCungCap.DataSource = dsNCC;
            cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cmbNhaCungCap.ValueMember = "MaNhaCungCap";
            cmbNhaCungCap.SelectedIndex = -1;
        }
        
        private void ResetValues()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            cmbMaLoaiHang.SelectedIndex = -1;
            txtSoluong.Text = "";
            txtDongianhap.Text = "";
            txtDongiaban.Text = "";
            txtXuatXu.Text = "";
            txtPath.Text = "";
            txtGhichu.Text = "";
            txtThoiGianBaoHanh.Text = "";
            txtTimKiem.Text = "";
            cmbNhaCungCap.SelectedIndex = -1;
            btnTimKiem.Enabled = true;
        }

       
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            this.Close();
        }

        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.Rows.Count < 1)
                return;

            if (dgvHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnTimKiem.Enabled = false;
            // Hiển thị thông tin lên bảng thông tin chi tiết
            int indexRow = dgvHangHoa.SelectedRows[0].Index;
            txtMaHang.Text = dgvHangHoa[0, indexRow].Value.ToString();
            txtTenHang.Text = dgvHangHoa[1, indexRow].Value.ToString();
            txtSoluong.Text = dgvHangHoa[2, indexRow].Value.ToString();
            txtDongianhap.Text = dgvHangHoa[3, indexRow].Value.ToString();
            txtDongiaban.Text = dgvHangHoa[4, indexRow].Value.ToString();
            txtPath.Text = dgvHangHoa[5, indexRow].Value.ToString();
            txtGhichu.Text = dgvHangHoa[6, indexRow].Value.ToString();
            txtThoiGianBaoHanh.Text = dgvHangHoa[7, indexRow].Value.ToString();
            txtXuatXu.Text = dgvHangHoa[8, indexRow].Value.ToString();
            cmbMaLoaiHang.Text = dgvHangHoa[11, indexRow].Value.ToString();
            cmbNhaCungCap.Text = dgvHangHoa[12, indexRow].Value.ToString();
            try
            {
                picAnh.Image = new Bitmap(Application.StartupPath + "\\Resources\\" + txtPath.Text);
            }
            catch
            {

            }

            if (Cons.Quyen == 0)
            {
                KhoaButton();
            }
        }

        

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHangHoa();
            ResetValues();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtTimKiem.Text.Trim() == "")
            {
    
                if ((txtMaHang.Text == "") && (txtTenHang.Text == "") && (cmbMaLoaiHang.Text == "") && (cmbNhaCungCap.Text == ""))
                {
                    MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                HangHoa HH = new HangHoa();
                HH.MaHang = txtMaHang.Text;
                HH.TenHang = txtTenHang.Text;

                if (cmbMaLoaiHang.SelectedValue != null)
                {
                    HH.LoaiHang = cmbMaLoaiHang.SelectedValue.ToString().Trim();
                }
                else
                {
                    HH.LoaiHang = "";
                }
                if (cmbNhaCungCap.SelectedValue != null)
                {
                    MessageBox.Show(cmbNhaCungCap.SelectedValue.ToString().Trim());
                    HH.MaNCC = int.Parse(cmbNhaCungCap.SelectedValue.ToString().Trim());
                }
                else
                {
                    HH.MaNCC = -1;
                }


                DataTable tblH = BLL_HangHoa.FindHangHoa(HH);
                if (tblH.Rows.Count == 0)
                    MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHangHoa.DataSource = tblH;
                ResetValues();
            }
            else
            {
                string para = txtTimKiem.Text;
                DataTable tblH= BLL_HangHoa.TimKiemHangHoa(para);
                if (tblH.Rows.Count == 0)
                    MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHangHoa.DataSource = tblH;
                ResetValues();


            }    
            
        }

        private void cboMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDongiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtThoiGianBaoHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text=="" || txtMaHang.Text==null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng");
                return;
            }
            else
            {
                Cons.flag = true;
                Cons.maHangHoa = txtMaHang.Text;
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
