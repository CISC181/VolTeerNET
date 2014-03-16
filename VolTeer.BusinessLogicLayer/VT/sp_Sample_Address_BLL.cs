using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
using VolTeer.DataAccessLayer.VT;

namespace VolTeer.BusinessLogicLayer.VT
{
    public class sp_Sample_Address_BLL
    {

        private sp_Sample_Address_DAL DAL = new sp_Sample_Address_DAL();

        public List<sp_Sample_Address_Select_DM> ListSampleAddress()
        {
            try
            {
                return DAL.ListSampleAddress();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSampleAddress(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.UpdateSampleAddress(addrID, addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }

        public void InsertSampleAddress(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.InsertSampleAddress(addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }

        public void DeleteSampleAddress(int addrID)
        {
            DAL.DeleteSampleAddress(addrID);
        }
    }
}
