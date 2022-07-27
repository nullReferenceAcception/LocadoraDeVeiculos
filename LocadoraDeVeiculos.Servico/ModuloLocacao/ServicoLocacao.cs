using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao, ValidadorLocacao>, IServicoLocacao
    {
        public ServicoLocacao(IRepositorioLocacao repositorioGrupoVeiculos, IContextoPersistencia contexto) : base(new ValidadorLocacao(), repositorioGrupoVeiculos, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";
    }
}
