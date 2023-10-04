using System;
using System.ComponentModel.DataAnnotations;

namespace APINetcore.DTO
{
	public class ProductDTO
	{
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000,
            ErrorMessage = "Range of {0} admited: {1} to {2}.")]
        public double Price { get; set; }

        [Required]
        public string SKU { get; set; }
	}
}

