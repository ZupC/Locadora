using Api.Core.Interface.Models;

namespace Api.Domain.Abstract
{
    public abstract class ModeloBase : IModeloBase
    {
        public int Id { get; set; }
    }
}
