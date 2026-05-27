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
    public partial class UC_QLSV : UserControl
    {
        QuanLySinhVienEntities2 db =
            new QuanLySinhVienEntities2();
        public UC_QLSV()
        {
            InitializeComponent();
        }

        private void UC_QLSV_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
        }
        void LoadSinhVien()
        {
            var ds = from sv in db.Students
                     join lh in db.Classes
                     on sv.ClassId equals lh.ClassId
                     select new
                     {
                         sv.MSSV,
                         sv.FullName,
                         sv.Gender,
                         sv.DateOfBirth,
                         lh.ClassName
                     };

            dgvSinhVien.DataSource = ds.ToList();
        }
    }
}
