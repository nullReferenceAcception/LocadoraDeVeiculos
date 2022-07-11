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

        //TODO lista de veiculos

        public override bool Equals(object? obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   guid == veiculos.guid &&
                   Nome == veiculos.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
