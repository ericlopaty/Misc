using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace XmlTestProject
{
  class Chap9
  {
  }

  [Serializable]
  public enum AddressType
  {
    Home, Office, Billing, Shipping,
    Mailing, Day, Evening, FAX
  }

  [Serializable]
  public enum State
  {
    AK, AL, AR, AZ, CA, CO, CT, DC, DE, FL,
    GA, HI, IA, ID, IL, IN, KS, KY, LA, MA,
    MD, ME, MI, MN, MO, MS, MT, NC, ND, NE,
    NH, NJ, NM, NV, NY, OH, OK, OR, PA, PR,
    RI, SC, SD, TN, TX, UT, VA, WA, WI, WV, WY
  }

  [Serializable]
  public class Address
  {
    public AddressType AddressType;
    public string[] Street;
    public string City;
    public State State;
    public string Zip;
  }

  [Serializable]
  public class TelephoneNumber
  {
    public string AreaCode;
    public string Exchange;
    public string Number;
  }

  [Serializable]
  public class Employee
  {
    public string FirstName;
    public string MiddleInitial;
    public string LastName;
    public Address[] Addresses;
    public TelephoneNumber[] TelephoneNumbers;
    public DateTime HireDate;
  }

  [Serializable]
  public class Personnel
  {
    public Employee[] Employees;
  }

  public static class Serializer
  {
    public static void main(string[] args)
    {
      IFormatter formatter = new SoapFormatter();
      Personnel personnel = CreatePersonnel();
      formatter.Serialize(File.OpenWrite("PersonnelSoap.xml"), personnel);
    }

    private static Personnel CreatePersonnel()
    {
      Personnel personnel = new Personnel();
      personnel.Employees = new Employee[] { new Employee() };
      personnel.Employees[0].FirstName = "Niel";
      personnel.Employees[0].MiddleInitial = "M";
      personnel.Employees[0].LastName = "Bornstein";

      personnel.Employees[0].Addresses = new Address[] { new Address() };
      personnel.Employees[0].Addresses[0].AddressType = AddressType.Home;
      personnel.Employees[0].Addresses[0].Street =
        new string[] { "999 Wilford Trace" };
      personnel.Employees[0].Addresses[0].City = "Atlanta";
      personnel.Employees[0].Addresses[0].State = State.GA;
      personnel.Employees[0].Addresses[0].Zip = "30037";
      personnel.Employees[0].HireDate = new DateTime(2001, 1, 1);

      return personnel;
    }
  }
}

/*

<?xml version ="1.0" encoding="UTF-8" ?>
<SOAP-ENV:Envelope
  xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SOAP-ENV:Header>
    <ns1:terms xmlns:ns1="urn:angushardware"
      SOAP-ENV:MustUnderstand="1">Net 30</ns1:terms>
  </SOAP-ENV:Header>
  <SOAP-ENV:Body>
    <ns1:placeOrder
      SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
      <productCode xsi:type="xsd:string">99HGTY</productCode>
      <quantity xsi:type="xsd:int">300</quantity>
    </ns1:placeOrder>
  </SOAP-ENV:Body>

</SOAP-ENV:Envelope>

<?xml version ="1.0" encoding="UTF-8" ?>
<SOAP-ENV:Envelope
  xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:xsd="http://www.w3.org/2001/XMLSchema">

  <SOAP-ENV:Body>
    <ns1:placeOrderResponse xmlns:ns1="urn:angushardware"
      SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
      <ns1:deliveryDate xsi:type="xsd:date">2002-09-04</deliveryDate>
    </ns1:placeOrderResponse>
  </SOAP-ENV:Body>
</SOAP-ENV:Envelope>

<?xml version ="1.0" encoding="UTF-8" ?>
<SOAP-ENV:Envelope
  xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SOAP-ENV:Body>
    <SOAP-ENV:Fault>
      <SOAP-ENV:faultCode xsi:type="xsd:string">
        SOAP-ENV:MustUnderstand
      </SOAP-ENV:faultCode>
      <SOAP-ENV:faultString xsi:type="xsd:string">
        The server did not understand the header element ns1:terms
      </SOAP-ENV:faultString>
      <SOAP-ENV:faultActor xsi:type="xsd:string">
        Smith's Sprocket Company
      </SOAP-ENV:faultActor>
    </SOAP-ENV:Fault>
  </SOAP-ENV:Body>

</SOAP-ENV:Envelope>

*/