using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace QLMucTieu
{
  
    public partial class frmDangNhap : Form
    {
        public static string _sFullname = "";
        public static string _sChucVu = "";
        public static string _sCapBac = "";


        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTen.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;

            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;

            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsTabTaiKhoan cls = new clsTabTaiKhoan();
            DataTable dt = cls.pr_tabTaiKhoan_Login(txtTen.Text.Trim(), EncodeMD5(txtMatKhau.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                _sFullname = dt.Rows[0]["hoTen"].ToString();
                _sChucVu = dt.Rows[0]["chucVu"].ToString();
                _sCapBac = dt.Rows[0]["capBac"].ToString();

                this.Hide();
                frmMain ff = new frmMain();
                ff.Show();
            }
            else
            {

                MessageBox.Show("Kiểm tra lại Tên đăng nhập hoặc mật khẩu");
                txtTen.ResetText();
                txtMatKhau.ResetText();
                txtTen.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        } 

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtMatKhau.Focus();
            }
            else
            {

            }


        }

        //
        public static string EncodeMD5(string Metin)
        {
            MD5CryptoServiceProvider MD5Code = new MD5CryptoServiceProvider();
            byte[] byteDizisi = Encoding.UTF8.GetBytes(Metin);
            byteDizisi = MD5Code.ComputeHash(byteDizisi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in byteDizisi)
            {
                sb.Append(ba.ToString("x2").ToUpper());
            }
            return sb.ToString();
        }
    }
}
