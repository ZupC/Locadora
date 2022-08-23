using Api.Domain.Abstract;
using Api.Core.Interface.Models;
using System;

namespace Api.Domain.Models
{
    public class Filme : ModeloBase, IModeloBase
    {
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
    }
}
