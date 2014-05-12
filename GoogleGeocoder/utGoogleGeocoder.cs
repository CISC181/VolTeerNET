using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels;
using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;

namespace UT.GoogleAPI
{
    [TestClass]
    public class utGoogleGeocoder
    {
        private GoogleGeocoder ggDefault = new GoogleGeocoder();
        private GoogleGeocoder ggFalse = new GoogleGeocoder(false);
        private GoogleGeocoder ggTrue = new GoogleGeocoder(true);

        private GoogleAddress gaNullFormat = new GoogleAddress();
        private GoogleAddress gaGoodFormat = new GoogleAddress();
        private GoogleAddress gaBadFormat = new GoogleAddress();
       
        [TestMethod]
        public void DefaultConstructorTest()
        {
            // ensure that the default constructor sets IsSSL to False
            Assert.IsFalse(ggDefault.IsSSL);
        }

        [TestMethod]
        public void OverrideConstructorTest()
        {
            // ensure that the constructor sets IsSSL to true/false according to the input parameter
            Assert.IsFalse(ggFalse.IsSSL);
            Assert.IsTrue(ggTrue.IsSSL);
        }
        
        [TestMethod]
        public void GetLatLongFromAddressTest()
        {
            gaNullFormat.FormattedAddress = null;
            gaGoodFormat.FormattedAddress = "1600 Amphitheatre Parkway, Mountain View, CA";
            gaBadFormat.FormattedAddress = "this is a bogus address";
         
            // null-formatted input (GoogleAddress.FormattedAddress) should return valid XML with unknown lat/lon
            Assert.AreEqual("<coordinate>\n" +
                                "<lat>unknown</lat>\n" +
                                "<lon>unknown</lon>\n" +
                            "</coordinate>",
                            ggTrue.GetLatLongFromAddress(gaNullFormat));
            
            // correctly-formatted input (GoogleAddress.FormattedAddress) should return valid XML with correct lat/lon
            Assert.AreEqual("<coordinate>\n" +
                                "<lat>37.4219998</lat>\n" +
                                "<lon>-122.0839596</lon>\n" +
                            "</coordinate>",
                            ggTrue.GetLatLongFromAddress(gaGoodFormat));
            
            // incorrectly-formatted input (GoogleAddress.FormattedAddress) should return valid XML with unknown lat/lon
            Assert.AreEqual("<coordinate>\n" +
                                "<lat>unknown</lat>\n" +
                                "<lon>unknown</lon>\n" +
                            "</coordinate>",
                            ggTrue.GetLatLongFromAddress(gaBadFormat));
          }
    }
}
