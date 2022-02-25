using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudeProjekt
{
    public partial class Form_Klijenti : Form
    {
        int selektiraniKlijent = 0;
        List<KlijentModel> klijenti = new List<KlijentModel>();

        List<Control> shadowControls = new List<Control>();
        Bitmap shadowBmp = null;

        public Form_Klijenti()
        {
            InitializeComponent();

            //Stavljanje sijene na panele
            shadowControls.Add(Panel_Klijenti);
            shadowControls.Add(Panel_KlijentInfo);
            this.Refresh();
        }

        //Sijena
        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceCopy;
                double alpha = 0;
                double astep = 0;
                double astepstep = (double)intensity / radius / (radius / 2D);
                for (int thickness = radius; thickness > 0; thickness--)
                {
                    using (Pen p = new Pen(Color.FromArgb((int)alpha, 0, 0, 0), thickness))
                    {
                        p.LineJoin = LineJoin.Round;
                        g.DrawPath(p, gp);
                    }
                    alpha += astep;
                    astep += astepstep;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (shadowBmp == null || shadowBmp.Size != this.Size)
            {
                shadowBmp?.Dispose();
                shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            }
            foreach (Control control in shadowControls)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddRectangle(new Rectangle(control.Location.X, control.Location.Y, control.Size.Width, control.Size.Height));
                    DrawShadowSmooth(gp, 25, 20, shadowBmp);
                }
                e.Graphics.DrawImage(shadowBmp, new Point(0, 0));
            }
        }

        private void Form_Klijenti_Shown(object sender, EventArgs e)
        {
            int x = Tablica_Klijenti.Width - 600;
            x = x / 3;
            Tablica_Klijenti.Columns[1].Width = x;
            Tablica_Klijenti.Columns[2].Width = x;
            Tablica_Klijenti.Columns[3].Width = x;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KlijentModel k = new KlijentModel();

            k.Ime = Input_ImePrezimeNaziv.Text.ToString();
            k.Adresa = Input_Adresa.Text.ToString();
            k.Posta = Input_Posta.Text.ToString();
            k.Oib = Input_Oib.Text.ToString();
            k.Dodatno = Input_Dodatno.Text.ToString();
            k.Telefon = Input_Telefon.Text.ToString();
            k.Mail = Input_Mail.Text.ToString();

            SqliteDataAccess.DodajKlijenta(k);

            ClearInputs();

            UcitajKlijente();
        }

        private void Form_Klijenti_Load(object sender, EventArgs e)
        {
            UcitajKlijente();
        }

        private void UcitajKlijente()
        {
            Tablica_Klijenti.Rows.Clear();
            klijenti = SqliteDataAccess.UcitajKlijente();

            foreach (var klijent in klijenti)
            {
                Tablica_Klijenti.Rows.Insert(0, klijent.Sifra, klijent.Ime, klijent.Adresa, klijent.Posta, klijent.Oib, klijent.Telefon, klijent.Mail, klijent.Dodatno);
            }

            Tablica_Klijenti.ClearSelection();
        }

        private void Tablica_Klijenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selektiraniKlijent = Convert.ToInt32(Tablica_Klijenti.Rows[e.RowIndex].Cells[0].Value);
                Input_Sifra.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[0].Value.ToString();
                Input_ImePrezimeNaziv.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[1].Value.ToString();
                Input_Adresa.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[2].Value.ToString();
                Input_Posta.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[3].Value.ToString();
                Input_Oib.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[4].Value.ToString();
                Input_Telefon.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[5].Value.ToString();
                Input_Mail.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[6].Value.ToString();
                Input_Dodatno.Text = Tablica_Klijenti.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            Input_Sifra.Text = "";
            Input_ImePrezimeNaziv.Text = "";
            Input_Adresa.Text = "";
            Input_Posta.Text = "";
            Input_Oib.Text = "";
            Input_Dodatno.Text = "";
            Input_Telefon.Text = "";
            Input_Mail.Text = "";

            Tablica_Klijenti.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void Button_Dodaj_Stavku_Click(object sender, EventArgs e)
        {
            KlijentModel k = new KlijentModel();

            k.Ime = Input_ImePrezimeNaziv.Text.ToString();
            k.Adresa = Input_Adresa.Text.ToString();
            k.Posta = Input_Posta.Text.ToString();
            k.Oib = Input_Oib.Text.ToString();
            k.Dodatno = Input_Dodatno.Text.ToString();
            k.Telefon = Input_Telefon.Text.ToString();
            k.Mail = Input_Mail.Text.ToString();

            SqliteDataAccess.UrediKlijenta(selektiraniKlijent, k);

            ClearInputs();

            UcitajKlijente();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.IzbrisiKlijenta(selektiraniKlijent);

            ClearInputs();

            UcitajKlijente();
        }

        private void Input_Pretrazi_TextChanged(object sender, EventArgs e)
        {
            Tablica_Klijenti.Rows.Clear();
            klijenti = SqliteDataAccess.UcitajKlijentePoRijeci(Input_Pretrazi.Text);

            foreach (var klijent in klijenti)
            {
                Tablica_Klijenti.Rows.Insert(0, klijent.Sifra, klijent.Ime, klijent.Adresa, klijent.Posta, klijent.Oib, klijent.Telefon, klijent.Mail, klijent.Dodatno);
            }

            Tablica_Klijenti.ClearSelection();
        }
    }
}
