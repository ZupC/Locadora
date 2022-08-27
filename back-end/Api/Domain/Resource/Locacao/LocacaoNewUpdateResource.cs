using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Resource.OrdemServico
{
    public class LocacaoNewUpdateResource : ResourceBase
    {
        public string Cliente { get; set; }
        public int Id_Cliente { get; set; }
        public string Filme { get; set; }
        public int Id_Filme { get; set; }
    }
}
