using Api.Core.Cryptography;
using Api.Domain.Abstract;
using Api.Domain.Models;
using Api.Domain.Resource;
using Api.Domain.Resource.Cliente;
using Api.Domain.Resource.OrdemServico;
using Api.Domain.Resource.Filme;
using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMapIDToResource<Filme, FilmeResource>();
            CreateMapIDToResource<Cliente, ClienteResource>();
            CreateMapIDToResource<Locacao, LocacaoResource>();

            CreateMapResourceToId<FilmeResource, Filme>();
            CreateMapResourceToId<ClienteResource, Cliente>();
            CreateMapResourceToId<LocacaoResource, Locacao>();

            CreateMap<LocacaoNewUpdateResource, Locacao>()
                .ForMember(pac => pac.Id, map => map.MapFrom(src => src.Id))
                .ForMember(pac => pac.ClienteId, map => map.MapFrom(src => src.Id_Cliente))
                .ForMember(pac => pac.FilmeId, map => map.MapFrom(src => src.Id_Filme));
        }

        private void CreateMapIDToResource<T, Z>() where T : ModeloBase where Z : ResourceBase
        {
            CreateMap<T, Z>().ForMember(pac => pac.Id, map =>
              map.MapFrom(src => $"{ Encryption.Encrypt(src.Id.ToString()) }"));
        }

        private void CreateMapResourceToId<T, Z>() where T : ResourceBase where Z : ModeloBase
        {
            CreateMap<T, Z>().ForMember(pac => pac.Id, map =>
              map.MapFrom(src => Convert.ToInt32(src.Id)));
        }
    }
}
