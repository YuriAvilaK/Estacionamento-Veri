namespace Estacionamento_Veri
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btEntrada = new Button();
            btSaida = new Button();
            dtgEsta = new DataGridView();
            txtBuscPlaca = new TextBox();
            lblBuscPlaca = new Label();
            btBuscar = new Button();
            btLimpar = new Button();
            chkEsta = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dtgEsta).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(257, 45);
            label1.TabIndex = 0;
            label1.Text = "Estacionamento";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btEntrada
            // 
            btEntrada.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btEntrada.Location = new Point(484, 88);
            btEntrada.Name = "btEntrada";
            btEntrada.Size = new Size(119, 43);
            btEntrada.TabIndex = 2;
            btEntrada.Text = "Marcar Entrada";
            btEntrada.UseVisualStyleBackColor = true;
            btEntrada.Click += btEntrada_Click;
            // 
            // btSaida
            // 
            btSaida.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSaida.Location = new Point(633, 88);
            btSaida.Name = "btSaida";
            btSaida.Size = new Size(119, 43);
            btSaida.TabIndex = 3;
            btSaida.Text = "Marcar Saída";
            btSaida.UseVisualStyleBackColor = true;
            btSaida.Click += btSaida_Click;
            // 
            // dtgEsta
            // 
            dtgEsta.AllowUserToAddRows = false;
            dtgEsta.AllowUserToDeleteRows = false;
            dtgEsta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgEsta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEsta.Location = new Point(12, 163);
            dtgEsta.Name = "dtgEsta";
            dtgEsta.ReadOnly = true;
            dtgEsta.Size = new Size(751, 227);
            dtgEsta.TabIndex = 4;
            dtgEsta.CellFormatting += dtgEsta_CellFormatting;
            // 
            // txtBuscPlaca
            // 
            txtBuscPlaca.Location = new Point(118, 85);
            txtBuscPlaca.Name = "txtBuscPlaca";
            txtBuscPlaca.Size = new Size(100, 23);
            txtBuscPlaca.TabIndex = 5;
            // 
            // lblBuscPlaca
            // 
            lblBuscPlaca.AutoSize = true;
            lblBuscPlaca.Location = new Point(12, 88);
            lblBuscPlaca.Name = "lblBuscPlaca";
            lblBuscPlaca.Size = new Size(100, 15);
            lblBuscPlaca.TabIndex = 6;
            lblBuscPlaca.Text = "Buscar por Placa: ";
            // 
            // btBuscar
            // 
            btBuscar.Location = new Point(224, 85);
            btBuscar.Name = "btBuscar";
            btBuscar.Size = new Size(75, 23);
            btBuscar.TabIndex = 7;
            btBuscar.Text = "Buscar";
            btBuscar.UseVisualStyleBackColor = true;
            btBuscar.Click += btBuscar_Click;
            // 
            // btLimpar
            // 
            btLimpar.Location = new Point(305, 85);
            btLimpar.Name = "btLimpar";
            btLimpar.Size = new Size(94, 23);
            btLimpar.TabIndex = 8;
            btLimpar.Text = "Limpar Busca";
            btLimpar.UseVisualStyleBackColor = true;
            btLimpar.Click += btLimpar_Click;
            // 
            // chkEsta
            // 
            chkEsta.AutoSize = true;
            chkEsta.Location = new Point(119, 123);
            chkEsta.Name = "chkEsta";
            chkEsta.Size = new Size(95, 19);
            chkEsta.TabIndex = 9;
            chkEsta.Text = "Estacionados";
            chkEsta.UseVisualStyleBackColor = true;
            chkEsta.CheckedChanged += chkEsta_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 402);
            Controls.Add(chkEsta);
            Controls.Add(btLimpar);
            Controls.Add(btBuscar);
            Controls.Add(lblBuscPlaca);
            Controls.Add(txtBuscPlaca);
            Controls.Add(dtgEsta);
            Controls.Add(btSaida);
            Controls.Add(btEntrada);
            Controls.Add(label1);
            Name = "Form1";
            Text = "7";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtgEsta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btEntrada;
        private Button btSaida;
        private DataGridView dtgEsta;
        private TextBox txtBuscPlaca;
        private Label lblBuscPlaca;
        private Button btBuscar;
        private Button btLimpar;
        private CheckBox chkEsta;
    }
}
