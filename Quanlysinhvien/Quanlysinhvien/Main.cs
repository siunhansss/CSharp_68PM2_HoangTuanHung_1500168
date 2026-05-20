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
    public partial class Main : Form

    {
        private UC_QLLH uc_qllh = new UC_QLLH();
        private UC_QLSV uc_qlsv = new UC_QLSV();
        public Main()
        {
            InitializeComponent();
            LoadUserControl(new UC_QLSV());
            SetActiveButton(button1);
        }
        private void LoadUserControl(UserControl uc)
        {
            panel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);
        }
        private void SetActiveButton(Button activeButton)
        {
            button1.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            button2.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            activeButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(uc_qlsv);
            SetActiveButton(button1);
        }
        

       

        private void panel_Paint_1(object sender, PaintEventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(uc_qllh);
            SetActiveButton(button2);
        }
    }
}
