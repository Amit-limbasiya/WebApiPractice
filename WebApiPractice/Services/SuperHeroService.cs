using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Data;

namespace WebApiPractice.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context) 
        {
            _context = context;
        }
       

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            _context.SaveChanges();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var superHeroes= await _context.SuperHeroes.ToListAsync();
            return superHeroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero newHero)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            hero.Name = newHero.Name;
            hero.FirstName = newHero.FirstName;
            hero.LastName = newHero.LastName;
            hero.Place = newHero.Place;
            await _context.SaveChangesAsync();
            return  await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>?> UpdateHeroPartial(int id, JsonPatchDocument<SuperHero> newHero)
        {
            var existingHero = await _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == id);
            if (existingHero is null)
                return null;
            try
            {
                newHero.ApplyTo(existingHero);
            }
            catch (JsonPatchException ex)
            {
                Console.WriteLine("Applyto error: " + ex);
                return null;
            }
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
