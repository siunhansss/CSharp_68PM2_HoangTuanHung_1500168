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
        QuanLySinhVienEntities2 db =
            new QuanLySinhVienEntities2();
        public UC_QLLH()
        {
            InitializeComponent();
        }

        private void UC_QLLH_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
        }
        void LoadLopHoc()
        {
            dgvLopHoc.DataSource =
                db.Classes.ToList();
        }
    }
}
