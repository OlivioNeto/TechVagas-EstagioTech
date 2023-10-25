using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities

{
    public class CargoService
    {
        private readonly ICargoInterface _cargoRepositorio;
        private readonly IMapper _mapper;

        public CargoService(ICargoInterface cargoRepositorio, IMapper mapper)
        {
            _cargoRepositorio = cargoRepositorio;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CargoDto>> BuscarTodosCargos()
        {
            var cargos = await _cargoRepositorio.BuscarTodosCargos();
            return _mapper.Map<IEnumerable<CargoDto>>(cargos);
        }
    }
}
