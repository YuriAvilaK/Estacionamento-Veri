namespace Estacionamento_Veri
{
    partial class Form2
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
            btOk = new Button();
            btCancel = new Button();
            txtPlaca = new TextBox();
            txtValor = new TextBox();
            lblPlaca = new Label();
            lblValor = new Label();
            SuspendLayout();
            // 
            // btOk
            // 
            btOk.Location = new Point(282, 139);
            btOk.Name = "btOk";
            btOk.Size = new Size(75, 23);
            btOk.TabIndex = 0;
            btOk.Text = "OK";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(282, 168);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(75, 23);
            btCancel.TabIndex = 1;
            btCancel.Text = "Cancelar";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(21, 55);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(153, 23);
            txtPlaca.TabIndex = 2;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(21, 130);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(63, 23);
            txtValor.TabIndex = 3;
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaca.Location = new Point(21, 22);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(64, 30);
            lblPlaca.TabIndex = 4;
            lblPlaca.Text = "Placa";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValor.Location = new Point(21, 97);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(63, 30);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 203);
            Controls.Add(lblValor);
            Controls.Add(lblPlaca);
            Controls.Add(txtValor);
            Controls.Add(txtPlaca);
            Controls.Add(btCancel);
            Controls.Add(btOk);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOk;
        private Button btCancel;
        private TextBox txtPlaca;
        private TextBox txtValor;
        private Label lblPlaca;
        private Label lblValor;
    }
}