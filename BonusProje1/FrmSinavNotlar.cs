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

namespace BonusProje1
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-EV2S3I4;Initial Catalog=BonusOkul;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtıd.Text));
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DERSAD";
            cmbders.ValueMember = ("DERSID");
            cmbders.DataSource = dt;
            baglanti.Close();
        }
        int notid;

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr2 = new FrmOgretmen();
            fr2.Show();
            this.Hide();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Green;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Green;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid=int.Parse ( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtıd.      Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav1.  Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.  Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.  Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje .  Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.   Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void button3_Click(object sender, EventArgs e)
        {
           
            //String durum;
             sinav1=Convert.ToInt32(txtsınav1 .Text);
            sinav2= Convert.ToInt32(txtsınav2 .Text);
            sinav3=Convert.ToInt32(txtsınav3.Text);
            proje=Convert.ToInt32(txtproje .Text);
            ortalama = (sinav3 + sinav2 + sinav1 + proje) / 4;
            txtortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else 
            {
                txtdurum.Text = "False";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbders.SelectedValue.ToString()),int.Parse(txtıd.Text),byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text),notid);
        }
    }
}
