using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Models
{
    public class Ingrediens
    {
        [Key]
        public int IndredientId { get; set; }

        public string IngredientName { get; set; }

        public ICollection<RecipesIngrediens> RecipesIngrediens { get; set; }
    }
}
