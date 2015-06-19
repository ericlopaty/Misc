using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace linq
{
	class Chapter1
	{
		//	RockStar[] rockStars;
		//	Customer[] customers;
		//	Product[] products;
		//	Order[] orders;

		//	public void Run()
		//	{
		//		InitObjectCollections();
		//		Part6();
		//		Console.ReadLine();
		//	}

		//	// basic linq query returning a string property of object
		//	private void Part1()
		//	{
		//		Program.Header("Chapter 1, Part 1");

		//		var query1 = from c in rockStars where c.Country == "UK" select c.Name;

		//		foreach (string name in query1)
		//			Console.Write(name + ", ");
		//		Console.WriteLine();

		//		IEnumerable<string> query1a = rockStars.Where(c => c.Country == "UK").Select(c => c.Name);

		//		foreach (string s in query1a)
		//			Console.Write(s + ", ");
		//		Console.WriteLine();
		//	}

		//	// basic linq query returning an object
		//	private void Part2()
		//	{
		//		Program.Header("Chapter 1, Part 2");

		//		var query2 = from c in rockStars where c.Country == "UK" select c;

		//		foreach (RockStar rockStar in query2)
		//			Console.Write(rockStar.Name + ", ");
		//		Console.WriteLine();

		//		IEnumerable<RockStar> query2a = rockStars.Where(c => c.Country == "UK");
		//		foreach (RockStar rockStar in query2a)
		//			Console.Write(rockStar.Name + ", ");
		//		Console.WriteLine();
		//	}

		//	private void Part3()
		//	{
		//		Program.Header("Chapter 1, Part 3");

		//		var query1 = from c in rockStars where c.Country == "UK" orderby c.Name select new { c.Name, c.City };
		//		foreach (object c in query1)
		//			Console.WriteLine(c.ToString());

		//		Console.WriteLine();

		//		var query1a = rockStars.Where(c => c.Country == "UK").OrderBy(c => c.Name).Select(c => new { c.Name, c.City });
		//		foreach (object c in query1a)
		//			Console.WriteLine(c.ToString());
		//	}

		//	private void Part4()
		//	{
		//		Program.Header("Chapter 1, Part 4");

		//		var query1 = rockStars.Where(c => c.Country == "UK").OrderBy(c => c.Name).Select(c => c);
		//		List<RockStar> rockStarList = query1.ToList<RockStar>();
		//		foreach (RockStar rs in rockStarList)
		//			Console.WriteLine(rs.Name);

		//		Console.WriteLine();

		//		var query1a = rockStars.Where(c => c.Country == "UK").OrderBy(c => c.Name).Select(c => new { c.Name, c.City });
		//		var l = query1.ToList();
		//		foreach (RockStar rs in l)
		//			Console.WriteLine(rs.Name);
		//	}

		//	private void Part5()
		//	{
		//		Program.Header("Chapter 1, Part 5");

		//		var query =
		//			from p in products
		//			where p.ProductID == 1
		//			from o in p.Orders
		//			select o;

		//		foreach (Order o in query)
		//			Console.WriteLine(o.Product.ProductName + ": " + o.Quantity.ToString());
		//	}

		//	private void Part6()
		//	{
		//		Program.Header("Chapter 1, Part 6");
		//		XNamespace ns="http://schemas.devleap.com/Orders";
		//		XDocument xmlOrders = XDocument.Load("Orders.xml");
		//	}

		//	private void InitObjectCollections()
		//	{
		//		rockStars = new RockStar[] {
		//			new RockStar { Name = "Paul McCartney", City = "Liverpool", Country = "UK" },
		//			new RockStar { Name = "Billy Joel", City = "Hicksville", Country = "US" },
		//			new RockStar { Name = "John Lennon", City = "Liverpool", Country = "UK" },
		//			new RockStar { Name = "George Harrison", City = "Liverpool", Country = "UK" },
		//			new RockStar { Name = "Ringo Starr", City = "Liverpool", Country = "UK" },
		//			new RockStar { Name = "John Bon Jovi", City = "Perth Amboy, NJ", Country = "US" },
		//			new RockStar { Name = "Bruce Springsteen", City = "Long Branch, NJ", Country = "US" },
		//			new RockStar { Name = "Phil Collins", City = "Chiswick", Country = "UK" },
		//			new RockStar { Name = "Neil Peart", City = "Hamilton, ON", Country = "Canada" },
		//			new RockStar { Name = "Geddy Lee", City = "Willowdale, ON", Country = "Canada" },
		//			new RockStar { Name = "Alex Lifeson", City = "", Country = "Canada" }
		//		};

		//		customers = new Customer[] {
		//			new Customer { Name = "IBM", City = "Poughkeepsie, NY" },
		//			new Customer { Name = "Apple", City = "Cupertino, CA" },
		//			new Customer { Name = "Microsoft", City = "Redmond, WA" }
		//		};

		//		products = new Product[] {
		//			new Product { ProductID = 1, Price = 3.99M, ProductName = "Pringles" },
		//			new Product { ProductID = 2, Price = 4.49M, ProductName = "Oreos" },
		//			new Product { ProductID = 3, Price = 9.99M, ProductName = "Vanilla Wafers" },
		//			new Product { ProductID = 4, Price = 7.99M, ProductName = "Cheesecake" },
		//			new Product { ProductID = 5, Price = 1.99M, ProductName = "Twinkies" },
		//			new Product { ProductID = 6, Price = 2.99M, ProductName = "Apple Pie" }
		//		};

		//		orders = new Order[] {
		//			new Order { Quantity = 4, Product = products[0], Customer = customers[0] },
		//			new Order { Quantity = 8, Product = products[1], Customer = customers[0] },
		//			new Order { Quantity = 12, Product = products[2], Customer = customers[0] },
		//			new Order { Quantity = 16, Product = products[3], Customer = customers[1] },
		//			new Order { Quantity = 20, Product = products[4], Customer = customers[1] },
		//			new Order { Quantity = 24, Product = products[5], Customer = customers[1] },
		//			new Order { Quantity = 28, Product = products[0], Customer = customers[2] },
		//			new Order { Quantity = 32, Product = products[1], Customer = customers[2] },
		//			new Order { Quantity = 36, Product = products[2], Customer = customers[2] },
		//			new Order { Quantity = 40, Product = products[3], Customer = customers[2] },
		//			new Order { Quantity = 44, Product = products[4], Customer = customers[2] },
		//			new Order { Quantity = 48, Product = products[5], Customer = customers[2] }
		//		};

		//		customers[0].Orders = new Order[] { orders[0], orders[1], orders[2] };
		//		customers[1].Orders = new Order[] { orders[3], orders[4], orders[5] };
		//		customers[2].Orders = new Order[] { orders[6], orders[7], orders[8], orders[9], orders[10], orders[11] };

		//		products[0].Orders = new Order[] { orders[0], orders[6] };
		//		products[1].Orders = new Order[] { orders[1], orders[7] };
		//		products[2].Orders = new Order[] { orders[2], orders[8] };
		//		products[3].Orders = new Order[] { orders[3], orders[9] };
		//		products[4].Orders = new Order[] { orders[4], orders[10] };
		//		products[5].Orders = new Order[] { orders[5], orders[11] };

		//	}
	}

	//class RockStar
	//{
	//	public string Name { get; set; }
	//	public string City { get; set; }
	//	public string Country { get; set; }
	//}

	//class Customer
	//{
	//	public string CustomerID;
	//	public string Name;
	//	public string City;
	//	public Order[] Orders;
	//}

	//struct Order
	//{
	//	public int Quantity;
	//	public Product Product;
	//	public Customer Customer;
	//}

	//class Product
	//{
	//	public int ProductID;
	//	public decimal Price;
	//	public string ProductName;
	//	public Order[] Orders;
	//}
}