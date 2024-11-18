using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Controllers;

public class WeaponController : GraphController
{
    private readonly DataContext _context;

    public WeaponController(DataContext context)
    {
        _context = context;
    }

    [MutationRoot("addWeapon")]
    public async Task<Weapon> AddWeapon(Weapon weapon)
    {
        _context.Add(weapon);
        await _context.SaveChangesAsync();
        return weapon;
    }

    [MutationRoot("assignWeaponToHero")]
    public async Task<int> AssignWeaponToHero(int weaponId, int heroId)
    {
        var hero = await _context.Heroes.FindAsync(heroId);
        var weapon = await _context.Weapons.FindAsync(weaponId);
        hero.Weapon = weapon;
        await _context.SaveChangesAsync();
        return 1;
    }
}