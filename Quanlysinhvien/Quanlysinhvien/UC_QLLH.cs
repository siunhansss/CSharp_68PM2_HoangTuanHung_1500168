using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlysinhvien
{
    public partial class UC_QLLH : UserControl
    {
        QuanLySinhVienEntities db =
            new QuanLySinhVienEntities();
        public UC_QLLH()
        {
            InitializeComponent();
        }

        private void UC_QLLH_Load(object sender, EventArgs e)
        {
            LoadLop();
        }
        void LoadLop()
        {
            var ds = db.Lops.Select(l => new
            {
                l.ID,
                l.MaLop,
                l.TenLop,
                l.GhiChu
            }).ToList();

            dgvClass.DataSource = ds;

            dgvClass.Columns["ID"].HeaderText = "ID";
            dgvClass.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvClass.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvClass.Columns["GhiChu"].HeaderText = "Ghi chú";
        }
        void ClearForm()
        {
            txtID.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id;

                // kiểm tra ID hợp lệ
                if (!int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("ID phải là số!");
                    return;
                }

                string maLop = txtMaLop.Text.Trim();
                string tenLop = txtTenLop.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                if (string.IsNullOrEmpty(maLop))
                {
                    MessageBox.Show("Chưa nhập mã lớp!");
                    return;
                }

                // check trùng MaLop
                var check = db.Lops.Find(maLop);
                if (check != null)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!");
                    return;
                }

                // tạo lớp
                Lop lop = new Lop()
                {
                    ID = id,
                    MaLop = maLop,
                    TenLop = tenLop,
                    GhiChu = ghiChu
                };

                db.Lops.Add(lop);
                db.SaveChanges();

                MessageBox.Show("Thêm lớp thành công!");

                LoadLop();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvClass.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtMaLop.Text = dgvClass.Rows[e.RowIndex].Cells["MaLop"].Value.ToString();
                txtTenLop.Text = dgvClass.Rows[e.RowIndex].Cells["TenLop"].Value.ToString();
                txtGhiChu.Text = dgvClass.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                string maLop = txtMaLop.Text.Trim();

                // tìm đối tượng cần sửa
                var lop = db.Lops.Find(maLop);

                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp!");
                    return;
                }

                // cập nhật dữ liệu
                lop.ID = id;
                lop.MaLop = maLop;
                lop.TenLop = txtTenLop.Text.Trim();
                lop.GhiChu = txtGhiChu.Text.Trim();

                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");

                LoadLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
