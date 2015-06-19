using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Schema;

namespace XmlTestProject
{
  class Chap2
  {
    public static void One()
    {
      using (Stream stream = File.OpenRead(Path.Combine(Program.DevRoot, "inventory.xml")))
      {
        int bytesToRead = 1024;
        int bytesRead = 0;
        byte[] buffer = new byte[bytesToRead];

        do
        {
          bytesRead = stream.Read(buffer, 0, bytesToRead);
          Console.Write(Encoding.ASCII.GetChars(buffer, 0, bytesRead));
        } while (bytesToRead == bytesRead);
        stream.Close();
      }
    }

    public static void Two()
    {
      using (TextReader reader = File.OpenText(Path.Combine(Program.DevRoot, "inventory.xml")))
      {
        while (reader.Peek() != -1)
        {
          string line = reader.ReadLine();
          Console.WriteLine(line);
        }
        reader.Close();
      }
    }

    public static void Three()
    {
      using (TextReader reader = File.OpenText(Path.Combine(Program.DevRoot, "inventory.xml")))
      {
        string line;
        while ((line=reader.ReadLine())!=null)
        {
          Console.WriteLine(line);
        }
        reader.Close();
      }
    }

    public static void Four()
    {
      //WebRequest request = WebRequest.Create("http://idiotarmy.org/inventory.xml");
      //WebRequest request = WebRequest.Create("file://c:/dev/inventory.xml");
      //WebResponse response = request.GetResponse();
      
      //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://idiotarmy.org/inventory.xml");
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com/calendar/feeds/ericlopaty%40gmail.com/private-3c8b66507cc5c220f3418993de4cda95/basic");
      request.Proxy = new WebProxy();
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();

      Stream stream = response.GetResponseStream();
      using (StreamReader reader = new StreamReader(stream))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          Console.Write(line);
          Console.ReadLine();
        }
        reader.Close();
      }
    }

    public static void Five()
    {
      string url = @"c:\dev\po.xml"; //args[0];
      XmlTextReader reader = new XmlTextReader(url);

      int c = 0;
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.XmlDeclaration)
          NodeWrite(ref c, "XMLDECLARATION", reader);
        if (reader.NodeType == XmlNodeType.CDATA)
          NodeWrite(ref c, "CDATA", reader);
        if (reader.NodeType == XmlNodeType.Comment)
          NodeWrite(ref c, "COMMENT", reader);
        if (reader.NodeType == XmlNodeType.Element)
          NodeWrite(ref c, "ELEMENT", reader);
        if (reader.NodeType == XmlNodeType.EndElement)
          NodeWrite(ref c, "ENDELEMENT", reader);
        if (reader.NodeType == XmlNodeType.Text)
          NodeWrite(ref c, "TEXT", reader);
        //if (reader.NodeType == XmlNodeType.Whitespace)
        //  NodeWrite(count, "WHITESPACE", reader);
        if (reader.NodeType == XmlNodeType.Document)
          NodeWrite(ref c, "DOCUMENT", reader);
        if (reader.NodeType == XmlNodeType.DocumentFragment)
          NodeWrite(ref c, "DOCUMENTFRAGMENT", reader);
        if (reader.NodeType == XmlNodeType.DocumentType)
          NodeWrite(ref c, "DOCUMENTTYPE", reader);
        if (reader.NodeType == XmlNodeType.EndEntity)
          NodeWrite(ref c, "ENDENTITY", reader);
        if (reader.NodeType == XmlNodeType.Entity)
          NodeWrite(ref c, "ENTITY", reader);
        if (reader.NodeType == XmlNodeType.EntityReference)
          NodeWrite(ref c, "ENTITYREFERENCE", reader);
        if (reader.NodeType == XmlNodeType.None)
          NodeWrite(ref c, "NONE", reader);
        if (reader.NodeType == XmlNodeType.Notation)
          NodeWrite(ref c, "NOTATION", reader);
        if (reader.NodeType == XmlNodeType.ProcessingInstruction)
          NodeWrite(ref c, "PROCESSINGINSTRUCTION", reader);
        if (reader.NodeType == XmlNodeType.SignificantWhitespace)
          NodeWrite(ref c, "SIGNIFICANTWHITESPACE", reader);
        if (reader.NodeType == XmlNodeType.Attribute)
          NodeWrite(ref c, "ATTRIBUTE", reader);
        if (reader.HasAttributes)
          for (int i = 0; i < reader.AttributeCount; i++)
            Console.WriteLine(">[Attribute \"{0}\"]", reader.GetAttribute(i));
      }
      Console.ReadLine();
    }

    public static void Six()
    {
      string url = @"c:\dev\po.xml"; //args[0];
      XmlTextReader reader = new XmlTextReader(url);

      StringBuilder pickList = new StringBuilder();
      pickList.Append("Angus Hardware PickList\n");
      pickList.Append("=======================\n");
      while (reader.Read())
      {
        if (reader.NodeType==XmlNodeType.Element)
        {
          switch(reader.LocalName)
          {
            case "po":
              pickList.Append(POElementToString(reader));
              break;
            case "date":
              pickList.Append(DateElementToString(reader));
              break;
            case "address":
              reader.MoveToAttribute("type");
              if (reader.Value=="shipping")
              {
                pickList.Append(AddressElementToString(reader));
              }
              else
              {
                reader.Skip();
              }
              break;
            case "items":
              pickList.Append(ItemsElementToString(reader));
              break;
          }
        }      
      }
      Console.WriteLine(pickList.ToString());
    }

    public static void Seven()
    {
      string url = @"c:\dev\po.xml";
      XmlTextReader textReader = new XmlTextReader(url);
      XmlValidatingReader reader = new XmlValidatingReader(textReader);
      reader.ValidationType = ValidationType.DTD;
      reader.ValidationEventHandler += new ValidationEventHandler(HandleValidationError);
      StringBuilder pickList = new StringBuilder();
      pickList.Append("Angus Hardware PickList\n");
      pickList.Append("=======================\n");
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.Element)
        {
          switch (reader.LocalName)
          {
            case "po":
              pickList.Append(POElementToString(textReader));
              break;
            case "date":
              pickList.Append(DateElementToString(textReader));
              break;
            case "address":
              reader.MoveToAttribute("type");
              if (reader.Value == "shipping")
                pickList.Append(AddressElementToString(reader));
              else
                textReader.Skip();
              break;
            case "items":
              pickList.Append(ItemsElementToString(reader));
              break;
          }
        }
      }
      Console.WriteLine(pickList.ToString());
    }

    private static void HandleValidationError(object sender, ValidationEventArgs e)
    {
      Console.WriteLine(e.Message);
    }

    static void NodeWrite(ref int count, string label, XmlReader reader)
    {
      count++;
      Console.WriteLine("*[{1} Name=\"{2}\"] Value=\"{3}\"", count, label, reader.LocalName, reader.Value.Trim());
    }

    private static string POElementToString(XmlReader reader)
    {
      string id = reader.GetAttribute("id");
      StringBuilder poBlock = new StringBuilder();
      poBlock.Append("PO Number: ").Append(id).Append("\n\n");
      return poBlock.ToString();
    }

    private static string DateElementToString(XmlReader reader)
    {
      int year = Int32.Parse(reader.GetAttribute("year"));
      int month = Int32.Parse(reader.GetAttribute("month"));
      int day = Int32.Parse(reader.GetAttribute("day"));
      DateTime date = new DateTime(year, month, day);
      StringBuilder dateBlock = new StringBuilder();
      dateBlock.Append("Date: ").Append(date.ToString("D")).Append("\n\n");
      return dateBlock.ToString();
    }

    private static string AddressElementToString(XmlReader reader)
    {
      StringBuilder addressBlock = new StringBuilder();
      addressBlock.Append("Shipping Address:\n");
      while (reader.Read() && (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.Whitespace))
      {
        switch (reader.LocalName)
        {
          case "name":
          case "company":
          case "street":
          case "zip":
            addressBlock.Append(reader.ReadString());
            addressBlock.Append("\n");
            break;
          case "city":
            addressBlock.Append(reader.ReadString());
            addressBlock.Append(", ");
            break;
          case "state":
            addressBlock.Append(reader.ReadString());
            addressBlock.Append(" ");
            break;
        }
      }
      addressBlock.Append("\n");
      return addressBlock.ToString();
    }

    private static string ItemsElementToString(XmlReader reader)
    {
      StringBuilder itemsBlock = new StringBuilder();
      itemsBlock.Append("Quantity Product Code Description\n");
      itemsBlock.Append("======== ============ ===========\n");
      while (reader.Read() && (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.Whitespace))
      {
        switch (reader.LocalName)
        {
          case "item":
            int quantity = Int32.Parse(
            reader.GetAttribute("quantity"));
            string productCode = reader.GetAttribute("productCode");
            string description = reader.GetAttribute("description");
            itemsBlock.AppendFormat(" {0,6}  {1,11}  {2}\n", quantity, productCode, description);
            break;
        }
      }
      return itemsBlock.ToString();
    }
  }
}

/*
<?xml version="1.0"?>
<po id="PO1456">
  <date year="2002" month="6" day="14" />
  <address type="shipping">
    <name>Frits Mendels</name>
    <street>152 Cherry St</street>
    <city>San Francisco</city>
    <state>CA</state>
    <zip>94045</zip>
  </address>
  <address type="billing">
    <name>Frits Mendels</name>
    <street>PO Box 6789</street>
    <city>San Francisco</city>
    <state>CA</state>
    <zip>94123-6798</zip>
  </address>
  <items>
    <item quantity="1" 
          productCode="R-273" 
          description="14.4 Volt Cordless Drill" 
          unitCost="189.95" />
    <item quantity="1" 
          productCode="1632S" 
          description="12 Piece Drill Bit Set" 
          unitCost="14.95" /> 
  </items>
</po>
*/
