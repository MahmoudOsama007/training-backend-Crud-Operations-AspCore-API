using System;
using System.ComponentModel.DataAnnotations;

namespace training_backend.models
{
    public class TrainingInitiative
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        // Add this property to track the last update date
        public DateTime? UpdateDate { get; set; } // Nullable if you want it to be optional at first
    }
}
