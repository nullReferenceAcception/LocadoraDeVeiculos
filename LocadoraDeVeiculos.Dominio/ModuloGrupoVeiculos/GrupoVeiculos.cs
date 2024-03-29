﻿namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public string Nome { get; set; }

        public GrupoVeiculos()
        {
        }

        public GrupoVeiculos(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   Id == veiculos.Id &&
                   Nome == veiculos.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
