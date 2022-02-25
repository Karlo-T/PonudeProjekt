using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace PonudeProjekt
{
    public partial class Form_Main : Form
    {
        private Form currentChildForm;
       
        public Form_Main()
        {
            InitializeComponent();

            Height = (int)(Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height * 0.10));
            Width = (int)(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width * 0.10));

            Panel_Menu.Width = (int)(Width * 0.15);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\Ponude"))
                Directory.CreateDirectory(@"C:\Ponude");

            OtvoriPonude();
        }

        private void btnNovaPonuda_Click(object sender, EventArgs e)
        {
            ClearButtons();

            //vizualni selektor
            onlNav.Height = btnNovaPonuda.Height;
            onlNav.Top = btnNovaPonuda.Top;
            onlNav.Left = btnNovaPonuda.Left;
            btnNovaPonuda.BackColor = Color.FromArgb(7, 69, 116);

            DisableButtons();

            //otvori formu nove ponude
            Form_Nova_Ponuda frr = new Form_Nova_Ponuda();
            OpenChildForm(frr);
            frr.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void btnPonude_Click(object sender, EventArgs e)
        {
            OtvoriPonude();
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            ClearButtons();

            onlNav.Height = btnPostavke.Height;
            onlNav.Top = btnPostavke.Top;
            onlNav.Left = btnPostavke.Left;
            btnPostavke.BackColor = Color.FromArgb(7, 69, 116);

            OpenChildForm(new Form_Postavke());
        }

        public void ClearButtons()
        {
            onlNav.Height = 0;
            btnNovaPonuda.BackColor = Color.FromArgb(0, 50, 95);
            btnPonude.BackColor = Color.FromArgb(0, 50, 95);
            btnPostavke.BackColor = Color.FromArgb(0, 50, 95);
            btnKlijenti.BackColor = Color.FromArgb(0, 50, 95);
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Dispose();
            }

            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesktop.Controls.Add(childForm);
            PanelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            ClearButtons();

            onlNav.Height = btnKlijenti.Height;
            onlNav.Top = btnKlijenti.Top;
            onlNav.Left = btnKlijenti.Left;
            btnKlijenti.BackColor = Color.FromArgb(7, 69, 116);

            OpenChildForm(new Form_Klijenti());
        }

        public void UrediPonudu(string brPonude)
        {
            ClearButtons();

            DisableButtons();

            Form_Uredi_Ponudu frm = new Form_Uredi_Ponudu(brPonude, this);
            OpenChildForm(frm);
            frm.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        public void NovaPonudaTemeljemPonude(string brPonude)
        {
            ClearButtons();

            DisableButtons();

            Form_Nova_Ponuda_Temeljem_Ponude frm = new Form_Nova_Ponuda_Temeljem_Ponude(brPonude, this);
            OpenChildForm(frm);
            frm.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private new void FormClosed(object sender, FormClosedEventArgs e)
        {
            EnableButtons();

            OtvoriPonude();
        }

        public void OtvoriPonude()
        {
            ClearButtons();

            onlNav.Height = btnPonude.Height;
            onlNav.Top = btnPonude.Top;
            onlNav.Left = btnPonude.Left;
            btnPonude.BackColor = Color.FromArgb(7, 69, 116);

            OpenChildForm(new Form_Ponude(this));
        }

        public void DisableButtons()
        {
            btnKlijenti.Enabled = false;
            btnPonude.Enabled = false;
            btnPostavke.Enabled = false;
            btnNovaPonuda.Enabled = false;
        }

        public void EnableButtons()
        {
            btnKlijenti.Enabled = true;
            btnPonude.Enabled = true;
            btnPostavke.Enabled = true;
            btnNovaPonuda.Enabled = true;
        }
    }
}
