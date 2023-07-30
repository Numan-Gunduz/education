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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-EV2S3I4;Initial Catalog=BonusOkul;Integrated Security=True");
         void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
          liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update  TBLKULUPLER set KULUPAD=@p1 where KULUPID=@p2",baglanti);
            komut2.Parameters.AddWithValue("@p1",textBox2.Text);
            komut2.Parameters.AddWithValue("@p2",textBox1.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DialogResult d1 = MessageBox.Show("Kulüp Silme İşlemi Yapılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d1 == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBLKULUPLER WHERE KULUPID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kulüp Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d1 == DialogResult.No)
            {
                MessageBox.Show("Kulüp Silme İşlemi Başarısız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                baglanti.Close();
            liste();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand  komut = new SqlCommand ("insert Into TBLKULUPLER (KULUPAD) values (@p1)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();   
            MessageBox.Show("Kulüp Listeye Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information );
            liste();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Yellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           FrmOgretmen fr1= new FrmOgretmen();
            fr1.Show();
            this.Hide();
           
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Yellow;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }
    }
}
