using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Resource.Cliente
{
    public class ClienteResource : ResourceBase
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        //public string DataNascimentoFormatada { get { return DataNascimento.ToString("dd/MM/yyyy"); } }
    }
}
