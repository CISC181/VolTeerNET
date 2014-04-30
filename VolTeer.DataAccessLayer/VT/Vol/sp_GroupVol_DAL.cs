using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_GroupVol_DAL
    {
        //TODO: Create an insert method passing in domain model
        # region Inserts

        public sp_Vol_GroupVol_DM InsertGroupContext(ref sp_Vol_GroupVol_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cGroup = new tblGroupVol
                {
                    GroupID = _cGroup.GroupID,
                    VolID = _cGroup.VolID,
                    PrimaryVolID = _cGroup.PrimaryVolID,
                    Admin = _cGroup.Admin

                };
                context.tblGroupVols.Add(cGroup);
                context.SaveChanges();

                // pass VolID back to BLL
                _cGroup.GroupID = cGroup.GroupID;

                return _cGroup;
            }
        }
        #endregion

        //TODO: Create a deleteall method passing in VolID
        #region Deletes
        public void DeleteGroupContext(sp_Vol_GroupVol_DM _cVolID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var GroupToRemove = (from n in context.tblGroupVols where n.VolID == _cVolID.VolID select n).FirstOrDefault();
                    context.tblGroupVols.Remove(GroupToRemove);
                    context.SaveChanges();

                 }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }
        #endregion
       
       

        //TODO: Create a MakePrimary method passing in VolID
        #region MakePrimary
        public void MakePrimaryVolID(sp_Vol_GroupVol_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cGroup = context.tblGroupVols.Find(_cGroup.GroupID);
                var cVol = context.tblGroupVols.Find(_cGroup.VolID);

                if (cGroup.GroupID == _cGroup.GroupID && cGroup.VolID == _cGroup.VolID)
                {
                    cGroup.GroupID = _cGroup.GroupID;
                    cGroup.VolID = _cGroup.VolID;
                    cGroup.PrimaryVolID = false;
                    context.SaveChanges();
                }

                else if (cGroup.GroupID == _cGroup.GroupID && cGroup.VolID != _cGroup.VolID)
                {
                    cGroup.GroupID = _cGroup.GroupID;
                    cGroup.VolID = _cGroup.VolID;
                    cGroup.PrimaryVolID = true;
                    context.SaveChanges();
                }
            }
        }
        #endregion
        //TODO: Create a Make Admin method passing in VolID

        #region MakeAdmin
        public void MakeAdminVolID(sp_Vol_GroupVol_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cGroup = context.tblGroupVols.Find(_cGroup.GroupID);
                var cVol = context.tblGroupVols.Find(_cGroup.VolID);

                if (cGroup.GroupID == _cGroup.GroupID && cGroup.VolID == _cGroup.VolID)
                {
                    cGroup.GroupID = _cGroup.GroupID;
                    cGroup.VolID = _cGroup.VolID;
                    cGroup.Admin = false;
                    context.SaveChanges();
                }
                else if (cGroup.GroupID == _cGroup.GroupID && cGroup.VolID != _cGroup.VolID)
                {
                    cGroup.GroupID = _cGroup.GroupID;
                    cGroup.VolID = _cGroup.VolID;
                    cGroup.Admin = true;
                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
