﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace superHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;
        public SuperHeroController( DataContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> Get(int id )
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero == null) return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero( SuperHero hero)
        {
             
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero resquest)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(resquest.Id);
            if (dbHero == null) return BadRequest("Hero not found");
            dbHero.Name = resquest.Name;
            dbHero.FirstName = resquest.FirstName;
            dbHero.LastName = resquest.LastName;
            dbHero.Place = resquest.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync()); 
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null) return BadRequest("Hero not found");
            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
