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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\proje.v6.mdb");
        int girishakki = 20; bool durum = false;
        int gun;
        private void bt_izinal_Click(object sender, EventArgs e)
        {
            if (girishakki != 0)
            {
                baglan.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO izinalma(izinbasla, izinbit) values('" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')", baglan);
                int ii = cmd.ExecuteNonQuery();
                baglan.Close();
            }
            if (durum == false)
            {
                if (dateTimePicker1.Value.Month == dateTimePicker2.Value.Month)
                {
                    int songun = Convert.ToInt16(dateTimePicker2.Value.Day);
                    int ilkgun = Convert.ToInt16(dateTimePicker1.Value.Day);
                    gun = songun - ilkgun;
                    girishakki -= gun;
                    baglan.Close();
                }
                else
                {
                    var months = dateTimePicker2.Value.Month - dateTimePicker1.Value.Month - 1;
                    var startDateDayes = 30 - dateTimePicker1.Value.Day;
                    startDateDayes = startDateDayes == -1 ? 0 : startDateDayes;
                    var endDateDayes = dateTimePicker2.Value.Day;
                    var toplamgun = startDateDayes + endDateDayes + months * 30;
                    if (dateTimePicker2.Value.Year > dateTimePicker1.Value.Year)
                    {
                        toplamgun += 360 * (dateTimePicker2.Value.Year - dateTimePicker1.Value.Year);
                    }
                    girishakki -= toplamgun;

                }
            }
            if (girishakki > 0)
            {
                MessageBox.Show("İZİN ALINDI", "PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            label2.Text = Convert.ToString(girishakki);
            if (girishakki == 0 || girishakki < 0)
            {
                bt_izinal.Enabled = false;
                MessageBox.Show("İZİN HAKKI KALMADI|", "PERSONEL TAKİP PROGRAMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
