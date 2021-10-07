using System;
using System.ComponentModel.DataAnnotations;

namespace CommandsService.Domain.Models
{
    public class Command
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public Guid PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
