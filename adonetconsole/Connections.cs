using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace adonetconsole
{
  class Connections
  {
    public static void ChangeDatabase()
    {
      using (SqlConnection cn = new SqlConnection(Util.Connection("Northwind")))
      {
        cn.Open();
        Console.WriteLine("DATABASE: {0}", cn.Database);
        cn.ChangeDatabase("pubs");
        Console.WriteLine("DATABASE: {0}", cn.Database);
      }
    }

    public static string Connection()
    {
      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
      builder.DataSource = "(local)";
      builder.InitialCatalog = "Northwind";
      builder.IntegratedSecurity = true;
      builder.MinPoolSize = 0;
      builder.MaxPoolSize = 10;
      builder.Pooling = true;
      builder.AsynchronousProcessing = true;
      return builder.ConnectionString;
    }

    public static void GetSchema()
    {
      using (SqlConnection cn = new SqlConnection(Connection()))
      {
        cn.Open();
        DataTable tbl;

        Console.WriteLine("GetSchema");
        tbl = cn.GetSchema();
        Util.DumpTable(tbl);
        Console.ReadLine();

        Console.WriteLine("Databases");
        Util.DumpTable(cn.GetSchema("databases"));
        Console.ReadLine();

        Console.WriteLine("Users");
        Util.DumpTable(cn.GetSchema("users"));
        Console.ReadLine();

        Console.WriteLine("Tables");
        Util.DumpTable(cn.GetSchema("tables"));
        Console.ReadLine();

        Console.WriteLine("Columns");
        Util.DumpTable(cn.GetSchema("columns"));
        Console.ReadLine();

        Console.WriteLine("Procedures");
        Util.DumpTable(cn.GetSchema("procedures"));
        Console.ReadLine();

        Console.WriteLine("Columns (Customers)");
        string[] restrictions;
        restrictions = new string[] { "Northwind", "dbo", "Customers", null };
        tbl = cn.GetSchema("Columns", restrictions);
        Util.DumpTable(tbl);
        Console.ReadLine();

        Console.WriteLine("Restrictions");
        tbl = cn.GetSchema("restrictions");
        Util.DumpTable(tbl);
        Console.ReadLine();
      }
    }

    private static void Configuration()
    {
      /*
      string strConnectionName = "Local SQLExpress";
      ConnectionStringSettings setting;
      setting = ConfigurationManager.ConnectionStrings[strConnectionName];

      if (setting == null)
      {
          //Create new entry in app.config
          setting = new ConnectionStringSettings();
          setting.Name = strConnectionName;
          setting.ConnectionString = @"Data Source=.\SQLExpress;" +
                                      "Initial Catalog=Northwind;" +
                                      "Integrated Security=True;";

          Configuration config;
          config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
          config.ConnectionStrings.ConnectionStrings.Add(setting);
          config.Save();
      }

      using (SqlConnection cn = new SqlConnection(setting.ConnectionString)) {
          try {
              cn.Open();
              Console.WriteLine("Success!");
          }
          catch (Exception ex) {
              Console.WriteLine(ex.ToString());
          }
      }

      config.ConnectionStrings.SectionInformation.ProtectSection(null);
       */
    }
  }
}
