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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\proje.v6.mdb");
        public static string mesaj;
        private void bt_gonder_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string a = "INSERT INTO mesajlar(mesaj) values('" + textBox1.Text + "')";
            OleDbCommand cmd = new OleDbCommand(a, baglan);
            int ii = cmd.ExecuteNonQuery();
            mesaj = textBox1.Text;
            baglan.Close();
            this.Hide();
        }
    }
}
