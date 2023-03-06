using Microsoft.AspNetCore.JsonPatch;

namespace WebApiPractice.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero newHero);
        Task<List<SuperHero>?> DeleteHero(int id);
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>?> UpdateHeroPartial(int id, JsonPatchDocument<SuperHero> newHero);
    }
}
