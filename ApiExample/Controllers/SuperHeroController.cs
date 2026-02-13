using ApiExample.Data;
using ApiExample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{

		private readonly DataContext _context;

		public SuperHeroController(DataContext context) // Dependency Injection of the DataContext
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>>
			GetAllHeroes() // Asynchronous method to get all superheroes from the database
		{
			var heroes = await _context.SuperHeroes.ToListAsync();

			return Ok(heroes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SuperHero>> GetHeroById(int id) // Asynchronous method to get a superhero by ID
		{
			var hero = await _context.SuperHeroes.FindAsync(id);
			if (hero == null)
				return NotFound();
			return Ok(hero);
		}

		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			_context.SuperHeroes.AddAsync(hero);
			await _context.SaveChangesAsync();
			return Ok(await _context.SuperHeroes.ToListAsync());
		}

		[HttpPut]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
		{
			var dbHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
			if (dbHero == null)
				return NotFound("Superhero not found.");

			dbHero.Name = updatedHero.Name;
			dbHero.FirstName = updatedHero.FirstName;
			dbHero.LastName = updatedHero.LastName;
			dbHero.Place = updatedHero.Place;

			await _context.SaveChangesAsync();

			return Ok(await _context.SuperHeroes.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
		{
			var dbHero = await _context.SuperHeroes.FindAsync(id);
			if (dbHero == null)
				return NotFound("Superhero not found.");
			_context.SuperHeroes.Remove(dbHero);
			await _context.SaveChangesAsync();
			return Ok(await _context.SuperHeroes.ToListAsync());
		}
	}
}
