namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}
