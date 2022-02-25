using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudeProjekt
{
    public partial class Form_Nova_Ponuda : Form
    {
        #region Varijable
        //Podaci o ponudi
        string lokacijaPonuda = "";
        string brojPonude = "";
        string datum = "";
        string naslov = "";
        string kupacIme = "";
        string kupacAdresa = "";
        string kupacPosta = "";
        string kupacOib = "";
        string kupacDodatno = "";
        string napomena = "";
        int rabatPostotak = 0;
        double ukupno = 0;
        double rabatIznos = 0;
        double osnovica = 0;
        double pdv = 0;
        double iznosZaPlatiti = 0;
        List<Stavka> stavke = new List<Stavka>();

        //Varijable za kreiranje PDF dokumenta
        int stranica = 1;
        int brojStranica = 1;
        int last_size = 0;
        int y_cord = 0;
        int brojStavki = 0;
        int preostaliBrojStavki = 0;
        int Index = 0;
        bool IZNOS = false;

        int SIFRA_KLIJENTA = 0;
        List<KlijentModel> klijenti = new List<KlijentModel>();
        bool NOVI_KLIJENT = false;

        // Sijene
        List<Control> shadowControlsL = new List<Control>();
        List<Control> shadowControlsD = new List<Control>();
        Bitmap shadowBmp = null;
        #endregion

        class Stavka
        {
            public string opis { get; set; }
            public string cijena { get; set; }
        }

        public Form_Nova_Ponuda()
        {
            InitializeComponent();
        }

        private void Form_Nova_Ponuda_Load(object sender, EventArgs e)
        {
            //Ucitavanje postavki iz baze podataka
            List<PostavkeModel> postavke = SqliteDataAccess.UcitajPostavke();
            foreach (var item in postavke)
            {
                brojPonude = item.BrojPonude.ToString();
                lokacijaPonuda = item.SaveLocation;
            }

            //Postavljanje danasnjeg datuma i broja ponude
            Input_Datum.Text = DateTime.Now.ToString("dd.MM.yyyy");
            Text_Ponuda.Text = "Broj ponude:  " + brojPonude;
        }

        private void Button_Ponisti_Click(object sender, EventArgs e)
        {
            //Obavijest da ponuda neće biti spremljena
            if (MessageBox.Show("Jeste li sigurni da želite poništiti ponudu? Ponuda NEĆE biti spremljena!", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Button_Dodaj_Stavku_Click(object sender, EventArgs e)
        {
            //Kreiranje i dodavanje nove stavke 
            Card c2 = new Card();
            c2.Dock = DockStyle.Top;
            Panel_Tablica.Controls.Add(c2);
            c2.BringToFront();
        }

        private void Button_Spremi_Click(object sender, EventArgs e)
        {
            #region Stavljanje podataka u varijable
            datum = Input_Datum.Text;
            naslov = Input_Naslov.Text;
            kupacIme = Input_ImePrezimeNaziv.Text;
            kupacAdresa = Input_Adresa.Text;
            kupacPosta = Input_Posta.Text;
            kupacOib = Input_Oib.Text;
            kupacDodatno = Input_Dodatno.Text;
            napomena = Input_Napomena.Text;

            if (Input_Rabat.Text != "")
            {
                rabatPostotak = Convert.ToInt32(Input_Rabat.Text);
            }
            else
            {
                rabatPostotak = 0;
            }

            brojStavki = 0;
            stavke.Clear();
            // Zbrajanje stavki i stavljanje opisa i cijene svih stavki u listu
            foreach (Control c in Panel_Tablica.Controls.Cast<Control>())
            {
                brojStavki++;
                preostaliBrojStavki = brojStavki;

                string tmpOpis = "";
                string tmpCijena = "";

                foreach (TextBox t in c.Controls.OfType<TextBox>())
                {
                    if (t.Tag.ToString() == "stavka")
                    {
                        tmpOpis = t.Text;
                    }
                    else if (t.Tag.ToString() == "cijena")
                    {
                        tmpCijena = t.Text;
                        double d = Convert.ToDouble(t.Text);
                        ukupno += d;
                    }
                };

                stavke.Insert(0, new Stavka { opis = tmpOpis, cijena = tmpCijena });
            };

            if (rabatPostotak != 0)
            {
                rabatIznos = ukupno * rabatPostotak / 100;
                osnovica = ukupno - rabatIznos;
            }
            else
            {
                rabatIznos = 0;
                osnovica = ukupno;
            }

            pdv = osnovica * 25 / 100;
            iznosZaPlatiti = osnovica + pdv;
            #endregion

            #region Izvršavanje provjere
            if(Input_ImePrezimeNaziv.Text == "")
            {
                if (MessageBox.Show("Niste upisali podatke o klijentu! Želite li spremiti ponudu bez podataka o klijentu?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            int i = 0;
            foreach(var stavka in stavke)
            {
                i++;
                if(stavka.opis == "Opis stavke")
                {
                    MessageBox.Show("Sadržaj stavke " + i + " nije promijenjen! Molim vas promijenite sadržaj ili izbrišite navedenu stavku.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (stavka.cijena == "0,00")
                {
                    MessageBox.Show("Cijena stavke " + i + " nije unesena! Molim vas unesite cijenu stavke.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            #endregion

            #region kreiranje i spremanje novog klijenta
            if (NOVI_KLIJENT)
            {
                KlijentModel km = new KlijentModel();
                km.Ime = kupacIme;
                km.Adresa = kupacAdresa;
                km.Posta = kupacPosta;
                km.Oib = kupacOib;
                km.Dodatno = kupacDodatno;
                km.Telefon = "";
                km.Mail = "";

                SqliteDataAccess.DodajKlijenta(km);
                klijenti = SqliteDataAccess.UcitajKlijente();
                SIFRA_KLIJENTA = klijenti[klijenti.Count - 1].Sifra;
            }
            #endregion

            #region Spremanje podataka u bazu podataka
            SpremiPonudu();
            #endregion

            #region Pokretanje kreiranja PDF dokumenta
            stranica = 1;
            IEnumerable<PaperSize> paperSizes = printDocument1.PrinterSettings.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
            printDocument1.DefaultPageSettings.PaperSize = sizeA4;
            printDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument1.PrinterSettings.PrintToFile = true;
            printDocument1.PrinterSettings.PrintFileName = lokacijaPonuda + "\\" + brojPonude + ".pdf";
            printDocument1.Print();
            #endregion
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region Kod za kreiranje PDF dokumenta sa svim podacima
            //Kreiranje Fontova, Brusheva i Formatiranja
            Font logo = new Font("Calibri", 28, FontStyle.Bold | FontStyle.Italic);
            Font tekst = new Font("Calibri", 12, FontStyle.Regular);
            Font podebljano = new Font("Calibri", 12, FontStyle.Bold);
            Font naslov = new Font("Calibri", 20, FontStyle.Bold);
            Font iznos = new Font("Calibri", 14, FontStyle.Bold);

            SolidBrush logo_Brush = new SolidBrush(Color.FromArgb(79, 129, 189));
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush ispuna = new SolidBrush(Color.LightGray);

            StringFormat format_desno = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat format_sredina = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat format_unutar = new StringFormat() { Trimming = StringTrimming.EllipsisWord };

            // Margine A4 stranice
            int START_X = 40;
            int START_Y = 40;
            int END_X = 787;
            int END_Y = 1130;
            int SREDINA = 414;

            var rect = new RectangleF(0, START_Y + 140, END_X + 40, 35);

            //Racunanje ukupnog broja stranica
            if (stranica == 1)
            {
                y_cord = START_Y + 393;
                for (int i = 0; i < brojStavki; i++)
                {
                    string opis = stavke[i].opis;

                    SizeF stringSize = new SizeF();
                    stringSize = e.Graphics.MeasureString(opis, tekst, SREDINA + 90);
                    last_size = (int)stringSize.Height;

                    y_cord = y_cord + last_size + 26;

                    if (y_cord > 1100)
                    {
                        y_cord = START_Y + 170;
                        brojStranica++;
                    }
                }
                y_cord -= 16;
                if (y_cord > 999)
                {
                    y_cord = START_Y + 170;
                    brojStranica++;
                }
                if (napomena != "")
                {
                    string measureString2 = napomena;
                    int stringWidth2 = 550;
                    SizeF stringSize2 = e.Graphics.MeasureString(measureString2, tekst, stringWidth2);

                    if ((y_cord + 163 + stringSize2.Height) > 1100)
                    {
                        y_cord = START_Y + 30;
                        brojStranica++;
                    }
                }
                y_cord = 0;
            }


            // Zaglavlje lijevo
            DrawSpacedText(e.Graphics, logo, logo_Brush, new Point(START_X - 5, START_Y), "OBRT          TRUPKOVIĆ", 330);
            e.Graphics.DrawString("Obrt za proizvodnju i montažu metalnih konstrukcija", tekst, brush, new Point(START_X, START_Y + 45));
            e.Graphics.DrawString("vl. Dragutin Trupković", podebljano, brush, new Point(START_X, START_Y + 65));

            //Zaglavlje desno
            rect = new RectangleF(END_X - 260, START_Y + 4, 260, 85);
            e.Graphics.DrawString("Preloge 18, Ivanovec" + "\r\n" + "40000 Čakovec, Hrvatska" + "\r\n" + "Mob. +385 (0) 98 212 258" + "\r\n" + "drago.trupkovic@gmail.com", tekst, brush, rect, format_desno);

            if (stranica == 1)
            {
                //Naslov
                rect = new RectangleF(0, START_Y + 140, END_X + 40, 35);
                e.Graphics.DrawString("PONUDA BR: " + brojPonude.ToString(), naslov, brush, rect, format_sredina);

                //Podaci ponude
                e.Graphics.FillRectangle(ispuna, new Rectangle(START_X, START_Y + 210, END_X - 40, 25));
                e.Graphics.DrawString("Datum ponude:", podebljano, brush, new Point(START_X + 5, START_Y + 213));
                e.Graphics.DrawString("Kupac:", podebljano, brush, new Point(SREDINA + 5, START_Y + 213));

                var rectt = new Rectangle(SREDINA, START_Y + 232, SREDINA - 42, 110);
                e.Graphics.DrawRectangle(new Pen(Color.LightGray, 2), rectt);

                e.Graphics.DrawString(datum, tekst, brush, new Point(START_X + 5, START_Y + 237));
                rect = new RectangleF(SREDINA + 5, START_Y + 237, 372, 105);
                e.Graphics.DrawString(kupacIme + "\r\n" + kupacAdresa + "\r\n" + kupacPosta + "\r\n" + kupacOib + "\r\n" + kupacDodatno, tekst, brush, rect, format_unutar);

                //Stavke --- Naslov
                e.Graphics.FillRectangle(ispuna, new Rectangle(START_X, START_Y + 364, END_X - 40, 25));
                e.Graphics.DrawString("Opis:", podebljano, brush, new Point(START_X + 5, START_Y + 367));
                rect = new RectangleF(END_X - SREDINA, START_Y + 367, SREDINA - 5, 20);
                e.Graphics.DrawString("Cijena:", podebljano, brush, rect, format_desno);

                last_size = 0;
                y_cord = START_Y + 393;
            }

            //Broj stranica na dnu stranice
            rect = new RectangleF(0, START_Y + 1090, END_X + 40, 25);
            e.Graphics.DrawString("stranica " + stranica + "/" + brojStranica, tekst, brush, rect, format_sredina);

            //Stavke
            for (int i = 0; i < preostaliBrojStavki; i++)
            {
                string opis = stavke[Index].opis;
                string cijena = stavke[Index].cijena;

                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(opis, tekst, SREDINA + 90);

                //Opis
                StringFormat format1 = new StringFormat();
                format1.Trimming = StringTrimming.EllipsisWord;
                e.Graphics.DrawString(opis, tekst, brush, new RectangleF(START_X + 5, y_cord, stringSize.Width, stringSize.Height), format1);

                //Cijena
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(cijena, tekst, brush, new RectangleF(SREDINA, y_cord, SREDINA - 45, stringSize.Height), sf);

                last_size = (int)stringSize.Height;

                y_cord = y_cord + last_size + 26;
                Index++;

                if (y_cord > 1100)
                {
                    preostaliBrojStavki -= (i + 1);
                    last_size = 0;
                    y_cord = START_Y + 170;

                    stranica++;
                    e.HasMorePages = true;
                    return;
                }
            }
            preostaliBrojStavki = 0;

            // Podaci o iznosu
            y_cord -= 16;
            if (y_cord > 999)
            {
                y_cord = START_Y + 170;
                stranica++;
                e.HasMorePages = true;
                return;
            }
            else
            {
                if (!IZNOS)
                {
                    e.Graphics.DrawLine(new Pen(Color.LightGray, 2), SREDINA, y_cord, END_X, y_cord);

                    e.Graphics.DrawString("Ukupno:" + "\r\n" + "Rabat(" + rabatPostotak + "%):" + "\r\n" + "Osnovica:" + "\r\n" + "PDV:", tekst, brush, new Point(SREDINA + 5, y_cord + 3));

                    e.Graphics.DrawString(ukupno.ToString("0,0.00") + "\r\n" + rabatIznos.ToString("0,0.00") + "\r\n" + osnovica.ToString("0,0.00") + "\r\n" + pdv.ToString("0,0.00"), tekst, brush, new RectangleF(SREDINA + 5, y_cord + 3, SREDINA - 50, 80), format_desno);

                    e.Graphics.FillRectangle(ispuna, new Rectangle(SREDINA, y_cord + 85, SREDINA - 40, 25));

                    e.Graphics.DrawString("Iznos za platiti (kn):", podebljano, brush, new Point(SREDINA + 5, y_cord + 88));
                    rect = new RectangleF(START_X, y_cord + 88, END_X - 45, 20);
                    e.Graphics.DrawString(iznosZaPlatiti.ToString("0,0.00"), podebljano, brush, rect, format_desno);

                    IZNOS = true;
                }
            }

            //Napomena
            if (napomena != "")
            {
                string measureString2 = napomena;
                int stringWidth2 = 550;
                SizeF stringSize2 = e.Graphics.MeasureString(measureString2, tekst, stringWidth2);

                if ((y_cord + 163 + stringSize2.Height) > 1100)
                {
                    y_cord = START_Y + 30;
                    stranica++;
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    //Napomena
                    e.Graphics.DrawString("Napomena:", podebljano, brush, new Point(START_X + 5, y_cord + 140));

                    StringFormat format2 = new StringFormat();
                    format2.Trimming = StringTrimming.EllipsisWord;
                    e.Graphics.DrawString(measureString2, tekst, brush, new RectangleF(START_X + 5, y_cord + 163, stringSize2.Width, stringSize2.Height), format2);
                }
            }
            #endregion
        }

        private void SpremiPonudu()
        {
            PonudeModel p = new PonudeModel
            {
                BrojPonude = Convert.ToInt32(brojPonude),
                Datum = Input_Datum.Text,
                Naslov = Input_Naslov.Text,
                Klijent = Input_ImePrezimeNaziv.Text,
                Adresa = Input_Adresa.Text,
                Posta = Input_Posta.Text,
                Oib = Input_Oib.Text,
                Dodatno = Input_Dodatno.Text,
                Napomena = Input_Napomena.Text,
                Ukupno = ukupno.ToString("0,0.00"),
                Osnovica = osnovica.ToString("0,0.00"),
                Rabat = rabatPostotak.ToString(),
                PDV = pdv.ToString("0,0.00"),
                Iznos = iznosZaPlatiti.ToString("0,0.00"),
                SifraKlijenta = SIFRA_KLIJENTA
            };

            SqliteDataAccess.SpremiPonudu(p);

            DetaljiPonudeModel d = new DetaljiPonudeModel();

            for (var i = 0; i < stavke.Count; i++)
            {
                d.BrojPonude = Convert.ToInt32(brojPonude);
                d.Opis = stavke[i].opis;
                d.Cijena = stavke[i].cijena;

                SqliteDataAccess.SpremiDetaljePonude(d);
            }

            SqliteDataAccess.AzurirajBrojPonude(Convert.ToInt32(brojPonude));

            this.Close();
        }

        private void Layout_Left_Paint(object sender, PaintEventArgs e)
        {
            //crtanje sijene
            if (shadowBmp == null || shadowBmp.Size != this.Size)
            {
                shadowBmp?.Dispose();
                shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            }
            foreach (Control control in shadowControlsL)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddRectangle(new Rectangle(control.Location.X, control.Location.Y, control.Size.Width, control.Size.Height));
                    DrawShadowSmooth(gp, 25, 20, shadowBmp);
                }
                e.Graphics.DrawImage(shadowBmp, new Point(0, 0));
            }
        }

        private void Layout_Right_Paint(object sender, PaintEventArgs e)
        {
            //crtanje sijene
            if (shadowBmp == null || shadowBmp.Size != this.Size)
            {
                shadowBmp?.Dispose();
                shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            }
            foreach (Control control in shadowControlsD)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddRectangle(new Rectangle(control.Location.X, control.Location.Y, control.Size.Width, control.Size.Height));
                    DrawShadowSmooth(gp, 25, 20, shadowBmp);
                }
                e.Graphics.DrawImage(shadowBmp, new Point(0, 0));
            }
        }

        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest)
        {
            //sijena
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

        public void DrawSpacedText(Graphics g, Font font, Brush brush, PointF point, string text, int desiredWidth)
        {
            //Tekst s vecim razmakom
            //Calculate spacing
            float widthNeeded = 0;
            foreach (char c in text)
            {
                widthNeeded += g.MeasureString(c.ToString(), font).Width;
            }
            float spacing = (desiredWidth - widthNeeded) / (text.Length - 1);

            //draw text
            float indent = 0;
            foreach (char c in text)
            {
                g.DrawString(c.ToString(), font, brush, new PointF(point.X + indent, point.Y));
                indent += g.MeasureString(c.ToString(), font).Width + spacing;
            }
        }

        private void Form_Nova_Ponuda_Shown(object sender, EventArgs e)
        {
            //Stavljanje sijene na panele
            shadowControlsL.Add(Panel_PonudaInfo);
            shadowControlsL.Add(Panel_KlijentInfo);
            shadowControlsL.Add(Panel_CijenaInfo);
            shadowControlsD.Add(Panel_Napomena);
            shadowControlsD.Add(Panel_Stavke);
            this.Refresh();

            //Skrol na tablici sa stavkama
            Panel_Tablica.HorizontalScroll.Maximum = 0;
            Panel_Tablica.AutoScroll = false;
            Panel_Tablica.HorizontalScroll.Visible = false;
            Panel_Tablica.AutoScroll = true;

            //Dodavanje prve stavke
            Card c2 = new Card();
            c2.Dock = DockStyle.Top;
            Panel_Tablica.Controls.Add(c2);
            c2.BringToFront();
        }

        private void btnUcitajKlijenta_Click(object sender, EventArgs e)
        {
            KlijentModel k = new KlijentModel();

            using(Form_Klijenti_Lista frm = new Form_Klijenti_Lista())
            {
                frm.ShowDialog();
                k = Form_Klijenti_Lista.kli;

                SIFRA_KLIJENTA = k.Sifra;
                Input_ImePrezimeNaziv.Text = k.Ime;
                Input_Adresa.Text = k.Adresa;
                Input_Posta.Text = k.Posta;
                Input_Oib.Text = k.Oib;
                Input_Dodatno.Text = k.Dodatno;

                NOVI_KLIJENT = false;
                Input_ImePrezimeNaziv.BackColor = Color.WhiteSmoke;
                Input_Adresa.BackColor = Color.WhiteSmoke;
                Input_Posta.BackColor = Color.WhiteSmoke;
                Input_Oib.BackColor = Color.WhiteSmoke;
                Input_Dodatno.BackColor = Color.WhiteSmoke;
            }
        }

        private void Input_ImePrezimeNaziv_KeyPress(object sender, KeyPressEventArgs e)
        {
            NOVI_KLIJENT = true;
            Input_ImePrezimeNaziv.BackColor = Color.FromArgb(192, 255, 192);
            Input_Adresa.BackColor = Color.FromArgb(192, 255, 192);
            Input_Posta.BackColor = Color.FromArgb(192, 255, 192);
            Input_Oib.BackColor = Color.FromArgb(192, 255, 192);
            Input_Dodatno.BackColor = Color.FromArgb(192, 255, 192);
        }
    }
}
