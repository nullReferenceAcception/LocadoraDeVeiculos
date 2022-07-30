using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBase<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override void Excluir(Funcionario registro)
        {
            registros.Update(registro);
        }

        public override List<Funcionario> SelecionarTodos()
        {
            return registros.Where(x => x.EstaAtivo == true).ToList();
        }

        public List<Funcionario> SelecionarDesativados()
        {
            return registros.Where(x => x.EstaAtivo == false).ToList();
        }

        public bool VerificarDuplicidade(Funcionario registro)
        {
            var x = registros.Where(x => x.Login == registro.Login && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }
    }
}
