using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBase<Locacao>, IRepositorioLocacao
    {
        public RepositorioLocacaoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public void RemoverTaxas(Locacao locacao, List<Taxa> taxas)
        {
            foreach (Taxa taxa in taxas)
                if (locacao.Taxas.Contains(taxa))
                    locacao.Taxas.Remove(taxa);
        }

        public override void Excluir(Locacao registro)
        {
            registro.Status = StatusEnum.Inativo;
            registros.Update(registro);
        }


        public override List<Locacao> SelecionarTodos()
        {
            return registros.Where(x => x.Status == StatusEnum.Ativo).Include(x => x.Condutor)
                .ThenInclude(x => x.Cliente)
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.PlanoCobranca).ThenInclude(x => x.GrupoVeiculos)
                .Include(x => x.Taxas)
                .Include(x => x.Veiculo).ThenInclude(x => x.GrupoVeiculos)
                .ToList();
        }

        public bool VerificarDuplicidade(Locacao registro)
        {
            var x = registros.Where(x => x.Veiculo == registro.Veiculo && x.Status == StatusEnum.Ativo && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }

        public List<Locacao> SelecionarDesativados()
        {
            return registros.Where(x => x.Status == StatusEnum.Inativo || x.Status == StatusEnum.Finalizado).Include(x => x.Condutor)
                .ThenInclude(x => x.Cliente)
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.PlanoCobranca).ThenInclude(x => x.GrupoVeiculos)
                .Include(x => x.Taxas)
                .Include(x => x.Veiculo).ThenInclude(x => x.GrupoVeiculos)
                .ToList();
        }
    }
}
