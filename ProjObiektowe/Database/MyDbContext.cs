using Microsoft.EntityFrameworkCore;
using ProjObiektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Database
{
    public  class MyDbContext : DbContext 
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-UGLSJC1Q;database=CookBook;trusted_connection=true;");
                base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Recipes> Recipes { get; set; }

        public DbSet<Tags> Tags { get; set; }

        public DbSet<RecipesTags> RecipesTags { get; set; }

        public DbSet<RecipesIngrediens> RecipesIngrediens { get; set; }

        public DbSet<Ingrediens> Ingrediens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipesTags>()
                .HasKey(rt => new {rt.RecipeId,rt.TagId});
           
            modelBuilder.Entity<RecipesTags>()
                .HasOne(rt=>rt.Recipes)
                .WithMany(r => r.RecipesTags)
                .HasForeignKey(rt=>rt.RecipeId);
            modelBuilder.Entity<RecipesTags>()
                .HasOne(rt => rt.Tags)
                .WithMany(t => t.RecipesTags)
                .HasForeignKey(rt => rt.TagId);

            modelBuilder.Entity<RecipesIngrediens>()
                .HasKey(rt => new { rt.RecipeId, rt.IngredientId });
                
            modelBuilder.Entity<RecipesIngrediens>()
                .HasOne(rt => rt.Recipes)
                .WithMany( t=> t.RecipesIngrediens)
                .HasForeignKey(rt => rt.RecipeId);

            modelBuilder.Entity<RecipesIngrediens>()
                .HasOne(rt => rt.Ingrediens)
                .WithMany(t => t.RecipesIngrediens)
                .HasForeignKey(rt => rt.IngredientId);

            base.OnModelCreating(modelBuilder);

        }

    }

   
}
