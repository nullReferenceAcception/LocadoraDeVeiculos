using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBase<Locacao>, IRepositorioLocacao
    {
        public RepositorioLocacaoOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        public void RemoverTaxas(Locacao locacao,List<Taxa> taxas)
        {
            foreach (var item in taxas)
            {
                if (locacao.Taxas.Contains(item))
                    locacao.Taxas.Remove(item);
            }
        }

        public override List<Locacao> SelecionarTodos()
        {
            return registros.Include(x => x.Condutor)
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
            var x = registros.Where(x => x.Veiculo == registro.Veiculo && x.EstaAtivo == true && x.Id != registro.Id);

            if (x.Any())
                return true;

            return false;
        }
    }
}
