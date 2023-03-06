using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
           var heroes= await _superHeroService.GetAllHeroes();
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero=await _superHeroService.GetSingleHero(id);
            if (hero == null)
                return NotFound("Hero not found!!!");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            var heroes =await _superHeroService.AddHero(hero);
            return Created("Hero added.",heroes);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, [FromBody] SuperHero newHero)
        {
            var heroes =await _superHeroService.UpdateHero(id, newHero);
            if (heroes == null)
                return NotFound("Hero not found!!!");
            return Ok(heroes);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroes=await _superHeroService.DeleteHero(id);
            if (heroes == null)
                return NotFound("Hero not found!!!");
            return Ok(heroes);
        }
        [HttpPatch]
        [Route("updatePartial/{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdatePartial(int id, JsonPatchDocument<SuperHero> newHero)
        {
            var heroes = await _superHeroService.UpdateHeroPartial(id, newHero);
            if (heroes == null)
                return NotFound("Hero doesnt exist...");
            return Ok(heroes);
        }
    }
}
