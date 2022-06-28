using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloTaxa
{
    public class ServicoTaxa : ServicoBase<Taxa, ValidadorTaxa>,IServicoTaxa
    {

        public ServicoTaxa(IRepositorioTaxa repositorio) : base(new ValidadorTaxa(), repositorio)
        {

        }

        public override ValidationResult HaDuplicidadeFilha(Taxa registro, ValidationResult resultadoValidacao)
        {

            return HaDuplicidadeMae("Descricao já está cadastrado", registro, resultadoValidacao);
        }
    }
}
