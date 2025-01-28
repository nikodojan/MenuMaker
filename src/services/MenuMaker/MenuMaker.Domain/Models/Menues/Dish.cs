using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MenuMaker_HostedWasm.Shared.Models.Menus
{
    [Table("dish")]
    public class Dish
    {
        [Key]
        public Guid Id { get; set; }
        
        public int MealId { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [ForeignKey(nameof(MealId))]
        [InverseProperty("Dishes")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        public int? RecipeId { get; set; }

        //[ForeignKey(nameof(RecipeId))]
        //public Recipe Recipe { get; set; }

        public int Portions { get; set; } = 1;
    }
}
