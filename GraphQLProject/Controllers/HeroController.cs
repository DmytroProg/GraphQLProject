using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQLProject.Data;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Controllers;

public class HeroController : GraphController
{
    private readonly DataContext _context;

    public HeroController(DataContext context)
    {
        _context = context;
    }

    [QueryRoot("heroes")]
    public async Task<IEnumerable<Hero>> GetHeroes()
    {
        return await _context.Heroes
            .Include(h => h.Weapon)
            .ToArrayAsync();
    }

    [QueryRoot("getHero")]
    public async Task<Hero?> GetHero(int id)
    {
        return await _context.Heroes.FindAsync(id);
    }

    [MutationRoot("addHero")]
    public async Task<Hero> AddHero(Hero hero)
    {
        _context.Add(hero);
        await _context.SaveChangesAsync();
        return hero;
    }
    
    
}