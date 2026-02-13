using ApiExample.Data;
using ApiExample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{

		private readonly DataContext _context;

		public SuperHeroController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
		{
			var heroes = new List<SuperHero>
			{
				new SuperHero
				{
					Id = 1,
					Name = "Spiderman",
					FirstName = "Peter",
					LastName = "Parker",
					Place = "New York City"
				},
				new SuperHero
				{
					Id = 2,
					Name = "Ironman",
					FirstName = "Tony",
					LastName = "Stark",
					Place = "Long Island"
				},
				new SuperHero
				{
					Id = 3,
					Name = "Hulk",
					FirstName = "Bruce",
					LastName = "Banner",
					Place = "Dayton"
				}
			};
			return Ok(heroes);
		}
	}
}
