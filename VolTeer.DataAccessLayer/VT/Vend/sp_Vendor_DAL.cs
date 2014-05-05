using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_Vendor_DAL : sp_Vendor_CON
    {

        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Vendor_DM> ListVendors()
        {
            List<sp_Vendor_DM> list = new List<sp_Vendor_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vendor_Select(null)
                            select new sp_Vendor_DM
                            {
                                ActiveFlg = result.ActiveFlg,
                                VendorID = result.VendorID,
                                VendorName = result.VendorName


                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public sp_Vendor_DM ListVendors(Guid? VendorID)
        {
            List<sp_Vendor_DM> list = new List<sp_Vendor_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vendor_Select(VendorID)
                            select new sp_Vendor_DM
                            {
                                ActiveFlg = result.ActiveFlg,
                                VendorID = result.VendorID,
                                VendorName = result.VendorName
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list.FirstOrDefault();

        }

        #endregion


        #region Insert Statements


        /// <summary>
        /// InsertVolunteerContext - Will insert a record into Volunteer table via SProc
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public sp_Vendor_DM InsertVendorContext(ref sp_Vendor_DM _cVendor)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVendor = new tblVendor
                {
                    ActiveFlg = _cVendor.ActiveFlg,
                    VendorID = _cVendor.VendorID,
                    VendorName = _cVendor.VendorName
                    

                };
                context.tblVendors.Add(cVendor);
                context.SaveChanges();


                return _cVendor;
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateSampleAddressContext - Will update a given Volunteer record by VolID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdateVolunteerContext(sp_Vendor_DM _cVendor)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVendor = context.tblVendors.Find(_cVendor.VendorID);

                if (cVendor != null)
                {
                    cVendor.VendorName = _cVendor.VendorName;
                    cVendor.VendorID = _cVendor.VendorID;
                    cVendor.ActiveFlg = _cVendor.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements

        /// <summary>
        /// DeleteVolunteerContext - Will do a soft delete (make inactive) by VolID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void DeleteVendorContext(sp_Vendor_DM _cVendor)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VendorToRemove = (from n in context.tblVendors where n.VendorID == _cVendor.VendorID select n).FirstOrDefault();
                context.tblVendors.Remove(VendorToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
