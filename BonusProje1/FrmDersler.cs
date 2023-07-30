using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           FrmOgretmen fr2 = new FrmOgretmen();
            fr2.Show();
            this.Hide();
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor=Color.GreenYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Transparent;
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.YellowGreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.DersEkle(textBox2.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=ds.DersListesi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse (textBox1.Text));
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(textBox2.Text,byte.Parse(textBox1.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Yapılmıştır ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
