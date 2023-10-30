using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CargoDto, CargoModel>().ReverseMap();
			CreateMap<VagasDto, VagasModel>().ReverseMap();
			CreateMap<CursoDto, CursoModel>().ReverseMap();
			CreateMap<DocumentoDto, DocumentoModel>().ReverseMap();
			CreateMap<TipoDocumentoDto, TipoDocumentoModel>().ReverseMap();
			CreateMap<TipoEstagioDto, TipoEstagioModel>().ReverseMap();
            CreateMap<ConcedenteDto, ConcedenteModel>().ReverseMap();


        }
	}
}
