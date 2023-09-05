using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MenuMaker_HostedWasm.Shared.Models.Menus
{
    [Table("day")]
    public class Day
    {
        public Day()
        {
            Meals = new List<Meal>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int MenuId { get; set; }

        [ForeignKey(nameof(MenuId))]
        [InverseProperty("Days")]
        [JsonIgnore]
        public virtual Menu Menu { get; set; }

        [InverseProperty(nameof(Meal.Day))]
        public List<Meal> Meals { get; set; }
    }
}
