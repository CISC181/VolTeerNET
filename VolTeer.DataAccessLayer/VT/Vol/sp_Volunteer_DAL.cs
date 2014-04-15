using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Volunteer_DAL : sp_Volunteer_CON
    {

        #region Select Statements
        /// <summary>
        /// Return a list of Sample addresses using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Volunteer_DM> ListVolunteers()
        {
            List<sp_Volunteer_DM> list = new List<sp_Volunteer_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Volunteer_Select(null)
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

        public sp_Volunteer_DM ListVolunteers(Guid? Volunteer)
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

            return list.FirstOrDefault();

        }

        #endregion


        #region Insert Statements


        /// <summary>
        /// InsertVolunteerContext - Will insert a record into Volunteer table via SProc
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public sp_Volunteer_DM  InsertVolunteerContext(ref sp_Volunteer_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolunteer = new tblVolunteer
                {
                    VolID = _cVolunteer.VolID,
                    VolFirstName = _cVolunteer.VolFirstName,
                    VolMiddleName = _cVolunteer.VolMiddleName,
                    VolLastName = _cVolunteer.VolLastName,
                    ActiveFlg = _cVolunteer.ActiveFlg

                };
                context.tblVolunteers.Add(cVolunteer);
                context.SaveChanges();

                // pass VolID back to BLL
                _cVolunteer.VolID = cVolunteer.VolID;

                return _cVolunteer;
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateSampleAddressContext - Will update a given Volunteer record by VolID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdateVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cVolunteer = context.tblVolunteers.Find(_cVolunteer.VolID);

                if (cVolunteer != null)
                {
                    cVolunteer.VolFirstName = _cVolunteer.VolFirstName;
                    cVolunteer.VolMiddleName = _cVolunteer.VolMiddleName;
                    cVolunteer.VolLastName = _cVolunteer.VolLastName;
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
        public void DeleteVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var VolunteerToRemove = (from n in context.tblVolunteers where n.VolID == _cVolunteer.VolID select n).FirstOrDefault();
                context.tblVolunteers.Remove(VolunteerToRemove);
                context.SaveChanges();

            }
        }
        #endregion

    }
}
