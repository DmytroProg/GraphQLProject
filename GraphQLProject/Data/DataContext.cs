﻿using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {
    }

    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
}