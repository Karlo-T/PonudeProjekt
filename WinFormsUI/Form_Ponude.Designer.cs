namespace PonudeProjekt
{
    partial class Form_Ponude
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Ponude));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Ponude = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Tablica_Ponude = new System.Windows.Forms.DataGridView();
            this.datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.broj_ponude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iznos_no_pdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iznos_pdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Button_Nova = new System.Windows.Forms.Button();
            this.Button_Print = new System.Windows.Forms.Button();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Input_Pretrazi = new System.Windows.Forms.TextBox();
            this.Text_Pretrazi = new System.Windows.Forms.Label();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel_Ponude.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tablica_Ponude)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel1.Controls.Add(this.Panel_Ponude, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.axAcroPDF1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1558, 748);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Panel_Ponude
            // 
            this.Panel_Ponude.BackColor = System.Drawing.Color.White;
            this.Panel_Ponude.Controls.Add(this.panel5);
            this.Panel_Ponude.Controls.Add(this.panel1);
            this.Panel_Ponude.Controls.Add(this.panel4);
            this.Panel_Ponude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Ponude.Location = new System.Drawing.Point(10, 10);
            this.Panel_Ponude.Margin = new System.Windows.Forms.Padding(10);
            this.Panel_Ponude.Name = "Panel_Ponude";
            this.Panel_Ponude.Size = new System.Drawing.Size(883, 728);
            this.Panel_Ponude.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Tablica_Ponude);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 52);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(883, 676);
            this.panel5.TabIndex = 5;
            // 
            // Tablica_Ponude
            // 
            this.Tablica_Ponude.AllowUserToAddRows = false;
            this.Tablica_Ponude.AllowUserToDeleteRows = false;
            this.Tablica_Ponude.AllowUserToResizeRows = false;
            this.Tablica_Ponude.BackgroundColor = System.Drawing.Color.White;
            this.Tablica_Ponude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tablica_Ponude.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Tablica_Ponude.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(148)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(148)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tablica_Ponude.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Tablica_Ponude.ColumnHeadersHeight = 50;
            this.Tablica_Ponude.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Tablica_Ponude.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datum,
            this.broj_ponude,
            this.klijent,
            this.naslov,
            this.iznos_no_pdv,
            this.iznos_pdv});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Tablica_Ponude.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tablica_Ponude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tablica_Ponude.EnableHeadersVisualStyles = false;
            this.Tablica_Ponude.Location = new System.Drawing.Point(10, 10);
            this.Tablica_Ponude.MultiSelect = false;
            this.Tablica_Ponude.Name = "Tablica_Ponude";
            this.Tablica_Ponude.ReadOnly = true;
            this.Tablica_Ponude.RowHeadersVisible = false;
            this.Tablica_Ponude.RowTemplate.Height = 45;
            this.Tablica_Ponude.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tablica_Ponude.Size = new System.Drawing.Size(863, 656);
            this.Tablica_Ponude.TabIndex = 0;
            this.Tablica_Ponude.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tablica_Ponude_CellClick);
            // 
            // datum
            // 
            this.datum.HeaderText = "Datum";
            this.datum.Name = "datum";
            this.datum.ReadOnly = true;
            // 
            // broj_ponude
            // 
            this.broj_ponude.HeaderText = "Broj";
            this.broj_ponude.Name = "broj_ponude";
            this.broj_ponude.ReadOnly = true;
            this.broj_ponude.Width = 70;
            // 
            // klijent
            // 
            this.klijent.HeaderText = "Klijent";
            this.klijent.Name = "klijent";
            this.klijent.ReadOnly = true;
            // 
            // naslov
            // 
            this.naslov.HeaderText = "Naslov";
            this.naslov.Name = "naslov";
            this.naslov.ReadOnly = true;
            // 
            // iznos_no_pdv
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iznos_no_pdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.iznos_no_pdv.HeaderText = "Iznos bez PDV-a";
            this.iznos_no_pdv.Name = "iznos_no_pdv";
            this.iznos_no_pdv.ReadOnly = true;
            // 
            // iznos_pdv
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iznos_pdv.DefaultCellStyle = dataGridViewCellStyle3;
            this.iznos_pdv.HeaderText = "Iznos s PDV-om";
            this.iznos_pdv.Name = "iznos_pdv";
            this.iznos_pdv.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 2);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Button_Nova);
            this.panel4.Controls.Add(this.Button_Print);
            this.panel4.Controls.Add(this.Button_Edit);
            this.panel4.Controls.Add(this.Button_Delete);
            this.panel4.Controls.Add(this.Input_Pretrazi);
            this.panel4.Controls.Add(this.Text_Pretrazi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(883, 50);
            this.panel4.TabIndex = 4;
            // 
            // Button_Nova
            // 
            this.Button_Nova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Nova.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Nova.BackgroundImage")));
            this.Button_Nova.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_Nova.FlatAppearance.BorderSize = 0;
            this.Button_Nova.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Nova.Location = new System.Drawing.Point(698, 5);
            this.Button_Nova.Name = "Button_Nova";
            this.Button_Nova.Size = new System.Drawing.Size(40, 40);
            this.Button_Nova.TabIndex = 11;
            this.Button_Nova.UseVisualStyleBackColor = true;
            this.Button_Nova.Click += new System.EventHandler(this.Button_Nova_Click);
            // 
            // Button_Print
            // 
            this.Button_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Print.BackgroundImage = global::PonudeProjekt.Properties.Resources.print;
            this.Button_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_Print.FlatAppearance.BorderSize = 0;
            this.Button_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Print.Location = new System.Drawing.Point(744, 5);
            this.Button_Print.Name = "Button_Print";
            this.Button_Print.Size = new System.Drawing.Size(40, 40);
            this.Button_Print.TabIndex = 9;
            this.Button_Print.UseVisualStyleBackColor = true;
            this.Button_Print.Click += new System.EventHandler(this.Button_Print_Click);
            // 
            // Button_Edit
            // 
            this.Button_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Edit.BackgroundImage = global::PonudeProjekt.Properties.Resources.edit;
            this.Button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_Edit.FlatAppearance.BorderSize = 0;
            this.Button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Edit.Location = new System.Drawing.Point(790, 5);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(40, 40);
            this.Button_Edit.TabIndex = 8;
            this.Button_Edit.UseVisualStyleBackColor = true;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Delete.BackgroundImage = global::PonudeProjekt.Properties.Resources.delete;
            this.Button_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_Delete.FlatAppearance.BorderSize = 0;
            this.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Delete.Location = new System.Drawing.Point(836, 5);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(40, 40);
            this.Button_Delete.TabIndex = 7;
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Input_Pretrazi
            // 
            this.Input_Pretrazi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Input_Pretrazi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_Pretrazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Pretrazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Input_Pretrazi.Location = new System.Drawing.Point(171, 13);
            this.Input_Pretrazi.Name = "Input_Pretrazi";
            this.Input_Pretrazi.Size = new System.Drawing.Size(415, 26);
            this.Input_Pretrazi.TabIndex = 6;
            this.Input_Pretrazi.TextChanged += new System.EventHandler(this.Input_Pretrazi_TextChanged);
            // 
            // Text_Pretrazi
            // 
            this.Text_Pretrazi.Font = new System.Drawing.Font("Nirmala UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Pretrazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Text_Pretrazi.Location = new System.Drawing.Point(0, 0);
            this.Text_Pretrazi.Name = "Text_Pretrazi";
            this.Text_Pretrazi.Padding = new System.Windows.Forms.Padding(10, 13, 0, 0);
            this.Text_Pretrazi.Size = new System.Drawing.Size(165, 50);
            this.Text_Pretrazi.TabIndex = 3;
            this.Text_Pretrazi.Text = "Pretraži:";
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(903, 0);
            this.axAcroPDF1.Margin = new System.Windows.Forms.Padding(0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(655, 748);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // Form_Ponude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1558, 748);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Ponude";
            this.Text = "Form_Ponude";
            this.Load += new System.EventHandler(this.Form_Ponude_Load);
            this.Shown += new System.EventHandler(this.Form_Ponude_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Panel_Ponude.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tablica_Ponude)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Panel Panel_Ponude;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Text_Pretrazi;
        private System.Windows.Forms.TextBox Input_Pretrazi;
        private System.Windows.Forms.DataGridView Tablica_Ponude;
        private System.Windows.Forms.Button Button_Delete;
        private System.Windows.Forms.Button Button_Print;
        private System.Windows.Forms.Button Button_Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn broj_ponude;
        private System.Windows.Forms.DataGridViewTextBoxColumn klijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn naslov;
        private System.Windows.Forms.DataGridViewTextBoxColumn iznos_no_pdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn iznos_pdv;
        private System.Windows.Forms.Button Button_Nova;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}