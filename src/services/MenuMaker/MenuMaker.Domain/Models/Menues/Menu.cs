using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuMaker_HostedWasm.Shared.Models.Menus
{
    [Table("menu")]
    public class Menu
    {
        public Menu()
        {
            Days = new List<Day>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDateTime { get; set; }

        [InverseProperty(nameof(Day.Menu))]
        public List<Day> Days { get; set; }

        public int CreatedByUser { get; set; }
    }
}
