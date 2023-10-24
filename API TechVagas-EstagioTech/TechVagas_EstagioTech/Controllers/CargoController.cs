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
		public ActionResult<CargoModel> Get(int id)
		{
			var cargos = _context.Cargos.FirstOrDefault(c => c.CargoId == id);
			if (cargos is null)
			{
				return NotFound("Cargo não encontrado");
			}
			return cargos;
		}

		[HttpPost]
		public ActionResult Post(CargoModel cargo)
		{
			if (cargo is null)
				return BadRequest();

			_context.Cargos.Add(cargo);
			_context.SaveChanges();

			return new CreatedAtRouteResult("ObterCargo",
				new { id = cargo.CargoId }, cargo);
		}

		[HttpPut("{id:int}")]
		public ActionResult Put(int id, CargoModel cargo)
		{
			if (id != cargo.CargoId)
			{
				return BadRequest();
			}
			_context.Entry(cargo).State = EntityState.Modified;
			_context.SaveChanges();

			return Ok(cargo);
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
