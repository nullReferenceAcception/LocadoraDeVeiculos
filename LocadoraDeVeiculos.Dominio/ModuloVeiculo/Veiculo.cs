using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public decimal KmPercorrido { get; set; }
        public CorEnum? Cor { get; set; }
        public CombustivelEnum? Combustivel { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public byte[] Foto { get; set; }

        public Veiculo()
        {

        }

        public Veiculo(string modelo, string placa, string marca, int ano, decimal capacidadeTanque, decimal kmPercorrido, CorEnum cor, CombustivelEnum combustivel, byte[] foto)
        {
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Ano = ano;
            CapacidadeTanque = capacidadeTanque;
            KmPercorrido = kmPercorrido;
            Cor = cor;
            Combustivel = combustivel;
            Foto = foto;
        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   guid == veiculo.guid &&
                   Modelo == veiculo.Modelo &&
                   Placa == veiculo.Placa &&
                   Marca == veiculo.Marca &&
                   Ano == veiculo.Ano &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   Cor == veiculo.Cor &&
                   Combustivel == veiculo.Combustivel &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, veiculo.GrupoVeiculos) &&
                   EqualsFoto(veiculo);
        }

        private bool EqualsFoto(Veiculo veiculo)
        {
            for (int i = 0; i < veiculo.Foto.Length; i++)
                if (!EqualityComparer<byte>.Default.Equals(Foto[i], veiculo.Foto[i])) return false;

            return true;
        }
    }
}
