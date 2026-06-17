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
        int pageSize = 5;
        int currentPage = 1;
        int totalPage = 1;

        List<dynamic> dataList;
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

            dataList = ds.Cast<dynamic>().ToList();

            currentPage = 1;
            totalPage = (int)Math.Ceiling((double)dataList.Count / pageSize);

            LoadPage();

            dgvClass.Columns["ID"].HeaderText = "ID";
            dgvClass.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvClass.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvClass.Columns["GhiChu"].HeaderText = "Ghi chú";
        }
        void LoadPage()
        {
            var data = dataList
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dgvClass.DataSource = null;   
            dgvClass.DataSource = data;

            
            if (dgvClass.Columns["ID"] != null)
                dgvClass.Columns["ID"].HeaderText = "ID";

            if (dgvClass.Columns["MaLop"] != null)
                dgvClass.Columns["MaLop"].HeaderText = "Mã lớp";

            if (dgvClass.Columns["TenLop"] != null)
                dgvClass.Columns["TenLop"].HeaderText = "Tên lớp";

            if (dgvClass.Columns["GhiChu"] != null)
                dgvClass.Columns["GhiChu"].HeaderText = "Ghi chú";

            lblPage.Text = $"Trang {currentPage}/{totalPage} | {data.Count} bản ghi";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtMaLop.Text.Trim();

                if (string.IsNullOrEmpty(maLop))
                {
                    MessageBox.Show("Chưa chọn lớp!");
                    return;
                }

                // kiểm tra sinh viên còn thuộc lớp
                var countSV = db.SinhViens.Count(sv => sv.MaLop == maLop);

                if (countSV > 0)
                {
                    MessageBox.Show("Không thể xóa! Lớp vẫn còn sinh viên.");
                    return;
                }

                // xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;

                // tìm lớp
                var lop = db.Lops.Find(maLop);

                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp!");
                    return;
                }

                // xóa
                db.Lops.Remove(lop);
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!");

                LoadLop();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim().ToLower();
            int id;
            bool isNumber = int.TryParse(keyword, out id);

            var ds = db.Lops
                .Where(l => l.MaLop.ToLower().Contains(keyword)
                         || (isNumber && l.ID == id)
                         || l.TenLop.ToLower().Contains(keyword))
                .Select(l => new
                {
                    l.ID,
                    l.MaLop,
                    l.TenLop,
                    l.GhiChu
                })
                .ToList();

            dataList = ds.Cast<dynamic>().ToList();

            currentPage = 1;
            totalPage = (int)Math.Ceiling((double)dataList.Count / pageSize);

            LoadPage();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadLop();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPage();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadPage();
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPage;
            LoadPage();
        }






    }

}
