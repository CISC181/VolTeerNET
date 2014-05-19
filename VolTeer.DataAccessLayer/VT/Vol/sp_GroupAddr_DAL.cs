using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_GroupAddr_DAL : sp_GroupAddr_CON
    {

        public List<sp_GroupAddr_DM> ListAddresses(sp_GroupAddr_DM cGroupAddr)
        {
            List<sp_GroupAddr_DM> list = new List<sp_GroupAddr_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_GroupAddr_Select(cGroupAddr.GroupID, cGroupAddr.AddrID)
                            select new sp_GroupAddr_DM
                            {
                                GroupID = result.GroupID,
                                AddrID = result.AddrID,
                                PrimaryAddrID = result.PrimaryAddrID,
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

        public List<sp_GroupAddr_DM> ListGroups()
        {
            List<sp_GroupAddr_DM> list = new List<sp_GroupAddr_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_GroupAddr_Select(null,null)
                            select new sp_GroupAddr_DM
                            {
                                GroupID = result.GroupID,
                                AddrID = result.AddrID,
                                PrimaryAddrID = result.PrimaryAddrID,
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

        public sp_GroupAddr_DM ListAddress(sp_GroupAddr_DM cGroupAddr)
        {
            return ListAddresses(cGroupAddr).Single();
        }

        public List<sp_GroupAddr_DM> ListAddresses(int? GroupID, int? Address)
        {
            List<sp_GroupAddr_DM> list = new List<sp_GroupAddr_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_GroupAddr_Select(GroupID, Address)
                            select new sp_GroupAddr_DM
                            {
                                GroupID = result.GroupID,
                                AddrID = result.AddrID,
                                PrimaryAddrID = result.PrimaryAddrID,
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


        public sp_GroupAddr_DM ListPrimaryAddress(sp_GroupAddr_DM cGroupAddr)
        {
            sp_GroupAddr_DM item = new sp_GroupAddr_DM();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    item = (from result in context.sp_GroupAddr_Select(cGroupAddr.GroupID, cGroupAddr.AddrID)
                            select new sp_GroupAddr_DM
                            {
                                GroupID = result.GroupID,
                                AddrID = result.AddrID,
                                PrimaryAddrID = result.PrimaryAddrID,
                                ActiveFlg = result.ActiveFlg
                            }).FirstOrDefault();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return item;

        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var AddrToRemove = (from n in context.tblGroupAddrs where n.AddrID == _cGroupAddr.AddrID select n).FirstOrDefault();
                    context.tblGroupAddrs.Remove(AddrToRemove);
                    context.SaveChanges();

                    var AddressToRemove = (from n in context.tblVolAddresses where n.AddrID == _cAddress.AddrID select n).FirstOrDefault();
                    context.tblVolAddresses.Remove(AddressToRemove);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }

        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_GroupAddr_DM _cGroupAddr)
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

                    var cGroupAddr = new tblGroupAddr
                    {
                        GroupID = _cGroupAddr.GroupID,
                        AddrID = cAddress.AddrID,
                        PrimaryAddrID = _cGroupAddr.PrimaryAddrID
                    };

                    context.tblGroupAddrs.Add(cGroupAddr);
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

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    var cAddress = context.tblVolAddresses.Find(_cAddress.AddrID);
                    var cGroupAddr = context.tblGroupAddrs.Find(_cGroupAddr.GroupID, _cGroupAddr.AddrID);

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

                    if (cGroupAddr != null)
                    {
                        cGroupAddr.GroupID = _cGroupAddr.GroupID;
                        cGroupAddr.AddrID = _cGroupAddr.AddrID;
                        cGroupAddr.PrimaryAddrID = _cGroupAddr.PrimaryAddrID;
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
