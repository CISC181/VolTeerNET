using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;


namespace VolTeer.SampleControls
{
    public partial class GeoCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string address = ("214+Labrador+Lane");
            string city = ("Townsend");
            string comma = (",");
            string state = ("DE");
            string zip =  ("19734");

            XmlDocument xDoc = new XmlDocument();
            //xDoc.Load("http://maps.googleapis.com/maps/api/geocode/xml?address=1000+Fifth+Avenue,+New+York,+NY&sensor=false");

            var url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}+{1}+{2}+{3}+{4}&sensor=false", address, city, comma, state, zip);
            xDoc.Load(url);

            var lat = xDoc.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText;
            var longitude = xDoc.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText;
        }
    }
}