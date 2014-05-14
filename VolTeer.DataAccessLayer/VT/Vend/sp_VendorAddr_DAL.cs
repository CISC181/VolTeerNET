using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_VendorAddr_DAL : sp_VendorAddr_CON
    {

        #region Select Statements
        public List<sp_VendorAddr_DM> ListAddresses(Guid? VendorID)
        {
            List<sp_VendorAddr_DM> list = new List<sp_VendorAddr_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_VendorAddr_Select(VendorID)
                            select new sp_VendorAddr_DM
                            {
                                AddrID = result.AddrID,
                                VendorID = result.VendorID,
                                HQ = result.HQ
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        public List<sp_VendorAddr_DM> ListAddresses()
        {
            return ListAddresses(null);
        }
        #endregion

        #region Insert Statements
        public int InsertAddressContext(sp_VendorAddr_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewAddress = new tblVendorAddr
                {
                    AddrID = InputAddress.AddrID,
                    HQ = InputAddress.HQ
                };
                context.tblVendorAddrs.Add(NewAddress);
                context.SaveChanges();
                //Return the id of the newly created record
                return NewAddress.AddrID;
            }
        }
        #endregion

        #region Update Statements
        public void UpdateAddressContext(sp_VendorAddr_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var existingAddress = context.tblVendorAddrs.Find(InputAddress.AddrID);

                if (InputAddress != null)
                {
                    existingAddress.VendorID = InputAddress.VendorID;
                    existingAddress.AddrID = InputAddress.AddrID;
                    existingAddress.HQ = InputAddress.HQ;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteAddressContext(sp_VendorAddr_DM InputAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendorAddrsToRemove = (from n in context.tblVendorAddrs where n.VendorID == InputAddress.VendorID select n).FirstOrDefault();
                context.tblVendorAddrs.Remove(VendorAddrsToRemove);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
