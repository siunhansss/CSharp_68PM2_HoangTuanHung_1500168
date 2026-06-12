using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Quanlysinhvien
{
    public partial class UC_QLSV : UserControl
    {
        string maSVCu = "";
        QuanLySinhVienEntities db =
            new QuanLySinhVienEntities();
        public UC_QLSV()
        {
            InitializeComponent();
        }
        void LoadComboBox()
        {
            cbClass.DataSource = db.Lops.ToList();
            cbClass.DisplayMember = "TenLop";
            cbClass.ValueMember = "MaLop";
        }
        private void UC_QLSV_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadSinhVien();
        }

        void LoadSinhVien()
        {
            var ds = from sv in db.SinhViens
                     join lop in db.Lops
                     on sv.MaLop equals lop.MaLop
                     select new
                     {
                         sv.MaSV,
                         sv.HoTen,
                         sv.GioiTinh,
                         sv.NgaySinh,
                         TenLop = lop.TenLop
                     };

            dgvSinhVien.DataSource = ds.ToList();

            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvSinhVien.Columns["TenLop"].HeaderText = "Tên lớp";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string gioiTinh = cbGioiTinh.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string maLop = cbClass.SelectedValue.ToString();

                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Chưa nhập mã sinh viên!");
                    return;
                }

                var check = db.SinhViens.Find(maSV);
                if (check != null)
                {
                    MessageBox.Show("Mã SV đã tồn tại!");
                    return;
                }

                SinhVien sv = new SinhVien()
                {
                    MaSV = maSV,
                    HoTen = hoTen,
                    GioiTinh = gioiTinh,
                    NgaySinh = ngaySinh,
                    MaLop = maLop
                };

                db.SinhViens.Add(sv);
                db.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!");
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSV.Text = dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                txtHoTen.Text = dgvSinhVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                cbGioiTinh.Text = dgvSinhVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(
                    dgvSinhVien.Rows[e.RowIndex].Cells["NgaySinh"].Value);

                cbClass.Text = dgvSinhVien.Rows[e.RowIndex].Cells["TenLop"].Value.ToString();

                // lưu mã cũ
                maSVCu = txtMaSV.Text;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string maSVCu_local = maSVCu;
                string maSVMoi = txtMaSV.Text.Trim();

                var svCu = db.SinhViens.Find(maSVCu);

                if (svCu == null)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }

                // nếu đổi mã → check trùng
                if (maSVMoi != maSVCu)
                {
                    var check = db.SinhViens.Find(maSVMoi);
                    if (check != null)
                    {
                        MessageBox.Show("Mã SV đã tồn tại!");
                        return;
                    }
                }

                // tạo mới
                SinhVien svMoi = new SinhVien()
                {
                    MaSV = maSVMoi,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = cbGioiTinh.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    MaLop = cbClass.SelectedValue.ToString()
                };

                // xóa cũ
                db.SinhViens.Remove(svCu);

                // thêm mới
                db.SinhViens.Add(svMoi);

                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");
                LoadSinhVien();

                maSVCu = maSVMoi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    

    }
