using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Guid", HeaderText = "Guid"},

            };

            return colunas;
        }

        public int ObtemGuidVeiculoSelecionado()
        {
            return grid.ObterGuid<int>();
        }

        public void AtualizarRegistros(/*List<Locacao> locacoes*/)
        {
            grid.Rows.Clear();

            //foreach (Locacao locacao in locacoes)
            //    grid.Rows.Add();
        }
    }
}
