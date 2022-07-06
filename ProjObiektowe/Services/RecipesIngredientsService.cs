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
    /// Database queries to join tableof Recipes and Ingredients
    /// </summary>
    public static class RecipesIngredientsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="ingredientId"></param>
        /// <returns>True</returns>
        public static bool AddRecipesIngredientsRecord(int recipeId, int ingredientId)
        {
            try
            {
                var obj = new RecipesIngrediens()
                {
                    RecipeId = recipeId,
                    IngredientId = ingredientId
                };
                using (var context = new MyDbContext())
                {
                    var addedRecord = context.RecipesIngrediens.Add(obj);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"> recipe id</param>
        /// <returns>List of ingredients ids</returns>
        public static List<int> GetIngredientsIds(int recipeId)
        {
            using (var context = new MyDbContext())
            {
                return context.RecipesIngrediens.Where(x => x.RecipeId == recipeId).Select(x => x.IngredientId).ToList();
            }
        }

    }
}
