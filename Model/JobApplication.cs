using System;

namespace JobTrackerAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public required string Company { get; set; }
        public required string Position { get; set; }
        public required string Status { get; set; } 
        public DateTime DateApplied { get; set; }
    }
}
