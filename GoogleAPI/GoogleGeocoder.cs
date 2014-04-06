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
            get { return Protocol + ConfigurationManager.AppSettings["API_GEOCODE"]; }
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
        public GoogleGeocoder() : this(false) { }

        public string GetLatLongFromAddress(GoogleAddress address)
        {
            // @TODO: get our own Google API key?
            XDocument doc = XDocument.Load(String.Format(ApiGeoCode, address.FormattedAddress));

            var result = doc.Descendants("result").Descendants("geometry").Descendants("location").FirstOrDefault();
            string lat = result.Descendants("lat").FirstOrDefault().Value;
            string lon = result.Descendants("lng").FirstOrDefault().Value;
            return result != null
                       ? "<coordinate>\n" +
                            "<lat>" + (lat != null ? lat : "unknown") + "</lat>\n" +
                            "<lon>" + (lon != null ? lon : "unknown") + "</lon>\n" +
                         "</coordinate>"
                       : "<coordinate>\n" +
                            "<lat>unknown</lat>\n" +
                            "<lon>unknown</lon>\n" +
                         "</coordinate>";
        }

    }
}
