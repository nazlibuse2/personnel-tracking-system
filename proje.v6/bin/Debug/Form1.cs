using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proje.v6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\proje.v6.mdb");

        
        public static bool yoneticiBool = false;
        public static bool personelBool = false;
        public static bool idariBool = false;
        public static string kullaniciadi;

        public static string tcno, ad, soyad, yetki;
        int hak = 3; bool durum = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (hak != 0)
            {
                kullaniciadi = textBox1.Text;
                if (radioButton2.Checked)
                {
                    idariBool = true;
                }
                else if (radioButton3.Checked)
                {
                    personelBool = true;
                }
                else
                {
                    yoneticiBool = true;
                }
                OleDbDataAdapter adaptor;
                DataSet verikumesi;

                baglan.Open();
                adaptor = new OleDbDataAdapter("Select * from kullanicilar", baglan);
                verikumesi = new DataSet();
                adaptor.Fill(verikumesi);
                OleDbCommand ekle = new OleDbCommand("Select * FROM kullanicilar", baglan);

                OleDbDataReader oku = ekle.ExecuteReader();
                while (oku.Read())
                {
                    if (radioButton1.Checked == true)
                    {
                        if (oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && oku["yetki"].ToString() == "Yönetici")
                        {

                            durum = true;
                            tcno = oku.GetValue(0).ToString();
                            ad = oku.GetValue(1).ToString();
                            soyad = oku.GetValue(2).ToString();
                            yetki = oku.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();

                            break;
                        }

                    }
                    if (radioButton2.Checked == true)
                    {
                        if (oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && oku["yetki"].ToString() == "İdari")
                        {
                            durum = true;
                            tcno = oku.GetValue(0).ToString();
                            ad = oku.GetValue(1).ToString();
                            soyad = oku.GetValue(2).ToString();
                            yetki = oku.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();

                            break;
                        }

                    }
                    if (radioButton3.Checked == true)
                    {
                        if (oku["kullaniciadi"].ToString() == textBox1.Text && oku["parola"].ToString() == textBox2.Text && oku["yetki"].ToString() == "Personel")
                        {
                            durum = true;
                            tcno = oku.GetValue(0).ToString();
                            ad = oku.GetValue(1).ToString();
                            soyad = oku.GetValue(2).ToString();
                            yetki = oku.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();

                            break;
                        }

                    }
                }

                oku.Close();
                baglan.Close();
                if (durum == false)
                {
                    hak--;
                    baglan.Close();
                }
                label6.Text = Convert.ToString(hak);
                if (hak == 0)
                {
                    button1.Enabled = false;
                    MessageBox.Show("GİRİŞ HAKKI KALMADI|", "PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                oku.Close();
            }
            baglan.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "KULLANICI GİRİŞİ......";
            radioButton1.Checked = true;
            this.AcceptButton = button1;
            this.CancelButton = button2;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            label6.Text = Convert.ToString(hak);
        }

        private void cb_sifreyigoster_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sifreyigoster.Checked)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
