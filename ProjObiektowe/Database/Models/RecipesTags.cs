namespace ProjObiektowe.Models
{
    public class RecipesTags
    {

        public int RecipeId { get; set; }
        
        public  Recipes Recipes { get; set; }

        public int TagId { get; set; }

        public Tags Tags { get; set; }
        
    }
}