using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public virtual void GerarPdf() { }
        public virtual void Visualizar() { }
        public virtual bool VisualizarDesativados() { return true; }
        public abstract UserControl ObtemListagem();
        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();
    }
}
