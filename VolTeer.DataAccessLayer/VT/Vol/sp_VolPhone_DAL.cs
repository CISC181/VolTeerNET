using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_VolPhone_DAL
    {
        #region Select Statements
        /// <summary>
        /// Returns all or a phone number for the given volunteer
        /// </summary>
        /// <returns></returns>
        public List<sp_Phone_DM> ListPhones(sp_Phone_DM cVolPhone)
        {
            List<sp_Phone_DM> list = new List<sp_Phone_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Phone_Select(cVolPhone.VolID, cVolPhone.PhoneID, null)
                            select new sp_Phone_DM
                            {
                                PhoneID = result.PhoneID,
                                PhoneNbr = result.PhoneNbr,
                                VolID = result.VolID,
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

        public List<sp_Phone_DM> ListPrimaryPhone(sp_Phone_DM cVolPhone)
        {
            List<sp_Phone_DM> list = new List<sp_Phone_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Phone_Select(cVolPhone.VolID, cVolPhone.PhoneID,true)
                            select new sp_Phone_DM
                            {
                                PhoneID = result.PhoneID,
                                PhoneNbr = result.PhoneNbr,
                                VolID = result.VolID,
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

        #endregion


        #region Insert Statements


        /// <summary>
        /// InsertPhoneContext - Will insert a record into Volunteer Phone table via SProc
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void InsertPhoneContext(sp_Phone_DM _cPhone)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cPhone = new tblVolPhone
                {
                    VolID = _cPhone.VolID,
                    PhoneID = _cPhone.PhoneID,
                    PhoneNbr = _cPhone.PhoneNbr,
                    ActiveFlg = _cPhone.ActiveFlg
                    
                };
                context.tblVolPhones.Add(cPhone);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdatePhoneAddr - Will update a given PhoneNbr record by PhoneID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdatePhoneNbr(sp_Phone_DM _cPhone)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cPhone = context.tblVolPhones.Find(_cPhone.PhoneID);

                if (cPhone != null)
                {
                    cPhone.PhoneNbr = _cPhone.PhoneNbr;
                    cPhone.VolID = _cPhone.VolID;
                    cPhone.ActiveFlg = _cPhone.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements

        /// <summary>
        /// DeletePhonesContext - Will do a soft delete (make inactive) by PhoneID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void DeletePhonesContext(sp_Phone_DM _cPhone)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var PhonesToRemove = (from n in context.tblVolPhones where n.PhoneID == _cPhone.PhoneID select n).FirstOrDefault();
                context.tblVolPhones.Remove(PhonesToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
