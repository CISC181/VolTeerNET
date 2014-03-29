using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using VolTeer.DomainModels;
using VolTeer.DomainModels.Service;

namespace VolTeer.ExternalServiceLayer
{
    public class GoogleGeocoder : IGeocoder
    {
        const string API_REVERSE_GEOCODE = "maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
        const string API_GEOCODE = "maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false";
        const string API_DIRECTIONS = "maps.googleapis.com/maps/api/directions/xml?origin={0}&destination={1}&mode={2}&sensor=false";

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

        protected string ApiReverseGeoCode
        {
            get { return Protocol + API_REVERSE_GEOCODE; }
        }

        protected string ApiGeoCode
        {
            get { return Protocol + API_GEOCODE; }
        }

        protected string ApiDirections
        {
            get { return Protocol + API_DIRECTIONS; }
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
            XDocument doc = XDocument.Load(String.Format(ApiGeoCode, address.getFormattedAddress()));
           
            var result = doc.Descendants("result").Descendants("geometry").Descendants("location").First();
            return result != null
                       ? "<coordinate>\n" +
                            "<lat>" + (result.Descendants("lat").First().Value) + "</lat>\n" +
                            "<lon>" + (result.Descendants("lng").First().Value) + "</lon>\n" +
                         "</coordinate>"
                       : "<coordinate>\n" +
                            "<lat>unknown</lat>\n" +
                            "<lon>unknown</lon>\n" +
                         "</coordinate>";
        }
    }
}
