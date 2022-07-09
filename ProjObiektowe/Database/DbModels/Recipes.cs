using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Models
{
    public  class Recipes

    {
        [Key]
        public int RecipeId { get; set; }
        
        public string? RecipeTitle { get; set; }

        public string? RecipeIngriedients { get; set; }

        public int NoOfPortions { get; set; }

        public string? Description { get; set; }


        public virtual ICollection<RecipesIngrediens>? RecipesIngrediens { get; set; }

        public virtual ICollection<RecipesTags>? RecipesTags { get; set; }


    }
}
