using Api.Domain.Abstract;
using Api.Core.Interface.Models;

namespace Api.Domain.Models
{
    public class Cliente : ModeloBase, IModeloBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
