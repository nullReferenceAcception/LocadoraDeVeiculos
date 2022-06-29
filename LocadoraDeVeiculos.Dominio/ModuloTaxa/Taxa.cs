namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }

        public Taxa()
        {
            
        }

        public Taxa(string? descricao, decimal? valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor;
        }
    }
}
