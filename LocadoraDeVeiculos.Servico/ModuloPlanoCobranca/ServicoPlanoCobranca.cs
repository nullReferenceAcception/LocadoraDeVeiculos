using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorio) : base(new ValidadorPlanoCobranca(),repositorio)
        {

        }
        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
