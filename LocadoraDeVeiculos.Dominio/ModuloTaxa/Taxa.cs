namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }

        public bool EhDiaria { get; set; }

        public Taxa()
        {
            Valor = 0;
        }

        public Taxa(string? descricao, decimal? valor,bool ehDiaria)
        {
            Descricao = descricao;
            Valor = valor;
            this.EhDiaria = ehDiaria;
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
