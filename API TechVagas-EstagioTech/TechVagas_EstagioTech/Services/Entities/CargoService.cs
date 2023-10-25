using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities

{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepositorio cargoRepositorio, IMapper mapper)
        {
            _cargoRepositorio = cargoRepositorio;
            _mapper = mapper;
        }

        public async Task<CargoDto> BuscarPorId(int id)
        {
            var cargo = await _cargoRepositorio.BuscarPorId(id);
            return _mapper.Map<CargoDto>(cargo);
        }

        public async Task<IEnumerable<CargoDto>> BuscarTodosCargos()
        {
            var cargo = await _cargoRepositorio.BuscarTodosCargos();
            return _mapper.Map<IEnumerable<CargoDto>>(cargo);
        }

        public async Task Adicionar(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<CargoModel>(cargoDto);
            await _cargoRepositorio.Adicionar(cargo);
            cargoDto.CargoId = cargo.CargoId;
        }

        public async Task Atualizar(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<CargoModel>(cargoDto);
            await _cargoRepositorio.Atualizar(cargo);
        }

        public async Task Apagar(int id)
        {
            await _cargoRepositorio.Apagar(id);
        }

    }
}
