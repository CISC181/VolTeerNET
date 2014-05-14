using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendAddress_DAL : sp_VendAddress_CON
    {

        #region Select Statements
        public List<sp_VendAddress_DM> ListAddresses(int AddrID)
        {
            List<sp_VendAddress_DM> list = new List<sp_VendAddress_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vend_Address_Select(AddrID)
                            select new sp_VendAddress_DM
                            {
                                AddrID = result.AddrID,
                                AddrLine1 = result.AddrLine1,
                                AddrLine2 = result.AddrLine2,
                                AddrLine3 = result.AddrLine3,
                                City = result.City,
                                St = result.St,
                                Zip = result.Zip,
                                Zip4 = result.Zip4,
                                ActiveFlg = result.ActiveFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        public List<sp_VendAddress_DM> ListAddresses()
        {
            return ListAddresses();
        }
        #endregion

        #region Insert Statements
        public int InsertAddressContext(sp_VendAddress_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewAddress = new tblVendAddress
                {
                    AddrLine1 = InputAddress.AddrLine1,
                    AddrLine2 = InputAddress.AddrLine2,
                    AddrLine3 = InputAddress.AddrLine3,
                    City = InputAddress.City,
                    St = InputAddress.St,
                    Zip = InputAddress.Zip,
                    Zip4 = InputAddress.Zip4,
                    GeoCodeGetSet = InputAddress.GeoCodeGetSet,
                    ActiveFlg = InputAddress.ActiveFlg
                };
                context.tblVendAddresses.Add(NewAddress);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewAddress.AddrID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateAddressContext(sp_VendAddress_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingAddress = context.tblVendAddresses.Find(InputAddress.AddrID);

                if (InputAddress != null)
                {
                    existingAddress.AddrLine1 = InputAddress.AddrLine1;
                    existingAddress.AddrLine2 = InputAddress.AddrLine2;
                    existingAddress.AddrLine3 = InputAddress.AddrLine3;
                    existingAddress.City = InputAddress.City;
                    existingAddress.St = InputAddress.St;
                    existingAddress.Zip = InputAddress.Zip;
                    existingAddress.Zip4 = InputAddress.Zip4;
                    existingAddress.GeoCodeGetSet = InputAddress.GeoCodeGetSet;
                    existingAddress.ActiveFlg = InputAddress.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteAddressContext(sp_VendAddress_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendAddressToRemove = (from n in context.tblVendAddresses where n.AddrID == InputAddress.AddrID select n).FirstOrDefault();
                context.tblVendAddresses.Remove(VendAddressToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
