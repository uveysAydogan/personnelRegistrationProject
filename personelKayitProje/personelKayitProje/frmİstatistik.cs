using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelKayitProje
{
    public partial class frmİstatistik : Form
    {
        public frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QQPA737\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        private void frmİstatistik_Load(object sender, EventArgs e)
        {
            //toplam çalışan sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lblTotalEmployee.Text = dr1[0].ToString();
            }
            baglanti.Close();
            //Evli çalışan sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from tbl_Personel where empMstat=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblTotalMarried.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //bekar çalışan sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count (*) from tbl_Personel where empMStat=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                lblTotalSingle.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select Count(distinct(empCity)) from tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while(dr4.Read())
            {
                lblTotalCity.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //Toplam Maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(empSalary) from tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while(dr5.Read())
            {
                lblTotalSalary.Text = dr5[0].ToString();
            }
            baglanti.Close();
            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(empSalary) from tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while(dr6.Read())
            {
                lblAvgSalary.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
