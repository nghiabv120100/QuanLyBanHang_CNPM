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
    public partial class frmQLND : Form
    {
        List<ThongTin> dsThongTin;
        List<NhanVien> dsNhanVien;
        public frmQLND()
        {
            InitializeComponent();
        }
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
        private void frmQLND_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            txtTenDangNhap.Enabled = false;
            //Cấu hình datagribview
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            HienThiDanhSachNguoiDung();
            dgvNguoiDung.Columns[0].HeaderText = "Tên Đăng nhập";
            dgvNguoiDung.Columns[1].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns[2].HeaderText = "Loại Tài Khoản";
            dgvNguoiDung.Columns[3].HeaderText = "Mã Nhân Viên";
            dgvNguoiDung.Columns[4].HeaderText = "Tên Nhân Viên";
            dgvNguoiDung.Columns[5].HeaderText = "Địa Chỉ";
            dgvNguoiDung.Columns[6].HeaderText = "Điện Thoại";
            dgvNguoiDung.Columns[7].HeaderText = "Giới Tính";
            dgvNguoiDung.Columns[8].HeaderText = "Ngày Sinh";
            dgvNguoiDung.Columns[9].HeaderText = "Chức Vụ";
            dgvNguoiDung.Columns[10].HeaderText = "Lương";

            this.dgvNguoiDung.Columns[1].Visible = false;
            this.dgvNguoiDung.Columns[2].Visible = false;
            this.dgvNguoiDung.Columns[3].Visible = false;
            this.dgvNguoiDung.Columns[5].Visible = false;
     
            this.dgvNguoiDung.Columns[8].Visible = false;
            this.dgvNguoiDung.Columns[10].Visible = false;

            txtChucVu.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            mtbDienThoai.Enabled = false;
            txtLuong.Enabled = false;
            dtpNgaySinh.Enabled = false;
            chkNam.Enabled = false;
            chkNu.Enabled = false;


        
            //Nhân viên không thể thao tác
            KhoaButton();
        }
        private void HienThiDanhSachNguoiDung()
        {
            dsThongTin = new List<ThongTin>();
            dsNhanVien = new List<NhanVien>();

            dsNhanVien = BLL_NhanVien.LayToanBoNhanVien();
            

            
            dsThongTin = BLL_NguoiDung.LayToanBoNguoiDung();
            cmbMaNV.Items.Clear();
            cmbQuyen.Items.Clear();
            foreach (NhanVien tt in dsNhanVien)
            {
                cmbMaNV.Items.Add(tt.MaNhanVien.Trim());
            }
            cmbQuyen.Items.Add("admin");
            cmbQuyen.Items.Add("employee");
            dgvNguoiDung.DataSource = dsThongTin;  
        }
        private void ResetValues()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtXacNhanMK.Text = "";
            cmbQuyen.Text = "";
            txtChucVu.Text = "";
            txtTenNhanVien.Text = "";
            cmbMaNV.Text = "";
            txtDiaChi.Text = "";
            mtbDienThoai.Text = "";
            txtLuong.Text = "";
            /*dtpNgaySinh.Value = DateTime.Now();*/
            txtTenDangNhap.Focus(); // Đưa con trỏ tới MaNguoiDung
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtTenDangNhap.Enabled = true;
            cmbQuyen.SelectedIndex = 1;
            txtTenDangNhap.Focus();

        }

        private void dgvNguoiDung_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.Rows.Count < 1)
                return;
            if (btnThem.Enabled == false && Cons.Quyen == 1)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDangNhap.Focus();
                return;
            }
            if (dgvNguoiDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            dgvNguoiDung.Columns[0].HeaderText = "Tên Đăng nhập";
            dgvNguoiDung.Columns[1].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns[2].HeaderText = "Loại Tài Khoản";
            dgvNguoiDung.Columns[3].HeaderText = "Mã Nhân Viên";
            dgvNguoiDung.Columns[4].HeaderText = "Tên Nhân Viên";
            dgvNguoiDung.Columns[5].HeaderText = "Địa Chỉ";
            dgvNguoiDung.Columns[6].HeaderText = "Điện Thoại";
            dgvNguoiDung.Columns[7].HeaderText = "Giới Tính";
            dgvNguoiDung.Columns[8].HeaderText = "Ngày Sinh";
            dgvNguoiDung.Columns[9].HeaderText = "Chức Vụ";
            dgvNguoiDung.Columns[10].HeaderText = "Lương";


            // Hiển thị thông tin lên bảng thông tin chi tiết
            int indexRow = dgvNguoiDung.SelectedRows[0].Index;
            txtTenDangNhap.Text = dgvNguoiDung[0, indexRow].Value.ToString();
            txtMatKhau.Text = dgvNguoiDung[1, indexRow].Value.ToString();
            txtXacNhanMK.Text = dgvNguoiDung[1, indexRow].Value.ToString();
            txtChucVu.Text = dgvNguoiDung[9, indexRow].Value.ToString();
            if (dgvNguoiDung[2, indexRow].Value.ToString()=="1")
            {
                cmbQuyen.Text = "admin";
            }
            else
            {
                cmbQuyen.Text = "employee";
            }
            
            cmbMaNV.Text= dgvNguoiDung[3, indexRow].Value.ToString();
            txtTenNhanVien.Text=dgvNguoiDung[4, indexRow].Value.ToString();
            txtDiaChi.Text = dgvNguoiDung[5, indexRow].Value.ToString();
            mtbDienThoai.Text = dgvNguoiDung[6, indexRow].Value.ToString();
            txtLuong.Text = dgvNguoiDung[10, indexRow].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvNguoiDung[8, indexRow].Value;
            chkNam.Checked = false;
            chkNu.Checked = false;
            if (dgvNguoiDung[7, indexRow].Value.ToString() == "Nam")
            {
                chkNam.Checked = true;
            }
            else chkNu.Checked = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Phân quyền
            if (Cons.Quyen == 0)
            {
                KhoaButton();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDangNhap.Enabled = false;
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == "" || txtMatKhau.Text.Trim() == "" || txtXacNhanMK.Text.Trim() == "" || (cmbQuyen.Text != "admin" && cmbQuyen.Text != "employee") || cmbMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (txtMatKhau.Text.Trim() != txtXacNhanMK.Text.Trim())
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
            else
            {
                bool flagMaNV = false;
                bool flagTenDN = false;
                TaiKhoan tk = new TaiKhoan();
                tk.TenTaiKhoan = txtTenDangNhap.Text.Trim();
                tk.MatKhau = txtMatKhau.Text.Trim();
                tk.LoaiTaiKhoan = (cmbQuyen.Text == "admin") ? 1 : 0;
                tk.MaNV = cmbMaNV.Text.Trim();
                foreach (NhanVien tt in dsNhanVien)
                {
                    if (tt.MaNhanVien.Trim() == tk.MaNV)
                    {
                        flagMaNV = true;
                        break;
                    }
                }
                foreach (ThongTin tt in dsThongTin)
                {
                    if (tt.TenTaiKhoan.Trim() == tk.TenTaiKhoan.Trim())
                    {
                        flagTenDN = true;
                        break;
                    }
                }
                if (flagTenDN == true)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                } else if (flagMaNV == false)
                {
                    MessageBox.Show("Mã nhân viên không chính xác");
                }
                else
                {
                    int res = BLL_TaiKhoan.InsertTaiKhoan(tk);
                    if (res > 0)
                    {
                        HienThiDanhSachNguoiDung();
                        MessageBox.Show("Thêm tài khoản thành công");
                        ResetValues();
                        btnBoQua_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại");
                        ResetValues();
                    }
                }

            }
           

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() =="" || txtMatKhau.Text.Trim()=="" || txtXacNhanMK.Text.Trim()=="" ||(cmbQuyen.Text !="admin" && cmbQuyen.Text != "employee") || cmbMaNV.Text.Trim() =="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (txtMatKhau.Text.Trim() != txtXacNhanMK.Text.Trim())
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
            else
            {
                bool flag = false;
                TaiKhoan tk = new TaiKhoan();
                tk.TenTaiKhoan = txtTenDangNhap.Text.Trim();
                tk.MatKhau = txtMatKhau.Text.Trim();
                tk.LoaiTaiKhoan = (cmbQuyen.Text == "admin") ? 1 : 0;
                tk.MaNV = cmbMaNV.Text.Trim();
                foreach (NhanVien tt in dsNhanVien)
                {
                    if (tt.MaNhanVien.Trim() == tk.MaNV)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag==false)
                {
                    MessageBox.Show("Mã nhân viên không chính xác");
                } 
                else
                {
                    int res = BLL_TaiKhoan.UpdateTaiKhoan(tk);
                    if (res > 0)
                    {
                        HienThiDanhSachNguoiDung();
                        MessageBox.Show("Sửa đổi thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa đổi thất bại");
                    }
                }
                
            }                

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;
            int res = BLL_TaiKhoan.DeleteTaiKhoan(txtTenDangNhap.Text.Trim());
            if (res > 0)
            {
                HienThiDanhSachNguoiDung();
                ResetValues();
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắn chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Cancel || dlr == DialogResult.No)
                return;          
            this.Close();

        }
        private void cmbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (NhanVien tt in dsNhanVien)
            {
                if (tt.MaNhanVien.Trim() == cmbMaNV.SelectedItem.ToString().Trim())
                {
                   
                    txtChucVu.Text = tt.ChucVu;
                    txtTenNhanVien.Text = tt.TenNhanVien;
                    txtDiaChi.Text = tt.DiaChi;
                    mtbDienThoai.Text = tt.DienThoai;
                    txtLuong.Text = tt.Luong.ToString();

                    dtpNgaySinh.Value = tt.NgaySinh;
                    chkNam.Checked = false;
                    chkNu.Checked = false;
                    if (tt.GioiTinh.Trim() == "Nam")
                    {
                        chkNam.Checked = true;
                    }
                    else chkNu.Checked = true;
                }
            }
        }
        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        
    }
}
