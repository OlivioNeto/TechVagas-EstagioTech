using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Mappings
{
	public class CargoMapping : Profile
	{
		public CargoMapping() 
		{
			CreateMap<CargoDto, CargoModel>();

			CreateMap<CargoDto, CargoModel>().ForMember(
				c => c.CargoId,
				options => options.MapFrom(
					src => src.VagasId));
		}
	}
}
