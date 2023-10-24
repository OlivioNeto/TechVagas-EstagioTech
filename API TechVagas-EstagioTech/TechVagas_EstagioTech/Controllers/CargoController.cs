using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CargoController : ControllerBase
	{
		private readonly ICargoInterface _cargo;

		public CargoController(ICargoInterface cargo)
		{
			_cargo = cargo;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
		{
			var cargoDto = await _cargo.BuscarTodosCargos();
			if (cargoDto == null) return NotFound("Cargos não encontradas!");
			return Ok(cargoDto);
		}

		[HttpGet("{id:int}", Name = "ObterCargo")]
		public async Task<ActionResult<CargoDto>> Get(int id)
		{
			var cargoDto = await _cargo.BuscarPorId(id);
			if (cargoDto == null) return NotFound("Cargo não encontrado");
			return Ok(cargoDto);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CargoDto cargoDto)
		{
			if (cargoDto is null) return BadRequest("Dado inválido!");
			await _cargo.Adicionar(cargoDto);
			return new CreatedAtRouteResult("GetCargo", new { id = cargoDto.CargoId }, cargoDto);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put([FromBody] CargoDto cargoDto)
		{
			if (cargoDto is null) return BadRequest("Dado invalido!");
			await _cargo.Atualizar(cargoDto);
			return Ok(cargoDto);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			var cargo = _context.Cargos.FirstOrDefault(c => c.CargoId == id);

			if (cargo is null)
			{
				return NotFound("Cargos não encontrado...");
			}
			_context.Cargos.Remove(cargo);
			_context.SaveChanges();

			return Ok(cargo);
		}
	}
}
