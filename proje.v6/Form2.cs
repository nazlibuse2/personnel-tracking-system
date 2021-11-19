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
using System.Text.RegularExpressions;
using System.IO;

namespace proje.v6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\proje.v6.mdb");
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_proje_v6DataSet8.kullanicilar' table. You can move, or remove it, as needed.
            this.kullanicilarTableAdapter1.Fill(this._proje_v6DataSet8.kullanicilar);
            // TODO: This line of code loads data into the '_proje_v6DataSet7.izinalma' table. You can move, or remove it, as needed.
            this.izinalmaTableAdapter.Fill(this._proje_v6DataSet7.izinalma);
            // TODO: This line of code loads data into the '_proje_v6DataSet6.kullanicilar' table. You can move, or remove it, as needed.
            this.kullanicilarTableAdapter.Fill(this._proje_v6DataSet6.kullanicilar);
            mtb_tc.MaxLength = 11;
            tb_kullaniciadi.MaxLength = 8;
            tb_parola.MaxLength = 10;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            mtb_tc.Mask = "00000000000";
            mtb_ad.Mask = "LL????????????????????";
            mtb_soyad.Mask = "LL????????????????????";
            mtb_ad.Text.ToUpper();
            mtb_soyad.Text.ToUpper();

            if (Form1.personelBool)
            {
                bt_ekle.Hide();
                bt_sil.Hide();
                bt_ara.Hide();
                bt_mesajgonder.Hide();
                MessageBox.Show(Form4.mesaj, "PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OleDbDataAdapter adp = new OleDbDataAdapter("Select * from kullanicilar where kullaniciadi='" + Form1.kullaniciadi + "'", baglan);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

                mtb_tc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                mtb_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                mtb_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbcinsiyet.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                tbtelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbeposta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tbadres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tbgorevi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tbmaas.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tb_yetki.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tb_kullaniciadi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tb_parola.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tb_parolatekrar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                dataGridView1.Hide();
            }
            if (Form1.idariBool)
            {
                bt_ekle.Hide();
                bt_sil.Hide();
                bt_ara.Hide();
                bt_mesajgonder.Hide();
                MessageBox.Show(Form4.mesaj, "PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OleDbDataAdapter adp = new OleDbDataAdapter("Select * from kullanicilar where kullaniciadi='" + Form1.kullaniciadi + "'", baglan);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

                mtb_tc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                mtb_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                mtb_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbcinsiyet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbtelefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tbeposta.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tbadres.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tbgorevi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tbmaas.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                tb_yetki.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                tb_kullaniciadi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                tb_parola.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tb_parolatekrar.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                dataGridView1.Hide();
            }
            if (Form1.yoneticiBool)
            {
                bt_izinal.Hide();
            }
            label13.Text = Convert.ToString(DateTime.Now);
            baglan.Open();
            OleDbCommand giris = new OleDbCommand("Update kullanicilar SET girissaati='" + label13.Text + "' where tcno='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
            giris.ExecuteNonQuery();
            baglan.Close();
            timer1.Interval = 1000000000;
            timer1.Start();
        }
        void griddoldur()
        {
            OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\proje.v6.mdb");
            baglan.Open();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SElect *from kullanicilar", baglan);
            DataSet verikumesi = new DataSet();
            adaptor.Fill(verikumesi, "kullanicilar");
            dataGridView1.DataSource = verikumesi.Tables["kullanicilar"];
            baglan.Close();
        }
        private void bt_ekle_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;
            baglan.Open();
            string a = "INSERT INTO kullanicilar(tcno,Ad,soyad,telefon,eposta,adres,gorevi,maas,kullaniciadi,parola,yetki,cinsiyet) values('" +
                mtb_tc.Text + "','" + mtb_ad.Text + "','" + mtb_soyad.Text + "','"  + "','" + tbtelefon.Text + "','" +
                tbeposta.Text + "','" + tbadres.Text + "','" + tbgorevi.Text + "','" + tbmaas.Text + "','" + tb_kullaniciadi.Text +
                "','" + tb_parola.Text + "','" + tb_yetki.Text + "','"+ cbcinsiyet.Text+"')";
            OleDbCommand cmd = new OleDbCommand(a, baglan);
            int ii = cmd.ExecuteNonQuery();
            if (ii == 1)
            {
                kayitkontrol = true;
            }

            baglan.Close();
            if (kayitkontrol == false)
            {
                if (mtb_tc.Text.Length < 11 || mtb_tc.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;
                if (mtb_ad.Text.Length < 2 || mtb_ad.Text == "")
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;
                if (mtb_soyad.Text.Length < 2 || mtb_soyad.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;
                if (tb_kullaniciadi.Text.Length != 8 || tb_kullaniciadi.Text == "")
                    lb_kuladi.ForeColor = Color.Red;
                else
                    lb_kuladi.ForeColor = Color.Black;
                if (parola_skoru < 70 || tb_parola.Text == "")
                    lb_parola.ForeColor = Color.Red;
                else
                    lb_parola.ForeColor = Color.Black;
                if (tb_parola.Text != tb_parolatekrar.Text || tb_parolatekrar.Text == "")
                    lb_parolatekrar.ForeColor = Color.Red;
                else
                    lb_parolatekrar.ForeColor = Color.Black;

                if (mtb_tc.Text.Length == 11 && mtb_tc.Text != "" && mtb_ad.Text != "" && mtb_ad.Text.Length > 1 && mtb_soyad.Text != "" &&
                    mtb_soyad.Text.Length > 1 && tb_kullaniciadi.Text != "" && tb_parola.Text != "" && tb_parolatekrar.Text != "" &&
                    tb_parola.Text == tb_parolatekrar.Text && parola_skoru >= 70)
                {
                    try
                    {
                        baglan.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("INSERT INTO kullanicilar(tcno,Ad,soyad,cinsiyet,telefon,eposta,adres,gorevi,maas,kullaniciadi,parola,yetki) values('" +
                mtb_tc.Text + "','" + mtb_ad.Text + "','" + mtb_soyad.Text + "','" + cbcinsiyet.Text + "','" + tbtelefon.Text + "','" +
                tbeposta.Text + "','" + tbadres.Text + "','" + tbgorevi.Text + "','" + tbmaas.Text + "','" + tb_kullaniciadi.Text +
                "','" + tb_parola.Text + "','" + tb_yetki.Text + "')");
                        eklekomutu.ExecuteNonQuery();
                        griddoldur();
                        baglan.Close();
                        tb_temizle();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        baglan.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void bt_sil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand selectsorgu = new OleDbCommand("delete from kullanicilar where tcno='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
            selectsorgu.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı kaydı silindi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            griddoldur();
            baglan.Close();
            tb_temizle();
        }
        int parola_skoru = 0;

        private void tb_parola_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = tb_parola.Text;
            string duzeltilmis_sifre = "";
            duzeltilmis_sifre = sifre;
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("İ", "i");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("ı", "i");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("ç", "c");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("Ş", "S");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("Ğ", "G");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("ğ", "g");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("Ü", "U");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("ü", "u");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("Ö", "O");
            duzeltilmis_sifre = duzeltilmis_sifre.Replace("ö", "o");
            if (sifre != duzeltilmis_sifre)
            {
                tb_parola.Text = sifre;
                MessageBox.Show("Paroladaki Türkçe karakterler İngilizce karakterlere dönüştürülmüştür!");
            }

            int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;
            int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            buyuk_harf_skoru = Math.Min(2, AZ_karakter_sayisi) * 10;
            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;
            int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;
            if (sifre.Length == 9)
                parola_skoru += 10;
            else if (sifre.Length == 10)
                parola_skoru += 20;
            if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
                label11.Text = "Büyük harf, küçük harf, rakam, sembol mutlaka kullanmalısın!";
            if (kucuk_harf_skoru != 0 && buyuk_harf_skoru != 0 && rakam_skoru != 0 && sembol_skoru != 0)
                label11.Text = "";

            if (parola_skoru < 70)
                parola_seviyesi = "Kabul edilemez!";
            else if (parola_skoru == 70 || parola_skoru == 80)
                parola_seviyesi = "Güçlü";
            else if (parola_skoru == 90 || parola_skoru == 100)
                parola_seviyesi = "Çok Güçlü";
            lb_skor.Text = "%" + Convert.ToString(parola_skoru);
            lb_seviye.Text = parola_seviyesi;
            progressBar1.Value = parola_skoru;
        }

        private void mtb_tc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (mtb_tc.Text.Length < 11)
                errorProvider1.SetError(mtb_tc, "TC Kimlik No 11 karakter olmalı!");
            else
                errorProvider1.Clear();
        }

        private void mtb_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void mtb_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void mtb_soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tb_parolatekrar_TextChanged(object sender, EventArgs e)
        {
            if (tb_parolatekrar.Text != tb_parola.Text)
                errorProvider1.SetError(tb_parolatekrar, "Parola tekrarı eşleşmiyor!");
            else
                errorProvider1.Clear();
        }

        private void tb_kullaniciadi_TextChanged(object sender, EventArgs e)
        {
            if (tb_kullaniciadi.Text.Length != 8)
                errorProvider1.SetError(tb_kullaniciadi, "Kullanıcı adı 8 karakter olmalı!");
            else
                errorProvider1.Clear();
        }
        private void tb_temizle()
        {
            mtb_tc.Clear();
            mtb_ad.Clear();
            mtb_soyad.Clear();
            tbtelefon.Clear();
            tbeposta.Clear();
            tbadres.Clear();
            tbgorevi.Clear();
            tbmaas.Clear();
            tb_kullaniciadi.Clear();
            tb_parola.Clear();
            tb_parolatekrar.Clear();
        }

        private void bt_guncelle_Click(object sender, EventArgs e)
        {
            if (mtb_tc.Text.Length < 11 || mtb_tc.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;
            if (mtb_ad.Text.Length < 2 || mtb_ad.Text == "")
                label9.ForeColor = Color.Red;
            else
                label9.ForeColor = Color.Black;
            if (mtb_soyad.Text.Length < 2 || mtb_soyad.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;
            if (tb_kullaniciadi.Text.Length != 8 || tb_kullaniciadi.Text == "")
                lb_kuladi.ForeColor = Color.Red;
            else
                lb_kuladi.ForeColor = Color.Black;
            if (parola_skoru < 70 || tb_parola.Text == "")
                lb_parola.ForeColor = Color.Red;
            else
                lb_parola.ForeColor = Color.Black;
            if (tb_parola.Text != tb_parolatekrar.Text || tb_parolatekrar.Text == "")
                lb_parolatekrar.ForeColor = Color.Red;
            else
                lb_parolatekrar.ForeColor = Color.Black;

            if (mtb_tc.Text.Length == 11 && mtb_tc.Text != "" && mtb_ad.Text != "" && mtb_ad.Text.Length > 1 && mtb_soyad.Text != "" &&
                mtb_soyad.Text.Length > 1 && tb_kullaniciadi.Text != "" && tb_parola.Text != "" && tb_parolatekrar.Text != "" &&
                tb_parola.Text == tb_parolatekrar.Text && parola_skoru >= 70)
            {
                try
                {
                    baglan.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("Update kullanicilar SET ad='" + mtb_ad.Text +
                        "', soyad='" + mtb_soyad.Text +  "',telefon='" + tbtelefon.Text + "',eposta='" + tbeposta.Text + "',adres='" +
                        tbadres.Text + "',gorevi='" + tbgorevi.Text + "',maas='" + tbmaas.Text + "',yetki='" + tb_yetki.Text + "',kullaniciadi='" + tb_kullaniciadi.Text +
                        "',parola='" + tb_parola.Text + "',cinsiyet='" + cbcinsiyet.Text + "' where tcno='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);

                    guncellekomutu.ExecuteNonQuery();
                    baglan.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_formtemizle_Click(object sender, EventArgs e)
        {
            tb_temizle();
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            mtb_tc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mtb_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mtb_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            tbtelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbeposta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbadres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbgorevi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbmaas.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tb_kullaniciadi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tb_parola.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tb_parolatekrar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tb_yetki.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void bt_ara_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (mtb_tc.Text.Length == 11)
            {
                baglan.Open();
                OleDbCommand aramasorgusu = new OleDbCommand("select * from kullanicilar where tcno='" + mtb_tc.Text + "'", baglan);
                OleDbDataReader kayitokuma = aramasorgusu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    mtb_ad.Text = kayitokuma.GetValue(1).ToString();
                    mtb_soyad.Text = kayitokuma.GetValue(2).ToString();
                    cbcinsiyet.Text = kayitokuma.GetValue(11).ToString();
                    tbtelefon.Text = kayitokuma.GetValue(3).ToString();
                    tbeposta.Text = kayitokuma.GetValue(4).ToString();
                    tbadres.Text = kayitokuma.GetValue(5).ToString();
                    tbgorevi.Text = kayitokuma.GetValue(6).ToString();
                    tbmaas.Text = kayitokuma.GetValue(7).ToString();
                    tb_yetki.Text = kayitokuma.GetValue(8).ToString();
                    tb_kullaniciadi.Text = kayitokuma.GetValue(9).ToString();
                    tb_parola.Text = kayitokuma.GetValue(10).ToString();
                    tb_parolatekrar.Text = kayitokuma.GetValue(10).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayıt bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli bir TC kimlik no giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_temizle();
            }
        }

        private void bt_izinal_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void bt_cikis_Click(object sender, EventArgs e)
        {
            
            baglan.Open();
            OleDbCommand cikis = new OleDbCommand("Update kullanicilar SET cikissaati='" + timer1.ToString() + "' where tcno='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
            cikis.ExecuteNonQuery();
            baglan.Close();
            timer1.Stop();
            Application.Exit();
        }

        private void bt_mesajgonder_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mtb_tc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mtb_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mtb_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            tbtelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbeposta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbadres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbgorevi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbmaas.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tb_kullaniciadi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tb_parola.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tb_parolatekrar.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tb_yetki.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }




    }
}
