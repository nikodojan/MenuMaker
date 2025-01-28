using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MenuMaker_HostedWasm.Shared.Models.Menus
{
    [Table("meal")]
    public class Meal
    { public Meal()
        {
            Dishes = new List<Dish>();
        }

        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int DayId { get; set; }

        [ForeignKey(nameof(DayId))]
        [InverseProperty("Meals")]
        [JsonIgnore]
        public virtual Day Day { get; set; }

        [InverseProperty(nameof(Dish.Meal))]
        public List<Dish> Dishes { get; set; }
    }
}
