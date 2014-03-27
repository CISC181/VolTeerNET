using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Other;
using VolTeer.DataAccessLayer.VT.Other;

namespace VolTeer.BusinessLogicLayer.VT.Other
{
    public class sp_Sample_Address_BLL
    {

        private sp_Sample_Address_DAL DAL = new sp_Sample_Address_DAL();

        #region Select Statements
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
        #endregion
        #region Update Statements

        public void UpdateSampleAddress(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.UpdateSampleAddress(addrID, addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }

        public void UpdateSampleAddressContext(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.UpdateSampleAddress(addrID, addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }

        public void UpdateSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {
            DAL.UpdateSampleAddressContext(lSampleAddress);
        }
        #endregion
        #region Insert Statements
        public void InsertSampleAddress(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.InsertSampleAddress(addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }

        public void InsertSampleAddressContext(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            DAL.InsertSampleAddressContext(addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
        }


        public void InsertSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {
            DAL.InsertSampleAddressContext(lSampleAddress);
        }
        #endregion
        #region Delete Statements
        public void DeleteSampleAddress(int addrID)
        {
            DAL.DeleteSampleAddress(addrID);
        }

        public void DeleteSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {
            DAL.DeleteSampleAddressContext(lSampleAddress);
        }
        #endregion

    }
}
