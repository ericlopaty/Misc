using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace linq
{
	class Chapter2
	{
		public void Run()
		{
			//Developer[] developers = new Developer[] {
			//	new Developer { Name = "Paolo", Language = "C#" },
			//	new Developer { Name = "Marco", Language = "C#" },
			//	new Developer { Name = "Frank", Language = "VB.NET" }
			//};

			//Category[] categories = new Category[] {
			//	new Category { IdCategory = 1, Name = "Pasta"},
			//	new Category { IdCategory = 2, Name = "Beverages"},
			//	new Category { IdCategory = 3, Name = "Other food"},
			//};

			//Product[] products = new Product[] {
			//	new Product { IdProduct = "PASTA01", IdCategory = 1, Description = "Tortellini" },
			//	new Product { IdProduct = "PASTA02", IdCategory = 1, Description = "Spaghetti" },
			//	new Product { IdProduct = "PASTA03", IdCategory = 1, Description = "Fusilli" },
			//	new Product { IdProduct = "BEV01", IdCategory = 2, Description = "Water" },
			//	new Product { IdProduct = "BEV02", IdCategory = 2, Description = "Orange Juice" },
			//};

			//var query = from d in developers where d.Language == "C#" select d.Name;
			//foreach (string s in query)
			//	Console.WriteLine(s);

			//var query = developers.Where(d => d.Language == "C#");
			//foreach (Developer d in query)
			//	Console.WriteLine(d.Name);

			//var query = developers.Where(d => d.Language == "C#").Select(d => d.Name);
			//foreach (string s in query)
			//	Console.WriteLine(s);

			//var filteredDevelopers = developers.Where(delegate(Developer d) { return d.Language == "C#"; });
			//var filteredDevelopers = developers.Where(d => d.Language == "C#");

			//Func<Developer, bool> filteringPredicate = d => d.Language == "C#";
			//Func<Developer, string> selectionPredicate = d => d.Name;

			//IEnumerable<string> developersUsingCSharp = developers.Where(filteringPredicate).Select(selectionPredicate);
			//foreach (string s in developersUsingCSharp)
			//	Console.WriteLine(s);

			//var query = from Developer d in developers
			//			 where d.Language == "C#"
			//			 select d;
			//foreach (Developer d in query)
			//	Console.WriteLine(d.Name);

			//var query = from d in developers group d by d.Language;
			//foreach (var group in query)
			//{
			//	Console.WriteLine(group.Key);
			//	foreach (var d in group)
			//		Console.WriteLine("\t{0}", d.Name);
			//}

			//var query = 
			//	from d in developers 
			//	group d by new { d.Language, ageCluster = (d.Age / 10) * 10 };
			//foreach (var group in query)
			//{
			//	Console.WriteLine(group.Key);
			//	foreach (var d in group)
			//		Console.WriteLine("\t{0}", d.Name);
			//}

			//var query =
			//	from d in developers
			//	group d by d.Language into groups
			//	orderby groups.Count()
			//	select new
			//	{
			//		Language = groups.Key,
			//		Count = groups.Count()
			//	};
			//foreach (var group in query)
			//	Console.WriteLine("Language {0} contains {1} members.", group.Language, group.Count);

			//var categoriesAndProducts =
			//	from c in categories
			//	join p in products on c.IdCategory equals p.IdCategory
			//	select new
			//	{
			//		c.IdCategory,
			//		CategoryName = c.Name,
			//		Product = p.Description
			//	};
			//foreach (var item in categoriesAndProducts)
			//	Console.WriteLine(item);

			//var categoriesAndProducts =
			//	from c in categories
			//	join p in products on c.IdCategory equals p.IdCategory
			//		into ProductsByCategory
			//	select new
			//	{
			//		c.IdCategory,
			//		CategoryName = c.Name,
			//		Products = ProductsByCategory
			//	};
			//foreach (var category in categoriesAndProducts)
			//{
			//	Console.WriteLine("{0} - {1}", category.IdCategory, category.CategoryName);
			//	foreach (var product in category.Products)
			//		Console.WriteLine("\t{0}", product.Description);
			//}

			//var categoriesAndProducts =
			//	from c in categories
			//	join p in products on c.IdCategory equals p.IdCategory
			//	into productsByCategory
			//	from pc in productsByCategory.DefaultIfEmpty(new Product { IdProduct = string.Empty, Description = string.Empty, IdCategory = 0 })
			//	select new
			//	{
			//		c.IdCategory,
			//		CategoryName = c.Name,
			//		Product = pc.Description
			//	};
			//foreach (var item in categoriesAndProducts)
			//	Console.WriteLine(item);

			//var categoriesByProductNumberQuery =
			//	from c in categories
			//	join p in products on c.IdCategory equals p.IdCategory
			//	into ProductsByCategory
			//	let productsCount = ProductsByCategory.Count()
			//	orderby productsCount
			//	select new { c.IdCategory, productsCount };
			//foreach (var item in categoriesByProductNumberQuery)
			//	Console.WriteLine(item);


			Console.ReadLine();
		}
	}

	//class Developer
	//{
	//	public string Name;
	//	public string Language;
	//	public int Age;
	//}

	//public class Category
	//{
	//	public int IdCategory { get; set; }
	//	public string Name { get; set; }
	//}

	//public class Product
	//{
	//	public string IdProduct { get; set; }
	//	public int IdCategory { get; set; }
	//	public string Description { get; set; }
	//}
}
