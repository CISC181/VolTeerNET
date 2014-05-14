using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_Project_DAL : sp_Project_CON 
    {
        #region Select Statements
        /// <summary>
        /// Return a list of Sample projects using LINQ to SQL
        /// </summary>
        /// <returns></returns>
        public List<sp_Project_DM> ListProjects()
        {
            List<sp_Project_DM> list = new List<sp_Project_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Project_Select(null)
                            select new sp_Project_DM
                            {
                                ProjectID = result.ProjectID,
                                ProjectName = result.ProjectName,
                                ProjectDesc = result.ProjectDesc,
                                AddrID = result.AddrID,
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

        public sp_Project_DM ListProjects(Guid? ProjectID)
        {
            List<sp_Project_DM> list = new List<sp_Project_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Project_Select(ProjectID)
                            select new sp_Project_DM
                            {
                                ProjectID = result.ProjectID,
                                ProjectName = result.ProjectName,
                                ProjectDesc = result.ProjectDesc,
                                AddrID = result.AddrID,
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
        public sp_Project_DM InsertProjectContext(ref sp_Project_DM _cProject)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cProject = new tblProject
                {
                    
                    ProjectID = _cProject.ProjectID,
                    ProjectName = _cProject.ProjectName,
                    ProjectDesc = _cProject.ProjectDesc,
                    AddrID = _cProject.AddrID,
                    ActiveFlg = _cProject.ActiveFlg


                };
                context.tblProjects.Add(cProject);
                context.SaveChanges();


                return _cProject;
            }
        }
        #endregion

        #region Update Statements

        /// <summary>
        /// UpdateSampleAddressContext - Will update a given Volunteer record by VolID
        /// </summary>
        /// <param name="_cVolunteer"></param>
        public void UpdateProjectContext(sp_Project_DM _cProject)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cProject = context.tblProjects.Find(_cProject.ProjectID);

                if (cProject != null)
                {
                    cProject.ProjectDesc = _cProject.ProjectDesc;
                    cProject.ProjectName = _cProject.ProjectName;
                    cProject.ProjectID = _cProject.ProjectID;
                    cProject.ActiveFlg = _cProject.ActiveFlg;
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
        public void DeleteProjectContext(sp_Project_DM _cProject)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ProjectToRemove = (from n in context.tblProjects where n.ProjectID == _cProject.ProjectID select n).FirstOrDefault();
                context.tblProjects.Remove(ProjectToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
