using System;
using APINetcore.DTO;
using APINetcore.Models;

namespace Utils
{
	public static class Utils
	{
		public static ProductDTO TransformToDTO(this Product p)
		{
			return new ProductDTO
			{
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				SKU = p.SKU
			};	
		}
	}
}

