
using Estacionamento_Veri.Class;
using MongoDB.Driver;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace Estacionamento_Veri
{
    public partial class Form1 : Form
    {
        private MongoService _mongoService;

        public Form1()
        {
            InitializeComponent();
            _mongoService = new MongoService();
            CarregarDados();
        }

        private void CarregarDados()
        {
            var veiculos = _mongoService.ObterVeiculosEstacionados();
            dtgEsta.DataSource = veiculos;

            if (dtgEsta.Columns["Id"] != null)
            {
                dtgEsta.Columns["Id"].Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgEsta.CellFormatting += dtgEsta_CellFormatting;
            dtgEsta.CellFormatting += dtgEsta_CellFormatting;

            dtgEsta.Columns["DataEntrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewColumn coluna in dtgEsta.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btEntrada_Click(object sender, EventArgs e)
        {
            Form2 formEntrada = new Form2();

            if (formEntrada.ShowDialog() == DialogResult.OK)
            {
                string placa = formEntrada.PlacaDoCarro;
                string dataHoraEntrada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                decimal valor = formEntrada.Valor;

                var novoVeiculo = new Veiculo
                {
                    Placa = placa,
                    DataEntrada = dataHoraEntrada,
                    ValorPorHora = valor
                };

                _mongoService.InserirCarro(novoVeiculo);

                CarregarDados();

            }
        }

        private void btSaida_Click(object sender, EventArgs e)
        {
            if (dtgEsta.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgEsta.SelectedRows[0];

                string idCarro = row.Cells["Id"].Value?.ToString();

                string dataHoraEntradaStr = row.Cells[2].Value?.ToString();
                bool conversaoBemSucedida = DateTime.TryParseExact(
                dataHoraEntradaStr,
                "dd/MM/yyyy HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dataHoraEntrada);

                if (conversaoBemSucedida)
                {
                    DateTime dataHoraSaida = DateTime.Now;

                    row.Cells[3].Value = dataHoraSaida;

                    TimeSpan duracao = dataHoraSaida - dataHoraEntrada;
                    double duracaoEmHoras = duracao.TotalHours;

                    row.Cells[4].Value = duracaoEmHoras.ToString("F2");

                    double tempoCobrado;
                    if (duracao.TotalMinutes < 30)
                    {
                        tempoCobrado = 0.5;
                    }
                    else
                    {
                        //tolerancia 10 min
                        double horasTotais = duracao.TotalHours;
                        double minutosExcedentes = duracao.TotalMinutes % 60;

                        if (minutosExcedentes > 10)
                        {
                            tempoCobrado = Math.Ceiling(horasTotais);
                        }
                        else
                        {
                            tempoCobrado = Math.Floor(horasTotais);
                        }
                    }

                    row.Cells[5].Value = tempoCobrado.ToString();

                    string valorStr = row.Cells[6].Value.ToString();
                    if (decimal.TryParse(valorStr, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal valorPorHora))
                    {

                        decimal valorAPagar = valorPorHora * (decimal)tempoCobrado;
                        row.Cells[7].Value = valorAPagar;

                        AtualizarCarroNoMongo(idCarro, dataHoraSaida, duracao, tempoCobrado, valorAPagar);
                    }
                    else
                    {
                        MessageBox.Show("O valor por hora não pôde ser convertido corretamente.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um carro na tabela para marcar a saída.");
            }
        }

        private void AtualizarCarroNoMongo(string idCarro, DateTime dataSaida, TimeSpan duracao, double tempoCobrado, decimal valorAPagar)
        {
            var mongoDbService = new MongoService();

            var filtro = Builders<Veiculo>.Filter.Eq("Id", idCarro);

            var atualizacao = Builders<Veiculo>.Update
                .Set(v => v.DataSaida, dataSaida)
                .Set(v => v.Duracao, duracao.TotalHours)
                .Set(v => v.TempoCobrado, tempoCobrado)
                .Set(v => v.ValorAPagar, valorAPagar);

            mongoDbService._carrosCollection.UpdateOne(filtro, atualizacao);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string placaDigitada = txtBuscPlaca.Text.ToUpper().Trim();
            bool somenteNoEstacionamento = chkEsta.Checked;

            if (string.IsNullOrEmpty(placaDigitada))
            {
                foreach (DataGridViewRow row in dtgEsta.Rows)
                {
                    string dataSaida = row.Cells[3].Value?.ToString();

                    if (somenteNoEstacionamento)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtgEsta.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = string.IsNullOrEmpty(dataSaida);
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
                return;
            }

            foreach (DataGridViewRow row in dtgEsta.Rows)
            {
                string placaNaTabela = row.Cells[1].Value?.ToString().ToUpper();
                string dataSaida = row.Cells[3].Value?.ToString();

                bool placaCorresponde = !string.IsNullOrEmpty(placaNaTabela) &&
                                        (placaNaTabela.Contains(placaDigitada) || placaNaTabela.Equals(placaDigitada));

                bool estaNoEstacionamento = string.IsNullOrEmpty(dataSaida);

                if (placaCorresponde && (!somenteNoEstacionamento || estaNoEstacionamento))
                {
                    row.Visible = true;
                }
                else
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtgEsta.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtBuscPlaca.Text = string.Empty;

            chkEsta.Checked = false;

            foreach (DataGridViewRow row in dtgEsta.Rows)
            {
                row.Visible = true;
            }
        }

        private void chkEsta_CheckedChanged(object sender, EventArgs e)
        {
            bool somenteNoEstacionamento = chkEsta.Checked;

            foreach (DataGridViewRow row in dtgEsta.Rows)
            {
                string dataSaida = row.Cells[3].Value?.ToString();

                if (somenteNoEstacionamento)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtgEsta.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = string.IsNullOrEmpty(dataSaida);
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    row.Visible = true;
                }
            }
        }

        private void dtgEsta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (e.Value is double)
                {
                    double duracaoEmHoras = (double)e.Value;
                    TimeSpan duracao = TimeSpan.FromHours(duracaoEmHoras);
                    e.Value = duracao.ToString(@"hh\:mm\:ss");
                    e.FormattingApplied = true;
                }
            }

            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
