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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-EV2S3I4;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = ("KULUPID");
            comboBox1.DataSource = dt;
            baglanti.Close();


        }
        String c = "";

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d1 = MessageBox.Show("Öğrenci Silme İşlemi Yapılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d1 == DialogResult.Yes)
            {

                ds.OgrSil(int.Parse(textBox1.Text));

                MessageBox.Show("Öğrenci Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (d1 == DialogResult.No)
            {
                MessageBox.Show("Öğrenci Silme İşlemi Başarısız","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(textBox2.Text, textBox3.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(textBox1.Text));
            MessageBox.Show("Öğrenci Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
         
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if(radioButton2.Checked == true)
            {
                c = "Erkek";
            }
             DialogResult d =  MessageBox.Show("Öğrenci Ekleme İşlemi Yapılsın mı?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (d ==DialogResult.Yes)
            {
            ds.OgrenciEkle(textBox2.Text, textBox3.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);

            }
            else if (d == DialogResult.No)
            {
                MessageBox.Show("Öğrenci Eklenmedi");
            }

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

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

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Green;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Green;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text= comboBox1.SelectedValue.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String cinsiyet = "";
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if(cinsiyet == "Kız")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if(cinsiyet == "Erkek")
            {
                radioButton1.Checked=false;
                radioButton2.Checked = true;
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(textBox4.Text);
        }
    }
}
