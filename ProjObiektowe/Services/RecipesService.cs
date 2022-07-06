
using ProjObiektowe.Database;
using ProjObiektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Services
{
    /// <summary>
    /// Database queries to Recipes table
    /// </summary>
    public static class RecipesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"> recipe model</param>
        /// <returns>added recipe Id</returns>
        public static int AddRecipe(Recipes recipe)
        {
            using (var context = new MyDbContext())
            {
                var addedRecipe = context.Recipes.Add(recipe);
                context.SaveChanges();
                return addedRecipe.Entity.RecipeId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of all recipes</returns>
        public static List<Recipes> GetAllRecipes() 
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_title"> part of recipe title</param>
        /// <returns>list of recipes by title</returns>
        public static List<Recipes> GetRecipesByTitle(string _title)
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.Where(x => x.RecipeTitle.ToLower().Contains(_title.ToLower())).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>recipe model </returns>
        public static Recipes GetRecipe(int recipeId)
        {
            using (var context = new MyDbContext())
            {
                return context.Recipes.Where(x => x.RecipeId == recipeId).Single();
            }
        }
        
    }
}
