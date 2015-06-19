using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace XmlTestProject
{
  class Chap7
  {
    public static void One()
    {
      string source = @"c:\dev\inventory.xml";
      string styleSheet = @"c:\dev\inventory.xslt";
      string destination = @"c:\dev\inventory.htm";
      XslTransform transform = new XslTransform();
      transform.Load(styleSheet);
      transform.Transform(source, destination);
    }

    private const string ns = "http://www.w3.org/1999/XSL/Transform";

    public static void CreateStyleSheet(string[] args)
    {
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;

      writer.WriteStartDocument();

      writer.WriteStartElement("xsl", "stylesheet", ns);
      writer.WriteAttributeString("version", "1.0");

      writer.WriteStartElement("xsl:output");
      writer.WriteAttributeString("method", "html");
      writer.WriteEndElement();

      CreateRootTemplate(writer);
      CreateInventoryTemplate(writer);
      CreateDateTemplate(writer);
      CreateItemsTemplate(writer);
      CreateItemTemplate(writer);

      writer.WriteEndElement(); // xsl:stylesheet
      writer.WriteEndDocument();
    }

    private static void CreateRootTemplate(XmlWriter writer)
    {

      writer.WriteStartElement("xsl:template");
      writer.WriteAttributeString("match", "/");

      writer.WriteStartElement("html");

      writer.WriteStartElement("head");

      writer.WriteStartElement("title");
      writer.WriteString("Angus Hardware | Online Catalog");
      writer.WriteEndElement(); // title

      writer.WriteEndElement(); // head

      writer.WriteStartElement("xsl:apply-templates");

      writer.WriteEndElement(); // xsl:apply-templates
      writer.WriteEndElement(); // html
      writer.WriteEndElement(); // xsl:template
    }

    private static void CreateInventoryTemplate(XmlWriter writer)
    {
      writer.WriteStartElement("xsl:template");
      writer.WriteAttributeString("match", "inventory");

      writer.WriteStartElement("body");
      writer.WriteAttributeString("bgcolor", "#FFFFFF");

      writer.WriteStartElement("h1");
      writer.WriteString("Angus Hardware");
      writer.WriteEndElement(); // h1

      writer.WriteStartElement("h2");
      writer.WriteString("Online Catalog");
      writer.WriteEndElement(); // h2

      writer.WriteStartElement("xsl:apply-templates");
      writer.WriteEndElement();

      writer.WriteEndElement(); // body
      writer.WriteEndElement(); // xsl:template
    }

    private static void CreateDateTemplate(XmlWriter writer)
    {
      writer.WriteStartElement("xsl:template");
      writer.WriteAttributeString("match", "date");

      writer.WriteStartElement("p");

      writer.WriteString("Current as of ");

      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@month");
      writer.WriteEndElement(); // xsl:value-of

      writer.WriteString("/");

      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@day");
      writer.WriteEndElement(); // xsl:value-of

      writer.WriteString("/");

      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@year");
      writer.WriteEndElement(); // xsl:value-of

      writer.WriteEndElement(); // p
      writer.WriteEndElement(); // xsl-template
    }

    private static void CreateItemsTemplate(XmlWriter writer)
    {
      writer.WriteStartElement("xsl:template");
      writer.WriteAttributeString("match", "items");

      writer.WriteStartElement("p");
      writer.WriteString("Currently available items:");
      writer.WriteEndElement(); // p

      writer.WriteStartElement("table");
      writer.WriteAttributeString("border", "1");

      writer.WriteStartElement("tr");

      writer.WriteStartElement("th");
      writer.WriteString("Product Code");
      writer.WriteEndElement(); // th

      writer.WriteStartElement("th");
      writer.WriteString("Description");
      writer.WriteEndElement(); // th

      writer.WriteStartElement("th");
      writer.WriteString("Unit Price");
      writer.WriteEndElement(); // th

      writer.WriteStartElement("th");
      writer.WriteString("Number in Stock");
      writer.WriteEndElement(); // th

      writer.WriteStartElement("xsl:apply-templates");
      writer.WriteEndElement(); // xsl:apply-templates

      writer.WriteEndElement(); // tr
      writer.WriteEndElement(); // table
      writer.WriteEndElement(); // xsl:template
    }

    private static void CreateItemTemplate(XmlWriter writer)
    {
      writer.WriteStartElement("xsl:template");
      writer.WriteAttributeString("match", "item");

      writer.WriteStartElement("tr");

      writer.WriteStartElement("td");
      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@productCode");
      writer.WriteEndElement(); // xsl:value-of
      writer.WriteEndElement(); // td

      writer.WriteStartElement("td");
      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@description");
      writer.WriteEndElement(); // xsl:value-of
      writer.WriteEndElement(); // td

      writer.WriteStartElement("td");
      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@unitCost");
      writer.WriteEndElement(); // xsl:value-of
      writer.WriteEndElement(); // td

      writer.WriteStartElement("td");
      writer.WriteStartElement("xsl:value-of");
      writer.WriteAttributeString("select", "@quantity");
      writer.WriteEndElement(); // xsl:value-of
      writer.WriteEndElement(); // td

      writer.WriteEndElement(); // xsl:template

      writer.WriteEndElement(); // xsl:
    }
  }
}
