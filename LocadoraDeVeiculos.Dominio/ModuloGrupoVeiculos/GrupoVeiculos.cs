namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public string Nome { get; set; }

        public GrupoVeiculos()
        {
        }

        public GrupoVeiculos(string v)
        {
            Nome = v;
        }


        public override void Atualizar(GrupoVeiculos registro)
        {
                   Id = registro.Id;
                  Nome = registro.Nome;
        }

        //TODO lista de veiculos

        public override bool Equals(object? obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   Id == veiculos.Id &&
                   Nome == veiculos.Nome;
        }
    }
}
