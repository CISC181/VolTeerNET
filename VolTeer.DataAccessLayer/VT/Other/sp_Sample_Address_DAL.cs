using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Other;


namespace VolTeer.DataAccessLayer.VT.Other
{
    public class sp_Sample_Address_DAL
    {

        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Sample_Address_Select_DM> ListSampleAddress()
        {
            List<sp_Sample_Address_Select_DM> list = new List<sp_Sample_Address_Select_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Sample_Address_Select()
                            select new sp_Sample_Address_Select_DM
                            {
                                AddrID = result.AddrID,
                                ActiveFlg = result.ActiveFlg,
                                AddrLine1 = result.AddrLine1,
                                AddrLine2 = result.AddrLine2,
                                AddrLine3 = result.AddrLine3,
                                City = result.City,
                                St = result.St,
                                Zip = result.Zip,
                                Zip4 = result.Zip4

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }
        #endregion
        #region Update Statements
        /// <summary>
        /// UpdateSampleAddress...  Pass in each variable, hook each variable to the stored procedure, call the stored procedure directly
        /// </summary>
        /// <param name="addrID"></param>
        /// <param name="addrLine1"></param>
        /// <param name="addrLine2"></param>
        /// <param name="addrLine3"></param>
        /// <param name="city"></param>
        /// <param name="st"></param>
        /// <param name="zip"></param>
        /// <param name="zip4"></param>
        /// <param name="activeFlg"></param>
        public void UpdateSampleAddress(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Update(addrID, addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);
            }
        }

        /// <summary>
        /// UpdateSampleAddressContext...  Pass in each variable, hook each variable to the context, have the context execute the stored procedure
        /// </summary>
        /// <param name="addrID"></param>
        /// <param name="addrLine1"></param>
        /// <param name="addrLine2"></param>
        /// <param name="addrLine3"></param>
        /// <param name="city"></param>
        /// <param name="st"></param>
        /// <param name="zip"></param>
        /// <param name="zip4"></param>
        /// <param name="activeFlg"></param>
        public void UpdateSampleAddressContext(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var SampleAddress = context.tblSampleAddresses.Find(addrID);

                if (SampleAddress != null)
                {
                    SampleAddress.AddrLine1 = addrLine1;
                    SampleAddress.AddrLine2 = addrLine2;
                    SampleAddress.AddrLine3 = addrLine3;
                    SampleAddress.City = city;
                    SampleAddress.St = st;
                    SampleAddress.Zip = zip;
                    SampleAddress.Zip4 = zip4;
                    SampleAddress.ActiveFlg = activeFlg;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// UpdateSampleAddressContext...  pass in an object of SampleAddress...  assign the object variables to the context variables, call the update
        /// </summary>
        /// <param name="lSampleAddress"></param>
        public void UpdateSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                //  Load the Address based on the AddrID
                var SampleAddress = context.tblSampleAddresses.Find(lSampleAddress.AddrID);

                if (SampleAddress != null)
                {
                    SampleAddress.AddrLine1 = lSampleAddress.AddrLine1;
                    SampleAddress.AddrLine2 = lSampleAddress.AddrLine2;
                    SampleAddress.AddrLine3 = lSampleAddress.AddrLine3;
                    SampleAddress.City = lSampleAddress.City;
                    SampleAddress.St = lSampleAddress.St;
                    SampleAddress.Zip = lSampleAddress.Zip;
                    SampleAddress.Zip4 = lSampleAddress.Zip4;
                    SampleAddress.ActiveFlg = lSampleAddress.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion
        #region Insert Statements

        public void InsertSampleAddress(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Insert(addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);

            }
        }

        public void InsertSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {

            using (VolTeerEntities context = new VolTeerEntities())
            {
                var SampleAddress = new tblSampleAddress
                {
                    AddrLine1 = lSampleAddress.AddrLine1,
                    AddrLine2 = lSampleAddress.AddrLine2,
                    AddrLine3 = lSampleAddress.AddrLine3, 
                    City = lSampleAddress.City, 
                    St = lSampleAddress.St,
                    Zip = lSampleAddress.Zip, 
                    Zip4 = lSampleAddress.Zip4,
                    ActiveFlg = lSampleAddress.ActiveFlg 
                };
                context.tblSampleAddresses.Add(SampleAddress);
                context.SaveChanges();
            }
        }


        public void InsertSampleAddressContext(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)
        {

            using (VolTeerEntities context = new VolTeerEntities())
            {
                var SampleAddress = new tblSampleAddress
                {
                    AddrLine1 = addrLine1,
                    AddrLine2 = addrLine2,
                    AddrLine3 = addrLine3,
                    City = city,
                    St = st,
                    Zip = zip,
                    Zip4 = zip4,
                    ActiveFlg = activeFlg
                };
                context.tblSampleAddresses.Add(SampleAddress);
                context.SaveChanges();
            }
        }
        #endregion
        #region Insert Statements
        public void DeleteSampleAddress(int addrID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Delete(addrID);
            }
        }

        public void DeleteSampleAddressContext(sp_Sample_Address_Select_DM lSampleAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                //  Load the Address based on the AddrID

                var AddressToRemove = (from n in context.tblSampleAddresses where n.AddrID == lSampleAddress.AddrID select n).FirstOrDefault();
                context.tblSampleAddresses.Remove(AddressToRemove);
                context.SaveChanges();
 
            }
        }
        #endregion

    }
}
