namespace ProjObiektowe.Models
{
    public class RecipesIngrediens
    {
        public int RecipeId { get; set; }

        public Recipes Recipes { get; set; }

        public int IngredientId { get; set; }

        public Ingrediens Ingrediens { get; set; }


    }
}