using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Vol_Address_DAL
    {

        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Vol_Address_DM> ListAddresses()
        {
            List<sp_Vol_Address_DM> list = new List<sp_Vol_Address_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Address_Select(null)
                            select new sp_Vol_Address_DM
                            {
                                AddrID = result.AddrID,
                                ActiveFlg = result.ActiveFlg,
                                AddrLine1 = result.AddrLine1,
                                AddrLine2 = result.AddrLine2,
                                AddrLine3 = result.AddrLine3,
                                City = result.City,
                                St = result.St,
                                Zip = result.Zip,
                                Zip4 = result.Zip4,
                                GeogCol2 = result.GeogCol2

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public List<sp_Vol_Address_DM> ListAddresses(int? Address)
        {
            List<sp_Vol_Address_DM> list = new List<sp_Vol_Address_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Address_Select(Address)
                            select new sp_Vol_Address_DM
                            {
                                AddrID = result.AddrID,
                                ActiveFlg = result.ActiveFlg,
                                AddrLine1 = result.AddrLine1,
                                AddrLine2 = result.AddrLine2,
                                AddrLine3 = result.AddrLine3,
                                City = result.City,
                                St = result.St,
                                Zip = result.Zip,
                                Zip4 = result.Zip4,
                                GeogCol2 = result.GeogCol2
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

        #region Insert Statements


        /// <summary>
        /// InsertAddressContext - Will insert a record into Address table via SProc
        /// </summary>
        /// <param name="_cAddress"></param>
        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cAddress = new tblVolAddress
                {
                    AddrID = _cAddress.AddrID,
                    AddrLine1 = _cAddress.AddrLine1,
                    AddrLine2 = _cAddress.AddrLine2,
                    AddrLine3 = _cAddress.AddrLine3,
                    City = _cAddress.City,
                    St = _cAddress.St,
                    Zip = _cAddress.Zip,
                    Zip4 = _cAddress.Zip4,
                    GeogCol2 = _cAddress.GeogCol2,
                    ActiveFlg = _cAddress.ActiveFlg

                };
                context.tblVolAddresses.Add(cAddress);
                context.SaveChanges();

                //If the AddrID isn't null, set it equal to the return value
                if (_cAddress.AddrID != null)
                {
                    _cAddress.AddrID = cAddress.AddrID;
                }
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateAddressContext - Will update a given Address record by AddrID
        /// </summary>
        /// <param name="_cAddress"></param>
        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cAddress = context.tblVolAddresses.Find(_cAddress.AddrID);

                if (cAddress != null)
                {
                    cAddress.AddrLine1 = _cAddress.AddrLine1;
                    cAddress.AddrLine2 = _cAddress.AddrLine2;
                    cAddress.AddrLine3 = _cAddress.AddrLine3;
                    cAddress.City = _cAddress.City;
                    cAddress.St = _cAddress.St;
                    cAddress.Zip = _cAddress.Zip;
                    cAddress.Zip4 = _cAddress.Zip4;
                    cAddress.ActiveFlg = _cAddress.ActiveFlg;
                    cAddress.GeogCol2 = _cAddress.GeogCol2;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements

        /// <summary>
        /// DeleteAddressContext - Will do a soft delete (make inactive) by AddrID
        /// </summary>
        /// <param name="_cAddress"></param>
        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var AddressToRemove = (from n in context.tblVolAddresses where n.AddrID == _cAddress.AddrID select n).FirstOrDefault();
                context.tblVolAddresses.Remove(AddressToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
