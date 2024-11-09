﻿using Localizard.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Localizard.DAL;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
        
    }

    public DbSet<ProjectInfo> Projects { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<User> Users { get; set; }
    
}