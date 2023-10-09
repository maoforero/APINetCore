using System;
using System.ComponentModel.DataAnnotations;


namespace APINetcore.Models
{
	public class ProductUpdatedDTO
	{
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000,
            ErrorMessage = "Admited values for {o} must have a range: {1} to {2}")]
        public double Price { get; set; }
    }
}

