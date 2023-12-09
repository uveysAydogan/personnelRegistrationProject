using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace personelKayitProje
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QQPA737\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Admin where Username=@p1 and Password=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1",txtUsername.Text);
            komut.Parameters.AddWithValue("@p2",txtPassword.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaForm frm=new frmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!/incorrect username or password!");
            }
            baglanti.Close();
        }
    }
}
