using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Model;

namespace TechVagas_EstagioTech.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CargoController : ControllerBase
	{
		private readonly DBContext _context;

		public CargoController(DBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CargoModel>> Get()
		{
			var cargos = _context.Cargos.ToList();
			if (cargos is null)
			{
				return NotFound("Cargos não encontrados");
			}
			return cargos;
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
