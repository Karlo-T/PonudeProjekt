using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudeProjekt
{
    public partial class Form_Postavke : Form
    {
        private string lokacijaSpremanja;

        public Form_Postavke()
        {
            InitializeComponent();
        }

        private void Form_Postavke_Load(object sender, EventArgs e)
        {
            //Ucitavanje postavki iz baze podataka
            List<PostavkeModel> postavke = SqliteDataAccess.UcitajPostavke();
            foreach (var item in postavke)
            {
                lokacijaSpremanja = item.SaveLocation.ToString();
            }

            Input_Lokacija_Spremanja.Text = lokacijaSpremanja;
        }

        private void Button_Odaberi_Click(object sender, EventArgs e)
        {
            txt_spremljeno.Visible = false;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Input_Lokacija_Spremanja.Text = fbd.SelectedPath;
                }
            }
        }

        private void Button_Spremi_Click(object sender, EventArgs e)
        {
            txt_spremljeno.Visible = true;
            SqliteDataAccess.AzurirajSaveLocation(Input_Lokacija_Spremanja.Text);
        }
    }
}
