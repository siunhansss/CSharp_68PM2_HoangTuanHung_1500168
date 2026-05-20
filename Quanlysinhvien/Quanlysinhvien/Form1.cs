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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = EM.Text;
            string password = MK.Text;

            string emailSV = "1500168@st.huce.edu.vn";
            string mssv = "123456";

            if (email == emailSV && password == mssv)
            {
                MessageBox.Show("Đăng nhập thành công");

                Main main = new Main();
                main.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void MK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
