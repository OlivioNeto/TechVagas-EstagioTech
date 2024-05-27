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
			CreateMap<CursoDto, CursoModel>().ReverseMap();
			CreateMap<DocumentoDto, DocumentoModel>().ReverseMap();
			CreateMap<TipoDocumentoDto, TipoDocumentoModel>().ReverseMap();
			CreateMap<TipoEstagioDto, TipoEstagioModel>().ReverseMap();
            CreateMap<ConcedenteDto, ConcedenteModel>().ReverseMap();
            CreateMap<VagasDto, VagasModel>().ReverseMap();
			CreateMap<AlunoDto, AlunoModel>().ReverseMap();
			CreateMap<DocumentoVersaoDto, DocumentoVersaoModel>().ReverseMap();
			CreateMap<DocumentoNecessarioDto, DocumentoNecessarioModel>().ReverseMap();
			CreateMap<InstituicaoEnsinoDto, InstituicaoEnsinoModel>().ReverseMap();
			CreateMap<ApontamentoDto, ApontamentoModel>().ReverseMap();
            CreateMap<CoordenadorEstagioDto, CoordenadorEstagioModel>().ReverseMap();
			CreateMap<SupervisorEstagioDto, SupervisorEstagioModel>().ReverseMap();
            CreateMap<ContratoEstagioDto, ContratoEstagioModel>().ReverseMap();
			CreateMap<MatriculaDto, MatriculaModel>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioModel>().ReverseMap();
            CreateMap<SessaoDto, SessaoModel>().ReverseMap();
        }
	}
}
