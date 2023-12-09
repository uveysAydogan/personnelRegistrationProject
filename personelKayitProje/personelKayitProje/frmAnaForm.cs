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
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QQPA737\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtEmpID.Text = "";
            txtEmpName.Text="";
            txtEmpSurname.Text = "";
            txtEmpJob.Text = "";
            cmbEmpCity.Text = "";
            mskEmpSalary.Text = "";
            radioMarried.Checked = false;
            radioSingle.Checked = false;
            txtEmpName.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_Personel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut=new SqlCommand("insert into tbl_Personel (empName,empSurname,empCity,empSalary,empJob,empMstat) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtEmpName.Text);
            komut.Parameters.AddWithValue("@p2", txtEmpSurname.Text);
            komut.Parameters.AddWithValue("@p3", cmbEmpCity.Text);
            komut.Parameters.AddWithValue("@p4", mskEmpSalary.Text);
            komut.Parameters.AddWithValue("@p5", txtEmpJob.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel was inserted");
        }

        private void radioMarried_CheckedChanged(object sender, EventArgs e)
        {
            if(radioMarried.Checked)
            {
                label8.Text = "True";
            }
        }

        private void radioSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSingle.Checked)
            {
                label8.Text = "False";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtEmpID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtEmpName.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtEmpSurname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbEmpCity.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskEmpSalary.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtEmpJob.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioMarried.Checked = true;
            }
            if(label8.Text == "False") 
            {
                radioSingle.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From tbl_Personel where empID=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtEmpID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("Update tbl_Personel set empName=@a1,empSurname=@a2,empCity=@a3,empSalary=@a4,empMstat=@a5,empJob=@a6 where empID=@a7",baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", txtEmpName.Text);
            komutGuncelle.Parameters.AddWithValue("@a2",txtEmpSurname.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", cmbEmpCity.Text);
            komutGuncelle.Parameters.AddWithValue("@a4",mskEmpSalary.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", txtEmpJob.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", txtEmpID.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satır Güncellendi!");
        }

        private void btnSystat_Click(object sender, EventArgs e)
        {
            frmİstatistik frm=new frmİstatistik();
            frm.Show();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            frmGrafik frm=new frmGrafik();
            frm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FrmRaporlar frm=new FrmRaporlar();
            frm.Show();
        }
    }
}
