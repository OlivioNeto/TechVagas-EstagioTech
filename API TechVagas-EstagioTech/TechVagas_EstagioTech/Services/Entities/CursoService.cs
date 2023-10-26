using AutoMapper;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class CursoService
	{
		private readonly ICursoRepositorio _cursoRepositorio;
		private readonly IMapper _mapper;
	}
}
