using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>, IServicoCondutor
    {
        public ServicoCondutor(IRepositorioCondutor repositorio) : base(new ValidadorCondutor(), repositorio)
        {
            
        }

        protected override string SqlMensagemDeErro => "Nome já cadastrado";
    }
}




