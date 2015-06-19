using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Zeptomoby.OrbitTools;

namespace Tracker
{
  public partial class FormTracker : Form
  {
    private Orbit orbit = null;
    private Tle tle = null;
    private Site site = null;
    const double Km2Miles = 0.62137;
    const double ToDeg = 180.0 / Math.PI;
    const double ToRad = Math.PI / 180.0;

    public FormTracker()
    {
      InitializeComponent();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      DateTime now = DateTime.Now;
      lblDate.Text = now.ToLongDateString();
      lblTime.Text = now.ToLongTimeString();

        double mpe = d.Subtract(orbit.EpochTime).TotalMinutes;
        Eci eci = orbit.getPosition(mpe);
        CoordTopo look = site.getLookAngle(eci);
        CoordGeo loc = eci.toGeo();
        double latitude = (loc.Latitude*ToDeg);
        double longitude = (loc.Longitude*ToDeg);
        string ew = (longitude > 180.0) ? "W" : "E";
        string ns = (latitude >= 0.0) ? "N" : "S";
        if (longitude > 180.0)
          longitude = (180 - (longitude - 180));
        latitude = Math.Abs(latitude);
        double altitude = loc.Altitude * Km2Miles;
        double azimuth = (look.Azimuth*ToDeg);
        double elevation = (look.Elevation*ToDeg);
        double range = look.Range * Km2Miles;

      //  at(0, 3, string.Format("Time: {0}", d.ToLocalTime().ToLongTimeString()));
      //  at(0, 5, string.Format(" Pos: {0:f2}{1}/{2:f2}{3} @ {4:f2} miles    ", latitude, ns, longitude, ew, altitude));
      //  if (look.Elevation > 0)
      //    at(0, 7, string.Format("Look: {0:f2}/{1:f2} @ {2:f2}",azimuth, elevation, range));
      //  else
      //    at(0, 7, "Look:");
      //}
    
    }

    private StreamReader GetElements(string source)
    {
      if (source.StartsWith("http:", StringComparison.CurrentCultureIgnoreCase))
      {
        WebRequest request = WebRequest.Create(source);
        WebResponse response = request.GetResponse();
        return new StreamReader(response.GetResponseStream());
      }
      else
      {
        return new StreamReader(source);
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      StreamReader reader = GetElements(cboSource.Text);
      List<ElementSet> list = new List<ElementSet>();
      string[] rawData = reader.ReadToEnd().Split('\n');
      int i = 0;
      while (i < rawData.Length)
      {
        try
        {
          ElementSet elementSet = new ElementSet();
          elementSet.Name = rawData[i++].Trim();
          elementSet.Line1 = rawData[i++].Trim();
          elementSet.Line2 = rawData[i++].Trim();
          list.Add(elementSet);
        }
        catch { }
      } 
      lbSatellites.DataSource = list;
    }

    private void lbSatellites_SelectedIndexChanged(object sender, EventArgs e)
    {
      ElementSet elementSet = lbSatellites.SelectedItem;
      tle = new Tle(elementSet.Name, elementSet.Line1, elementSet.Line2);
      orbit = new Orbit(tle);
      site = new Site(new CoordGeo(41.03 * ToRad, -74.28 * ToRad), 0);
    }
  }
}
