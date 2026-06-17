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
    public partial class FrmSinhVienTheoLop : Form
    {
        QuanLySinhVienEntities db = new QuanLySinhVienEntities();

        string maLop;   // lưu mã lớp

        public FrmSinhVienTheoLop(string maLop)
        {
            InitializeComponent();
            this.maLop = maLop;
        }
        private void FrmSinhVienTheoLop_Load(object sender, EventArgs e)
        {
            var ds = db.SinhViens
                .Where(sv => sv.MaLop == maLop)
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.GioiTinh,
                    sv.NgaySinh
                })
                .ToList();

            dgvSinhVien.DataSource = ds;

            lblTitle.Text = $"Danh sách SV lớp: {maLop}";
        }
    }
}
