using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayit
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0,1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Admin12" && textBox2.Text == "panelgiriş123")
            {
                FrmKayitForm fr2 = new FrmKayitForm();
                fr2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
