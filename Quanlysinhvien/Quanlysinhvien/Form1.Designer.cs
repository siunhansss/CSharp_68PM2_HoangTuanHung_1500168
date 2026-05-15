namespace Quanlysinhvien
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.EM = new System.Windows.Forms.TextBox();
            this.MK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EM
            // 
            this.EM.Location = new System.Drawing.Point(352, 142);
            this.EM.Name = "EM";
            this.EM.Size = new System.Drawing.Size(220, 20);
            this.EM.TabIndex = 1;
            this.EM.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MK
            // 
            this.MK.Location = new System.Drawing.Point(352, 177);
            this.MK.Name = "MK";
            this.MK.PasswordChar = '*';
            this.MK.Size = new System.Drawing.Size(220, 20);
            this.MK.TabIndex = 2;
            this.MK.TextChanged += new System.EventHandler(this.MK_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DN
            // 
            this.DN.BackColor = System.Drawing.Color.SandyBrown;
            this.DN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DN.Location = new System.Drawing.Point(361, 258);
            this.DN.Name = "DN";
            this.DN.Size = new System.Drawing.Size(120, 40);
            this.DN.TabIndex = 0;
            this.DN.Text = "Đăng nhập";
            this.DN.UseVisualStyleBackColor = false;
            this.DN.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.DN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EM;
        private System.Windows.Forms.TextBox MK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DN;
    }
}

