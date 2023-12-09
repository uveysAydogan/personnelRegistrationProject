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
    public partial class frmGrafik : Form
    {
        public frmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QQPA737\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        private void frmGrafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select empCity,count(*) from tbl_Personel group by empCity", baglanti);
            SqlDataReader dr1=komutg1.ExecuteReader();
            while(dr1.Read())
            {
                chart1.Series["Cities"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
            //ort maaş grafiği mesleğe göre
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select empJob, avg(empSalary) from tbl_Personel group by empJob", baglanti);
            SqlDataReader dr2=komutg2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Job-Salary"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
