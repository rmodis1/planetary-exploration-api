using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Data.DTO
{
    public class MissionFormDto
    {    
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PlanetId { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = "";

        [ForeignKey("PlanetId")]
        public virtual Planet Planet { get; set; } = null!;

        public virtual List<Discovery> Discoveries { get; set; } = [];
    }
}