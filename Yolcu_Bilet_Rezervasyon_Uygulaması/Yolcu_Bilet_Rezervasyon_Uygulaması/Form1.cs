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

namespace Yolcu_Bilet_Rezervasyon_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=faruk\\sqlexpress;Initial Catalog=YolcuBiletRezervasyon;Integrated Security=True;");


        private void btn_YolcuEkle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@P1,@P2,@P3,@P4,@P5,@P6) ", conn);

            // MaskedTextBox.Text özelliğini kullanarak veriyi alıyoruz
            cmd.Parameters.AddWithValue("@P1", msk_Ad.Text);
            cmd.Parameters.AddWithValue("@P2", msk_Soyad.Text);
            cmd.Parameters.AddWithValue("@P3", msk_telNo.Text);  // Telefon numarası için
            cmd.Parameters.AddWithValue("@P4", msk_tc.Text);       // TC kimlik numarası için
            cmd.Parameters.AddWithValue("@P5", cmbo_cinsiyet.Text);
            cmd.Parameters.AddWithValue("@P6", msk_Mail.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Yeni Yolcu Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLKAPTANLAR (KAPTANNO,ADSOYAD,TELEFON) values (@P1,@P2,@P3)", conn);
            cmd.Parameters.AddWithValue("@P1", msk_kaptanNo.Text);
            cmd.Parameters.AddWithValue("@P2", txt_kaptanADSoyad.Text);
            cmd.Parameters.AddWithValue("@P3", msk_KaptanTelNo.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Yeni Kaptan Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values (@P1,@P2,@P3,@P4,@P5,@P6)", conn);
            cmd.Parameters.AddWithValue("@P1", msk_Kalkis.Text);
            cmd.Parameters.AddWithValue("@P2", msk_Varis.Text);
            cmd.Parameters.AddWithValue("@P3", msk_Tarih.Text);
            cmd.Parameters.AddWithValue("@P4", msk_Saat.Text);
            cmd.Parameters.AddWithValue("@P5", msk_KaptanID.Text);
            cmd.Parameters.AddWithValue("@P6", msk_fiyat.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Yeni Sefer Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SeferListele();
        }
        void SeferListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLSEFERBILGI", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            msk_RezSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "KAPTAN";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            msk_koltukNo.Text = "9";
        }

        private void btn_rezAl_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLHAREKETDETAY(SEFERNO,YOLCUTC,KOLTUK) values (@P1,@P2,@P3)", conn);
            cmd.Parameters.AddWithValue("@P1", msk_RezSeferNo.Text);
            cmd.Parameters.AddWithValue("@P2", msk_RezTC.Text);
            cmd.Parameters.AddWithValue("@P3", msk_koltukNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Rezerve işlemi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            switch (msk_koltukNo.Text)
            {
               
                case "2":
                    button3.BackColor = Color.Red; // 2 numaralı koltuk
                    break;
                case "3":
                    button4.BackColor = Color.Red; // 3 numaralı koltuk
                    break;
                case "4":
                    button5.BackColor = Color.Red; // 4 numaralı koltuk
                    break;
                case "5":
                    button6.BackColor = Color.Red; // 5 numaralı koltuk
                    break;
                case "6":
                    button7.BackColor = Color.Red; // 6 numaralı koltuk
                    break;
                case "7":
                    button8.BackColor = Color.Red; // 7 numaralı koltuk
                    break;
                case "8":
                    button9.BackColor = Color.Red; // 8 numaralı koltuk
                    break;
                case "9":
                    button10.BackColor = Color.Red; // 9 numaralı koltuk
                    break;
                default:
                    MessageBox.Show("Geçersiz koltuk numarası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
