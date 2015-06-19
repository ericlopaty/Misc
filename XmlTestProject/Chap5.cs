using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace XmlTestProject
{
  public static class Chap5
  {
    private static readonly string[] versions=new string[] {"1.0","2.0"};
 
    private static readonly string[] features=new string[] 
    {
      "Core","XML","HTML","Views","Stylesheets","CSS","CSS2","Events",
      "UIEvents","MouseEvents","MutationEvents","HTMLEvents",
      "Range","Traversal"
    };

    public static void One()
    {
      XmlImplementation impl=new XmlImplementation();
      foreach (string version in versions)
      {
        foreach (string feature in features)
        {
          Console.WriteLine("{0} {1}={2}",feature,version,impl.HasFeature(feature,version));
        }
      }
    }

    public static void Two()
    {
      XmlImplementation impl = new XmlImplementation();
      XmlDocument document = impl.CreateDocument();
      
      XmlDeclaration decl = document.CreateXmlDeclaration("1.0", null, null);
      document.AppendChild(decl);
      
      XmlElement element = document.CreateElement("inventory");
      document.AppendChild(element);

      XmlElement dateElement = document.CreateElement("date");
      dateElement.SetAttribute("year", "2002");
      dateElement.SetAttribute("month", "6");
      dateElement.SetAttribute("day", "22");
      document.DocumentElement.AppendChild(dateElement);

      XmlElement itemsElement = document.CreateElement("items");
      document.DocumentElement.AppendChild(itemsElement);

      XmlElement itemElement = document.CreateElement("item");
      itemElement.SetAttribute("quantity", "15");
      itemElement.SetAttribute("productCode", "R-273");
      itemElement.SetAttribute("description", "14.4 Vold Cordless Drill");
      itemsElement.AppendChild(itemElement);

      itemElement = document.CreateElement("item");
      itemElement.SetAttribute("quantity", "23");
      itemElement.SetAttribute("productCode", "1632S");
      itemElement.SetAttribute("description", "12 Piece Drill Bit Set");
      itemsElement.AppendChild(itemElement);

      //XmlNodeList elements = itemsElement.ChildNodes;
      XmlNodeList elements = itemsElement.GetElementsByTagName("item"); 
      foreach (XmlElement currentElement in elements)
      {
        double cost=0;
        string productCode=currentElement.GetAttribute("productCode");
        switch (productCode)
        {
          case "R-273":
            cost=189.95;
            break;
          case "1632S":
            cost=14.95;
            break;
          default:
            throw new ApplicationException("Unknown productCode: "+productCode);
        }
        currentElement.SetAttribute("unitCost", cost.ToString());
      }

      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;
      document.WriteTo(writer);

      document.Save("c:\\dev\\inventory.xml");
    }

    public static void Three()
    {
      XmlDocument document = new XmlDocument();
      document.Load("c:\\dev\\inventory.xml");

      XmlNodeList items = document.SelectNodes("//items/item");
      foreach (XmlElement item in items)
      {
        Console.WriteLine("{0} units of {1} in stock",
          item.GetAttribute("quantity"),
          item.GetAttribute("productCode"));
      }
    }

    public static void Four()
    {
      XmlDocument document = new XmlDocument();
      document.Load(Path.Combine(Program.DevRoot, "inventory.xml"));
      XmlNodeList items = document.SelectNodes("//items/item");
      ArrayList list = new ArrayList(items.Count);
      foreach (XmlElement item in items)
      {
        list.Add(new UnitInventory(
          item.GetAttribute("productCode"),
          int.Parse(item.GetAttribute("quantity")),
          item.GetAttribute("description"),
          double.Parse(item.GetAttribute("unitCost"))
          ));
      }
      list.Sort();
      foreach (UnitInventory listItem in list)
        Console.WriteLine(listItem);
    }

    public static void Five()
    {
      XmlDocument document = new XmlDocument();
      document.Load(Path.Combine(Program.DevRoot, "inventory.xml"));
      try
      {
        XmlElement item = (XmlElement)document.SelectSingleNode("//items/item[@productCode='R-273']");
        int quantity = int.Parse(item.GetAttribute("quantity"));
        quantity++;
        item.SetAttribute("quantity", quantity.ToString());
        document.Save(Path.Combine(Program.DevRoot, "inventory.xml"));
      }
      catch (Exception x)
      {
        Console.WriteLine("Error: {0}", x.Message);
      }
    }
  }

  class UnitInventory : IComparable
  {
    private string productCode;
    private int quantity;
    private string description;
    private double unitCost;

    public UnitInventory(string productCode, int quantity, string description, double unitCost)
    {
      this.productCode = productCode;
      this.quantity = quantity;
      this.description = description;
      this.unitCost = unitCost;
    }

    public int CompareTo(object other)
    {
      UnitInventory otherInventory = (UnitInventory)other;
      return productCode.CompareTo(otherInventory.productCode);
    }

    public override string ToString()
    {
      return quantity + " units of " + productCode + ", " + description + ", in stock at $" + unitCost;
    }
  }
}

