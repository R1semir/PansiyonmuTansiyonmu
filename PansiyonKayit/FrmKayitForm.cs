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

namespace PansiyonKayit
{
    public partial class FrmKayitForm : Form
    {
        public FrmKayitForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BJO2DGU\\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True");
        
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblMüşteriler", baglanti);
            

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr[0].ToString();
                ekle.SubItems.Add(dr[1].ToString());
                ekle.SubItems.Add(dr[2].ToString());
                ekle.SubItems.Add(dr[3].ToString());
                ekle.SubItems.Add(dr[4].ToString());
                ekle.SubItems.Add(dr[5].ToString());
                ekle.SubItems.Add(dr[6].ToString());
                ekle.SubItems.Add(dr[7].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                       
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into tblMüşteriler (id,Ad,Soyad,OdaNo,GTarih,Telefon,Hesap,CTarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",baglanti);     
            komut1.Parameters.AddWithValue("@p1",textBox1.Text);
            komut1.Parameters.AddWithValue("@p2",textBox2.Text);
            komut1.Parameters.AddWithValue("@p3",textBox3.Text);
            komut1.Parameters.AddWithValue("@p4",comboBox1.Text);
            komut1.Parameters.AddWithValue("@p5",dateTimePicker1.Text);
            komut1.Parameters.AddWithValue("@p6",textBox6.Text);
            komut1.Parameters.AddWithValue("@p7",textBox7.Text);
            komut1.Parameters.AddWithValue("@p8",dateTimePicker2.Text);
            komut1.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("insert into BosOda (bosyerler) values(@e1)",baglanti);
            komut2.Parameters.AddWithValue("@e1",comboBox1.Text);
            komut2.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("delete from DoluOda where doluyerler=@r1",baglanti);
            komut3.Parameters.AddWithValue("@r1",comboBox1.Text);
            komut3.ExecuteNonQuery();

            MessageBox.Show("Kayıt Eklendi");
            baglanti.Close();
            verilerigoster();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from tblMüşteriler where id=@k1 ",baglanti);
            komutsil.Parameters.AddWithValue("@k1",textBox1.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            baglanti.Close();
            verilerigoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
  baglanti.Open();
  SqlCommand komutguncelle = new SqlCommand("Update tblMüşteriler set Ad=@s1,Soyad=@s2,OdaNo=@s3,GTarih=@s4,Telefon=@s5,Hesap=@s6,CTarih=@s7 where id=@s8",baglanti);
            komutguncelle.Parameters.AddWithValue("@s1",textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@s2",textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@s3",comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@s4",dateTimePicker1.Text);
            komutguncelle.Parameters.AddWithValue("@s5",textBox6.Text);
            komutguncelle.Parameters.AddWithValue("@s6",textBox7.Text);
            komutguncelle.Parameters.AddWithValue("@s7",dateTimePicker2.Text);
            komutguncelle.Parameters.AddWithValue("@s8",textBox1.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı Güncellendi");
            verilerigoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblMüşteriler where  Ad like @arananAd", baglanti);
            komut.Parameters.AddWithValue("@arananAd","%"+ textBox5.Text + "%");
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr[0].ToString();
                ekle.SubItems.Add(dr[1].ToString());
                ekle.SubItems.Add(dr[2].ToString());
                ekle.SubItems.Add(dr[3].ToString());
                ekle.SubItems.Add(dr[4].ToString());
                ekle.SubItems.Add(dr[5].ToString());
                ekle.SubItems.Add(dr[6].ToString());
                ekle.SubItems.Add(dr[7].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text.Substring(1) + textBox4.Text.Substring(0, 1);
        }

        private void FrmKayitForm_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutoda = new SqlCommand("select * from BosOda",baglanti);
            SqlDataReader dr2 = komutoda.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0].ToString());
            }
            baglanti.Close();
        }
    }
}
