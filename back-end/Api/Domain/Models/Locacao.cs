using Api.Domain.Abstract;
using Api.Core.Interface.Models;
using System;
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class Locacao : ModeloBase, IModeloBase
    {
        public string Cliente { get; set; }
        public int ClienteId { get; set; }
        public string Filme { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

    }
}
