using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Vol_Address_DAL : sp_Vol_Address_CON
    {

        #region Select Statements
        /// <summary>
        /// Returns a list of all addresses
        /// </summary>
        /// <returns></returns>
        public List<sp_Vol_Address_DM> ListAddresses(sp_Vol_Address_DM cVolAddr)
        {
            List<sp_Vol_Address_DM> list = new List<sp_Vol_Address_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Address_Select(cVolAddr.VolID, cVolAddr.AddrID, null)
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
                                GeoCodeGetSet = result.GeoCodeGetSet,
                                PrimaryAddr = result.PrimaryAddr

                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public sp_Vol_Address_DM ListAddress(sp_Vol_Address_DM cVolAddr)
        {
            return ListAddresses(cVolAddr).Single();
        }

        public List<sp_Vol_Address_DM> ListAddresses(Guid? VolID, int? Address)
        {
            List<sp_Vol_Address_DM> list = new List<sp_Vol_Address_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Address_Select(VolID, Address, null)
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
                                GeoCodeGetSet = result.GeoCodeGetSet,
                                PrimaryAddr = result.PrimaryAddr
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public sp_Vol_Address_DM ListPrimaryAddress(sp_Vol_Address_DM cVolAddr)
        {
            sp_Vol_Address_DM item = new sp_Vol_Address_DM();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    item = (from result in context.sp_Vol_Address_Select(cVolAddr.VolID, null, true)
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
                                GeoCodeGetSet = result.GeoCodeGetSet,
                                PrimaryAddr = result.PrimaryAddr
                            }).FirstOrDefault();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return item;

        }

        #endregion

        #region Insert Statements


        /// <summary>
        /// InsertAddressContext - Will insert a record into Address table via SProc
        /// </summary>
        /// <param name="_cAddress"></param>
        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_Vol_Addr_DM _cVolAddr)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var cAddress = new tblVolAddress
                    {
                        AddrLine1 = _cAddress.AddrLine1,
                        AddrLine2 = _cAddress.AddrLine2,
                        AddrLine3 = _cAddress.AddrLine3,
                        City = _cAddress.City,
                        St = _cAddress.St,
                        Zip = _cAddress.Zip,
                        Zip4 = _cAddress.Zip4,
                        GeoCodeGetSet = _cAddress.GeoCodeGetSet,
                        ActiveFlg = _cAddress.ActiveFlg
                    };
                    context.tblVolAddresses.Add(cAddress);
                    context.SaveChanges();

                    var cVolAddr = new tblVolAddr
                    {
                        VolID = _cVolAddr.VolID,
                        AddrID = cAddress.AddrID,
                        PrimaryAddr = _cVolAddr.PrimaryAddr
                    };

                    context.tblVolAddrs.Add(cVolAddr);
                    context.SaveChanges();

                    //If the AddrID isn't null, set it equal to the return value
                    if (_cAddress.AddrID != null)
                    {
                        _cAddress.AddrID = cAddress.AddrID;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateAddressContext - Will update a given Address record by AddrID
        /// </summary>
        /// <param name="_cAddress"></param>
        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    var cAddress = context.tblVolAddresses.Find(_cAddress.AddrID);
                    var cVolAddr = context.tblVolAddrs.Find(_cVolAddr.VolID,_cVolAddr.AddrID);

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
                        cAddress.GeoCodeGetSet = _cAddress.GeoCodeGetSet;
                    }

                    if (cVolAddr != null)
                    {
                        cVolAddr.VolID = _cVolAddr.VolID;
                        cVolAddr.AddrID = _cVolAddr.AddrID;
                        cVolAddr.PrimaryAddr = _cVolAddr.PrimaryAddr;
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }



        }
        #endregion

        #region Delete Statements

        /// <summary>
        /// DeleteAddressContext - Will do a soft delete (make inactive) by AddrID
        /// </summary>
        /// <param name="_cAddress"></param>
        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var AddrToRemove = (from n in context.tblVolAddrs where n.AddrID == _cVolAddr.AddrID select n).FirstOrDefault();
                    context.tblVolAddrs.Remove(AddrToRemove);
                    context.SaveChanges();

                    var AddressToRemove = (from n in context.tblVolAddresses where n.AddrID == _cAddress.AddrID select n).FirstOrDefault();
                    //context.tblVolAddresses.Remove(AddressToRemove);
                    AddressToRemove.ActiveFlg = false;
                    context.sp_Vol_Address_Update(AddressToRemove.AddrID, AddressToRemove.ActiveFlg, AddressToRemove.AddrLine1, 
                        AddressToRemove.AddrLine2, AddressToRemove.AddrLine3, AddressToRemove.City, AddressToRemove.St, AddressToRemove.Zip, 
                        AddressToRemove.Zip4, AddressToRemove.GeoCodeGetSet);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }
        #endregion
    }
}
