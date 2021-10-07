using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommandsService.Domain.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ExternalID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
