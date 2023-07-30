using System;
namespace API_Products;

public class Product
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public double Price { get; set; } = 0.0;
	public int Quantify { get; set; } = 0;

	public Product()
	{

	}
}

