namespace PonudeProjekt
{
    partial class Form_Postavke
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_lokacija = new System.Windows.Forms.Label();
            this.Input_Lokacija_Spremanja = new System.Windows.Forms.TextBox();
            this.Button_Spremi = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.Label();
            this.Button_Odaberi = new System.Windows.Forms.Button();
            this.txt_spremljeno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_lokacija
            // 
            this.txt_lokacija.AutoSize = true;
            this.txt_lokacija.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lokacija.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txt_lokacija.Location = new System.Drawing.Point(29, 94);
            this.txt_lokacija.Name = "txt_lokacija";
            this.txt_lokacija.Size = new System.Drawing.Size(224, 21);
            this.txt_lokacija.TabIndex = 3;
            this.txt_lokacija.Text = "Lokacija spremanja ponuda:";
            // 
            // Input_Lokacija_Spremanja
            // 
            this.Input_Lokacija_Spremanja.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Input_Lokacija_Spremanja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_Lokacija_Spremanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Lokacija_Spremanja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Input_Lokacija_Spremanja.Location = new System.Drawing.Point(30, 120);
            this.Input_Lokacija_Spremanja.Name = "Input_Lokacija_Spremanja";
            this.Input_Lokacija_Spremanja.Size = new System.Drawing.Size(633, 26);
            this.Input_Lokacija_Spremanja.TabIndex = 6;
            // 
            // Button_Spremi
            // 
            this.Button_Spremi.BackColor = System.Drawing.Color.Green;
            this.Button_Spremi.FlatAppearance.BorderSize = 0;
            this.Button_Spremi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Spremi.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Spremi.ForeColor = System.Drawing.Color.White;
            this.Button_Spremi.Location = new System.Drawing.Point(30, 184);
            this.Button_Spremi.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Button_Spremi.Name = "Button_Spremi";
            this.Button_Spremi.Size = new System.Drawing.Size(103, 35);
            this.Button_Spremi.TabIndex = 7;
            this.Button_Spremi.Text = "Spremi";
            this.Button_Spremi.UseVisualStyleBackColor = false;
            this.Button_Spremi.Click += new System.EventHandler(this.Button_Spremi_Click);
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txt.Location = new System.Drawing.Point(28, 32);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(106, 30);
            this.txt.TabIndex = 8;
            this.txt.Text = "Postavke";
            // 
            // Button_Odaberi
            // 
            this.Button_Odaberi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(148)))), ((int)(((byte)(210)))));
            this.Button_Odaberi.FlatAppearance.BorderSize = 0;
            this.Button_Odaberi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Odaberi.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Odaberi.ForeColor = System.Drawing.Color.White;
            this.Button_Odaberi.Location = new System.Drawing.Point(678, 119);
            this.Button_Odaberi.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Button_Odaberi.Name = "Button_Odaberi";
            this.Button_Odaberi.Size = new System.Drawing.Size(90, 29);
            this.Button_Odaberi.TabIndex = 9;
            this.Button_Odaberi.Text = "Odaberi";
            this.Button_Odaberi.UseVisualStyleBackColor = false;
            this.Button_Odaberi.Click += new System.EventHandler(this.Button_Odaberi_Click);
            // 
            // txt_spremljeno
            // 
            this.txt_spremljeno.AutoSize = true;
            this.txt_spremljeno.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_spremljeno.ForeColor = System.Drawing.Color.Green;
            this.txt_spremljeno.Location = new System.Drawing.Point(141, 191);
            this.txt_spremljeno.Name = "txt_spremljeno";
            this.txt_spremljeno.Size = new System.Drawing.Size(154, 21);
            this.txt_spremljeno.TabIndex = 10;
            this.txt_spremljeno.Text = "Spremanje uspješno.";
            this.txt_spremljeno.Visible = false;
            // 
            // Form_Postavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 543);
            this.Controls.Add(this.txt_spremljeno);
            this.Controls.Add(this.Button_Odaberi);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.Button_Spremi);
            this.Controls.Add(this.Input_Lokacija_Spremanja);
            this.Controls.Add(this.txt_lokacija);
            this.Name = "Form_Postavke";
            this.Text = "Form_Postavke";
            this.Load += new System.EventHandler(this.Form_Postavke_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txt_lokacija;
        private System.Windows.Forms.TextBox Input_Lokacija_Spremanja;
        private System.Windows.Forms.Button Button_Spremi;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Button Button_Odaberi;
        private System.Windows.Forms.Label txt_spremljeno;
    }
}