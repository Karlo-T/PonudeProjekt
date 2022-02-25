using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudeProjekt
{
    public partial class Form_Ponude : Form
    {
        #region Varijable
        string lokacijaPonuda = "";
        string selektiranaPonuda = "";
        Form_Main main;

        List<Control> shadowControls = new List<Control>();
        List<PonudeModel> ponude = new List<PonudeModel>();
        string nl = Environment.NewLine;

        Bitmap shadowBmp = null;
        #endregion

        public Form_Ponude(Form_Main frm)
        {
            InitializeComponent();

            main = frm;

            //Stavljanje sijene na panele
            shadowControls.Add(Panel_Ponude);
            this.Refresh();
        }

        
        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest)
        {
            //Sijena
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

        private void Form_Ponude_Shown(object sender, EventArgs e)
        {
            int x = Tablica_Ponude.Width - 370;
            x = x / 2;
            Tablica_Ponude.Columns[2].Width = x - 17;
            Tablica_Ponude.Columns[3].Width = x;
        }

        private void Form_Ponude_Load(object sender, EventArgs e)
        {
            UcitajPonude();

            //Ucitavanje postavki iz baze podataka
            List<PostavkeModel> postavke = SqliteDataAccess.UcitajPostavke();
            foreach (var item in postavke)
            {
                lokacijaPonuda = item.SaveLocation;
            }
        }

        private void Tablica_Ponude_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selektiranaPonuda = Tablica_Ponude.Rows[e.RowIndex].Cells[1].Value.ToString();
                axAcroPDF1.src = lokacijaPonuda + "\\" + selektiranaPonuda + ".pdf#toolbar=0";
                axAcroPDF1.setView("Fit");
            }
        }

        private void Input_Pretrazi_TextChanged(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("ok.pdf");
            ponude = SqliteDataAccess.UcitajPonudePoRijeci(Input_Pretrazi.Text);

            Tablica_Ponude.Rows.Clear();
            foreach (var ponuda in ponude)
            {
                Tablica_Ponude.Rows.Insert(0, ponuda.Datum, ponuda.BrojPonude, ponuda.Klijent, ponuda.Naslov, ponuda.Osnovica, ponuda.Iznos);
            }
            Tablica_Ponude.ClearSelection();
            selektiranaPonuda = "";
        }

        private void Button_Print_Click(object sender, EventArgs e)
        {
            PrintPDF("HPB4FC99 (HP OfficeJet Pro 7740 series)", "A4", lokacijaPonuda + "\\" + selektiranaPonuda + ".pdf", 1);
        }

        public bool PrintPDF(string printer, string paperName, string filename, int copies){
            try
            {
                // Create the printer settings for our printer
                var printerSettings = new PrinterSettings
                {
                    PrinterName = printer,
                    Copies = (short)copies,
                };

                // Create our page settings for the paper size selected
                var pageSettings = new PageSettings(printerSettings)
                {
                    Margins = new Margins(0, 0, 0, 0),
                };
                foreach (PaperSize paperSize in printerSettings.PaperSizes)
                {
                    if (paperSize.PaperName == paperName)
                    {
                        pageSettings.PaperSize = paperSize;
                        break;
                    }
                }

                // Now print the PDF document
                using (var document = PdfDocument.Load(filename))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrinterSettings = printerSettings;
                        printDocument.DefaultPageSettings = pageSettings;
                        printDocument.PrintController = new StandardPrintController();
                        printDocument.Print();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
         
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (selektiranaPonuda != "")
            {
                main.UrediPonudu(selektiranaPonuda);
            }
            else
            {
                MessageBox.Show("Nije odabrana niti jedna ponuda.", "Uredjivanje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (selektiranaPonuda != "")
            {
                if (MessageBox.Show("Želite li izbrisati ponudu broj " + selektiranaPonuda + "?", "Brisanje ponude", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string brojNovePonude = "";
                    SqliteDataAccess.IzbrisiPonudu(selektiranaPonuda);
                    File.Delete(lokacijaPonuda + "\\" + selektiranaPonuda + ".pdf");

                    //Ucitavanje postavki iz baze
                    List<PostavkeModel> postavke = new List<PostavkeModel>();
                    postavke = SqliteDataAccess.UcitajPostavke();
                    foreach (var item in postavke)
                    {
                        brojNovePonude = item.BrojPonude.ToString();
                    }

                    if ((Convert.ToInt32(brojNovePonude) - 1) == Convert.ToInt32(selektiranaPonuda))
                    {
                        SqliteDataAccess.AzurirajBrojPonudeBrisanje(Convert.ToInt32(selektiranaPonuda));
                    }

                    axAcroPDF1.LoadFile("OK.pdf");
                    UcitajPonude();
                }
            }
            else
            {
                MessageBox.Show("Nije odabrana niti jedna ponuda.", "Brisanje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_Nova_Click(object sender, EventArgs e)
        {
            if (selektiranaPonuda != "")
            {
                main.NovaPonudaTemeljemPonude(selektiranaPonuda);
            }
            else
            {
                MessageBox.Show("Nije odabrana niti jedna ponuda.", "Izradi novu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UcitajPonude()
        {
            ponude = SqliteDataAccess.UcitajPonude();

            Tablica_Ponude.Rows.Clear();
            foreach (var ponuda in ponude)
            {
                Tablica_Ponude.Rows.Insert(0, ponuda.Datum, ponuda.BrojPonude, ponuda.Klijent, ponuda.Naslov, ponuda.Osnovica, ponuda.Iznos, ponuda.SifraKlijenta);
            }

            Tablica_Ponude.ClearSelection();
            selektiranaPonuda = "";
            Tablica_Ponude.Sort(Tablica_Ponude.Columns[1], ListSortDirection.Descending);
        }
    }
}
