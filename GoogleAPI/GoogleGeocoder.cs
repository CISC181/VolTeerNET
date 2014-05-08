using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using VolTeer.DomainModels;
using VolTeer.DomainModels.Service;
using System.Configuration;
using System.Collections.Specialized;

namespace VolTeer.GoogleAPI
{
    public class GoogleGeocoder : IGeocoder
    {
        /// <summary>
        /// Gets a value indicating whether to send API requests via HTTPS.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sending API requests via HTTPS; otherwise, <c>false</c>.
        /// </value>
        public bool IsSSL { get; private set; }

        private string Protocol
        {
            get { return IsSSL ? "https://" : "http://"; }
        }

        protected string ApiGeoCode
        {
            // @TODO: get the ConfigurationManager.AppSettings call to work
            get { return Protocol + "maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false&key=AIzaSyDSBBqZS-nRournmpfJJ4f2QhcXx3wOagk"; }// ConfigurationManager.AppSettings["API_GEOCODE"]; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleGeocoder"/> class.
        /// </summary>
        /// <param name="isSSL">Indicates whether to send API requests via HTTPS.</param>
        public GoogleGeocoder(bool isSSL)
        {
            IsSSL = isSSL;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleGeocoder"/> class and defaults to transmission over HTTP. 
        /// </summary>
        public GoogleGeocoder() : this(true) { }

        public string GetLatLongFromAddress(GoogleAddress address)
        {
            if (address.FormattedAddress == null)
            {
                return "<coordinate>\n" +
                          "<lat>unknown</lat>\n" +
                          "<lon>unknown</lon>\n" +
                       "</coordinate>";
            }
            
            XDocument doc = XDocument.Load(String.Format(ApiGeoCode, address.FormattedAddress.Replace(" ", "+")));
          
            var result = doc.Descendants("result").Descendants("geometry").Descendants("location").FirstOrDefault();
            if (result == null)
            {
                return "<coordinate>\n" +
                          "<lat>unknown</lat>\n" +
                          "<lon>unknown</lon>\n" +
                       "</coordinate>";
            }
            XElement lat = result.Descendants("lat").FirstOrDefault();
            XElement lon = result.Descendants("lng").FirstOrDefault();
            return "<coordinate>\n" +
                      "<lat>" + (lat != null ? lat.Value : "unknown") + "</lat>\n" +
                      "<lon>" + (lon != null ? lon.Value : "unknown") + "</lon>\n" +
                   "</coordinate>";
        }

    }
}
