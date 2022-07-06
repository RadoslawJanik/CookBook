using ProjObiektowe.Database;
using ProjObiektowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Services
{
    public static class IngrediensService
    {
        /// <summary>
        /// Adds Ingerdient to a database
        /// </summary>
        /// <param name="ingredientName"> ingredient name in string like "carrot"</param>
        /// <returns>ingredientId</returns>
        public static int AddIngredient(string ingredientName)
        {
            using (var context = new MyDbContext())
            {
                var ingredientId = FindIngredient(ingredientName);

                if (ingredientId == 0)
                {
                    var ingredient = new Ingrediens()
                    {
                        IngredientName = ingredientName
                    };
                    var x = context.Ingrediens.Add(ingredient);
                    context.SaveChanges();
                    ingredientId = FindIngredient(ingredientName);
                }
                return ingredientId;
            }
        }

        /// <summary>
        /// Return Existing Ingredient id
        /// </summary>
        /// <param name="ingredientName">ingredient name in string like "carrot"</param>
        /// <returns>ingredient id</returns>
        public static int FindIngredient(string ingredientName)
        {
            using (var context = new MyDbContext())
            {
                int ingredientId = context.Ingrediens.Where(x => x.IngredientName == ingredientName)
                .Select(x => x.IngredientId).FirstOrDefault();
                return ingredientId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientsIds">List of ingredients ids</param>
        /// <returns>List of ingredients names</returns>
        public static List<string> GetIngredientsName(List<int> ingredientsIds)
        {
            List<string> ingredientsNames = new List<string>();

            using (var context = new MyDbContext())
            {
                foreach (var item in ingredientsIds)
                {
                    ingredientsNames.Add(context.Ingrediens.Where(x => x.IngredientId == item).Select(x => x.IngredientName).Single());
                }
                return ingredientsNames;

            }
        }
    }
}
