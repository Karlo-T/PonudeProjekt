using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace PonudeProjekt
{
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR");
        }

        private void Card_Load(object sender, EventArgs e)
        {

            this.Height = 93;



            textBox2.Location = new Point(this.Width - 125, this.Height - 44);
            textBox2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            textBox2.Width = 120;
            textBox2.Height = 29;

            textBox1.Text = "Opis stavke";
            textBox2.Text = "0,00";
            textBox1.ScrollBars = ScrollBars.None;

            panel1.Height = 10;

            button1.Width = 26;
            button1.Height = 26;

            textBox1.Width = this.Width - 205;
            textBox1.Height = this.Height - 20;

            button1.Location = new Point(this.Width - 31, 5);
            button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int textSize = TextRenderer.MeasureText(textBox1.Text,
                textBox1.Font,
                new Size(textBox1.ClientSize.Width, 1000),
                TextFormatFlags.WordBreak
            ).Height + 10;

            if(textSize >= 73)
            {
                textBox1.Height = textSize;
                this.Height = textBox1.Height + 20;
            }
            else
            {
                textBox1.Height = 73;
                this.Height = 93;
            }

            

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da želite obrisati odabranu stavku?", "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Controls.Remove(this);
                this.Dispose();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' && textBox2.Text.Contains(',')) { e.Handled = true; }

            if(char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            {
                if (Regex.IsMatch(textBox2.Text, "^\\d*\\,\\d{2}$")) { e.Handled = true; }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                decimal unos = Convert.ToDecimal(textBox2.Text);
                textBox2.Text = unos.ToString("0,0.00");
            }
            else
            {
                textBox2.Text = "0,00";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == "0,00")
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Opis stavke";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Opis stavke")
            {
                textBox1.Text = "";
            }
        }
    }
}
