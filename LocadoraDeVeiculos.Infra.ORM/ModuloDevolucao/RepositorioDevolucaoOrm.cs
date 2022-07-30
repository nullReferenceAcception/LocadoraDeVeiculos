using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : RepositorioBase<Devolucao>, IRepositorioDevolucao
    {
        public RepositorioDevolucaoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public bool VerificarDuplicidade(Devolucao registro)
        {
            return false;
        }

        public override List<Devolucao> SelecionarTodos()
        {
            return registros.Include(x => x.Locacao)
                .Include(x => x.Locacao.Cliente)
                .Include(x => x.Locacao.Condutor)
                .Include(x => x.Locacao.Funcionario)
                .Include(x => x.Locacao.PlanoCobranca)
                .Include(x => x.Locacao.Veiculo)
                .ToList();
        }

        public void RemoverTaxas(Devolucao devolucao, List<Taxa> taxas)
        {
            foreach (Taxa taxa in taxas)
                if (devolucao.TaxasAdicionais.Contains(taxa))
                    devolucao.TaxasAdicionais.Remove(taxa);
        }
    }
}
