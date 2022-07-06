using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjObiektowe.Models
{
    public class Tags
    {
        [Key]
        public int TagId { get; set; }

        public string TagName { get; set; }

        public virtual ICollection<RecipesTags> RecipesTags { get; set; }
    }
}
