using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteOrm(IContextoPersistencia dbContext) : base(dbContext)
        {

        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaFisica()
        {
            return registros.Where(x => x.PessoaFisica == true).ToList();
        }

        public List<Cliente> SelecionarTodosClientesQueSaoPessoaJuridica()
        {
            return registros.Where(x => x.PessoaFisica == false).ToList();

        }

        public bool VerificarDuplicidade(Cliente registro)
        {
            var x = registros.Where(x => x.CPF != null &&  x.CPF == registro.CPF && x.Id != registro.Id);

            if (x.Any())
                return true;


            return false;

        }

        public bool VerificarDuplicidadeCNPJ(Cliente registro)
        {
            var x = registros.Where(x => x.CNPJ != null  && x.CNPJ == registro.CNPJ && x.Id != registro.Id).ToList();

            if (x.Any())
                return true;


            return false;

        }


    }
}