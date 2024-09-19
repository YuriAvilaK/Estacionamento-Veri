using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento_Veri
{
    public partial class Form2 : Form
    {
        public string PlacaDoCarro { get; private set; }
        public decimal Valor { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.Trim();

            if (!ValidarPlaca(placa))
            {
                MessageBox.Show("Por favor, insira uma placa válida (ex: AAA-9999 ou AAA9A99).");
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Por favor, insira um valor numérico.");
                return;
            }

            PlacaDoCarro = placa;
            Valor = valor;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarPlaca(string placa)
        {
            string padraoAntigo = @"^[A-Z]{3}-\d{4}$";
            string padraoMercosul = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            return Regex.IsMatch(placa, padraoAntigo) || Regex.IsMatch(placa, padraoMercosul);
        }
    }
}
