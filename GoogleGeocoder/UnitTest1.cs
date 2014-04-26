using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolTeer.DomainModels;
using VolTeer.DomainModels.Service;

namespace VolTeer.GoogleAPI
{
    [TestClass]
    public class UnitTest1
    {
        private GoogleGeocoder ggDefault = new GoogleAPI.GoogleGeocoder();
        private GoogleGeocoder ggFalse = new GoogleAPI.GoogleGeocoder(false);
        private GoogleGeocoder ggTrue = new GoogleAPI.GoogleGeocoder(true);

        private GoogleAddress gaBadFormat = new GoogleAddress();
        private GoogleAddress gaGoodFormat = new GoogleAddress();
       
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
            // @TODO: register for Google API key and put in App.config

            gaBadFormat.FormattedAddress = "this is a bogus address";
            gaGoodFormat.FormattedAddress = "@TODO";
            
            // incorrectly-formatted input (GoogleAddress.FormattedAddress) should return valid XML with unknown lat/lon
            Assert.AreEqual(ggTrue.GetLatLongFromAddress(gaBadFormat), "<coordinate>\n" +
                                                                         "<lat>unknown</lat>\n" +
                                                                         "<lon>unknown</lon>\n" +
                                                                       "</coordinate>");
            // correctly-formatted input (GoogleAddress.FormattedAddress) should return valid XML with correct lat/lon
            Assert.AreEqual(ggTrue.GetLatLongFromAddress(gaGoodFormat), "<coordinate>\n" +
                                                                     "<lat>@TODO</lat>\n" +
                                                                     "<lon>@TODO</lon>\n" +
                                                                   "</coordinate>");
        
        }
    }
}
