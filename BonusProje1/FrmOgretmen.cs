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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci fro = new FrmOgrenci();
            fro.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup klp = new FrmKulup();
            klp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frd = new FrmDersler();
            frd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fsn = new FrmSinavNotlar();
            fsn.Show();
        }
    }
}
