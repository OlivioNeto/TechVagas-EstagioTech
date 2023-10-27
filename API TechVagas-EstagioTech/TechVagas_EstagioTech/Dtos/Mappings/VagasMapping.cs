using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Mappings
{
	public class VagasMapping : Profile
	{
		public VagasMapping() 
		{
			CreateMap<VagasDto, VagasModel>();
			CreateMap<VagasModel, VagasDto>().ReverseMap();
		}
	}
}
