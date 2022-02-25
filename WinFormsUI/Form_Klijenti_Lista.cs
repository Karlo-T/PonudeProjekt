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
    public partial class Form_Klijenti_Lista : Form
    {
        public static KlijentModel kli = new KlijentModel();
        List<KlijentModel> klijenti = new List<KlijentModel>();

        List<Control> shadowControls = new List<Control>();
        Bitmap shadowBmp = null;

        public Form_Klijenti_Lista()
        {
            InitializeComponent();
            kli = new KlijentModel();

            //Stavljanje sijene na panele
            shadowControls.Add(Panel_Klijenti);
            this.Refresh();
        }

        private void Form_Klijenti_Lista_Shown(object sender, EventArgs e)
        {
            int x = dataGridView1.Width-20;
            x = x / 5;
            dataGridView1.Columns[0].Width = x;
            dataGridView1.Columns[1].Width = x;
            dataGridView1.Columns[2].Width = x;
            dataGridView1.Columns[3].Width = x;
            dataGridView1.Columns[4].Width = x;
        }

        private void Form_Klijenti_Lista_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            klijenti = SqliteDataAccess.UcitajKlijente();

            foreach (var klijent in klijenti)
            {
                dataGridView1.Rows.Insert(0, klijent.Ime, klijent.Adresa, klijent.Posta, klijent.Oib, klijent.Dodatno, klijent.Sifra);
            }

            dataGridView1.ClearSelection();
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

        private void Form_Klijenti_Lista_Paint(object sender, PaintEventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                kli.Sifra = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                kli.Ime = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                kli.Adresa = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                kli.Posta = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                kli.Oib = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                kli.Dodatno = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }

            this.Close();
        }

        private void Input_Pretrazi_TextChanged(object sender, EventArgs e)
        {
            klijenti = SqliteDataAccess.UcitajKlijentePoRijeci(Input_Pretrazi.Text);

            dataGridView1.Rows.Clear();
            foreach (var klijent in klijenti)
            {
                dataGridView1.Rows.Insert(0, klijent.Ime, klijent.Adresa, klijent.Posta, klijent.Oib, klijent.Dodatno, klijent.Sifra);
            }

            dataGridView1.ClearSelection();
        }
    }
}
