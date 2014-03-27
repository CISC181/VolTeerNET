using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;


namespace VolTeer.DataAccessLayer.VT.Vol
{
    class sp_Email_DAL
    {
        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Email_DM> ListVolunteers()
        {
            List<sp_Email_DM> list = new List<sp_Email_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Vol_Email_Select(null)
                            select new sp_Email_DM
                            {
                                EmailID = result.EmailID,
                                VolID = result.VolID,
                                EmailAddr = result.EmailAddr,
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

        public List<sp_Volunteer_DM> ListVolunteers(Guid? Volunteer)
        {
            List<sp_Volunteer_DM> list = new List<sp_Volunteer_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Volunteer_Select(Volunteer)
                            select new sp_Volunteer_DM
                            {
                                VolFirstName = result.VolFirstName,
                                VolID = result.VolID,
                                VolMiddleName = result.VolMiddleName,
                                VolLastName = result.VolLastName,
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
        /// InsertVolunteerContext - Will insert a record into Volunteer table via SProc
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void InsertVolunteerContext(sp_Email_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolunteer = new tblVolEmail
                {
                    VolID = _cVolunteer.VolID,
                    EmailID = _cVolunteer.EmailID,
                    EmailAddr = _cVolunteer.EmailAddr,
                    ActiveFlg = _cVolunteer.ActiveFlg

                };
                context.tblVolEmails.Add(cVolunteer);
                context.SaveChanges();
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateSampleAddressContext - Will update a given Volunteer record by VolID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdateSampleAddressContext(sp_Email_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolunteer = context.tblVolEmails.Find(_cVolunteer.VolID);

                if (cVolunteer != null)
                {
                    cVolunteer.EmailID = _cVolunteer.EmailID;
                    cVolunteer.EmailAddr = _cVolunteer.EmailAddr;
                    cVolunteer.ActiveFlg = _cVolunteer.ActiveFlg;
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
        public void DeleteVolunteerContext(sp_Email_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VolunteerToRemove = (from n in context.tblVolEmails where n.VolID == _cVolunteer.VolID select n).FirstOrDefault();
                context.tblVolEmails.Remove(VolunteerToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
