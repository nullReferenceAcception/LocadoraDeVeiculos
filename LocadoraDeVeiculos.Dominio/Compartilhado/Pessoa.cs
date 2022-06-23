using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class Pessoa<T> : EntidadeBase<T>
    {
       public string Nome { get; set; }
       public string Endereco { get; set; }
       public string Email { get; set; }
       public string Telefone { get; set; }
    }
}
