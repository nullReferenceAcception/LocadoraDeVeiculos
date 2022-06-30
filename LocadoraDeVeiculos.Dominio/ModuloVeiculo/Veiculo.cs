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
        public decimal KmsPercorridos { get; set; }
        public CorEnum Cor { get; set; }
        public CombustivelEnum  Combustivel {get; set;}
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public byte[] Foto { get; set; }

        public Veiculo()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   Modelo == veiculo.Modelo &&
                   Placa == veiculo.Placa &&
                   Marca == veiculo.Marca &&
                   Ano == veiculo.Ano &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   KmsPercorridos == veiculo.KmsPercorridos &&
                   Cor == veiculo.Cor &&
                   Combustivel == veiculo.Combustivel &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, veiculo.GrupoVeiculos) &&
                   EqualityComparer<byte[]>.Default.Equals(Foto, veiculo.Foto);
        }
    }
}
