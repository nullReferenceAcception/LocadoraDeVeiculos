using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public GrupoVeiculos()
        {
        }

        public GrupoVeiculos(string v)
        {
            Nome = v;
        }

        public string Nome { get; set; }

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
