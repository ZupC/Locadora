using Api.Domain.Resource.Cliente;
using Api.Domain.Resource.Filme;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Resource.OrdemServico
{
    public class LocacaoResource : ResourceBase
    {
        [Required]
        public DateTime DataLocacao { get; set; }
        [Required]
        public DateTime DataDevolucao { get; set; }
    }
}
