using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Resource.Filme
{
    public class FilmeResource : ResourceBase
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }
        [Required]
        public int ClassificacaoIndicativa { get; set; }
        [Required]
        public int Lancamento { get; set; }
    }
}
