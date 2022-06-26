using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    ID = 1,
                    Name = "father",
                    Power = "PowerLike_GOD"
                }
            };
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            return Ok(hero);
        }
        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            _context.superHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> PutHero(SuperHero Req)
        {
            var hero = await _context.superHeroes.FindAsync(Req.ID);
            hero.Name = Req.Name;
            hero.Power = Req.Power;
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
        [HttpDelete]
        public async Task<IActionResult> Delet(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            _context.superHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }
    }
}
