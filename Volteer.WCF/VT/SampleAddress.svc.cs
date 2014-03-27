using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using VolTeer.DomainModels.VT.Other;
using VolTeer.BusinessLogicLayer.VT.Other;



namespace Volteer.WCF.VT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SampleAddress" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SampleAddress.svc or SampleAddress.svc.cs at the Solution Explorer and start debugging.
    public class SampleAddress : ISampleAddress
    {
        sp_Sample_Address_BLL BLL = new sp_Sample_Address_BLL();

        public string ListSampleAddress()
        {
            List<sp_Sample_Address_Select_DM> AddressList = new List<sp_Sample_Address_Select_DM>();
            var ser = new XmlSerializer(typeof(List<sp_Sample_Address_Select_DM>));

            AddressList = BLL.ListSampleAddress();
            StringWriter sw = new StringWriter();
            ser.Serialize(sw, AddressList);
            return sw.ToString();
        }
    }
}
