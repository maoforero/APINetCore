﻿using System;
using APINetcore.Models;

namespace APINetcore.Repository
{
	public interface IProductsInMemory
	{
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);


    }
}

