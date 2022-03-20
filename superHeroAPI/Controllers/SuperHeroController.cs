using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace superHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> heros = new List<SuperHero>
            {
                new SuperHero{
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName =  "Parker",
                    Place = "New York City"},
                new SuperHero{
                    Id = 2,
                    Name = "IronMan",
                    FirstName = "Tony",
                    LastName =  "Stark",
                    Place = "LonG Island"}
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heros);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> Get(int id )
        {
            var hero = heros.Find(h => h.Id == id);
            if(hero == null) return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero( SuperHero hero)
        {
            
            heros.Add(hero);
            return Ok(heros);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero resquest)
        {
            var hero = heros.Find(h => h.Id == resquest.Id);
            if (hero == null) return BadRequest("Hero not found");
            hero.Name = resquest.Name;
            hero.FirstName = resquest.FirstName;    
            hero.LastName = resquest.LastName;  
            hero.Place = resquest.Place;
            return Ok(heros);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null) return BadRequest("Hero not found");
            heros.Remove(hero);
            return Ok(heros);
        }

    }
}
