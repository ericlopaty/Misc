using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace XmlTestProject
{
  class Chap6
  {
    static string fileName;
    static string xpathExpression = "//items/item";

    static Chap6()
    {
      fileName = Path.Combine(Program.DevRoot, "inventory.xml");
    }

    public static void One()
    {
      XmlDocument document = new XmlDocument();
      document.Load(fileName);
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;
      XmlNode node = document.SelectSingleNode(xpathExpression);
      node.WriteTo(writer);
      writer.Close();
    }

    public static void Two()
    {
      XmlDocument document = new XmlDocument();
      document.Load(fileName);
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;
      XmlNodeList nodeList = document.SelectNodes(xpathExpression);
      Console.WriteLine("{0} nodes found", nodeList.Count);
      foreach (XmlNode node in nodeList)
        node.WriteTo(writer);
      writer.Close();
    }

    public static void Three()
    {
      XmlDocument document = new XmlDocument();
      document.Load(fileName);
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;

      XPathNavigator navigator = document.CreateNavigator();
      XPathNodeIterator iterator = navigator.Select("//items/item");
      Console.WriteLine("{0} nodes matched.", iterator.Count);
      while (iterator.MoveNext())
      {
        XmlNode node = ((IHasXmlNode)iterator.Current).GetNode();
        node.WriteTo(writer);
      }
      writer.Close();
    }

    public static void Four()
    {
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;

      XPathDocument document = new XPathDocument(fileName);
      XPathNavigator navigator = document.CreateNavigator();
      XPathNodeIterator iterator = navigator.Select(xpathExpression);
      Console.WriteLine("{0} nodes matched.", iterator.Count);
      while (iterator.MoveNext())
      {
        Console.WriteLine(iterator.Current.LocalName);
        Console.WriteLine(iterator.Current.GetAttribute("productCode",""));
        Console.WriteLine();
      }
      writer.Close();
    }
  }
}
