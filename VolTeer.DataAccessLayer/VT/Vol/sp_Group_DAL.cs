using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Group_DAL : sp_Group_Con
    {
        #region Select Statements
        public List<sp_Group_DM> ListGroups()
        {
            List<sp_Group_DM> list = new List<sp_Group_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Group_Select(null)
                            select new sp_Group_DM
                            {
                                GroupID = result.GroupID,
                                GroupName = result.GroupName,
                                ParticipationLevelID = result.ParticipationLevelID,
                                ActiveFlg = result.ActiveFlg,
                                ShortDesc = result.ShortDesc,
                                LongDesc = result.LongDesc


                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }
        public sp_Group_DM ListGroups(int? groupID)
        {
            List<sp_Group_DM> list = new List<sp_Group_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_Group_Select(groupID)
                            select new sp_Group_DM
                            {
                                GroupName = result.GroupName,
                                ParticipationLevelID = result.ParticipationLevelID,
                                ActiveFlg = result.ActiveFlg,
                                ShortDesc = result.ShortDesc,
                                LongDesc = result.LongDesc
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list.FirstOrDefault();
            //return list.FirstOrDefault();

        }
        #endregion

        # region Inserts

        public sp_Group_DM InsertGroupContext(ref sp_Group_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cGroup = new tblGroup
                {
                    GroupID = _cGroup.GroupID,
                    GroupName = _cGroup.GroupName,
                    ParticipationLevelID = _cGroup.ParticipationLevelID,
                    ActiveFlg = _cGroup.ActiveFlg,
                    ShortDesc = _cGroup.ShortDesc,
                    LongDesc = _cGroup.LongDesc

                };
                context.tblGroups.Add(cGroup);
                context.SaveChanges();

                // pass VolID back to BLL
                _cGroup.GroupID = cGroup.GroupID;

                return _cGroup;
            }
        }
        #endregion

        #region Updates
        public void UpdateGroupContext(sp_Group_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var cGroup = context.tblGroups.Find(_cGroup.GroupID);

                if (cGroup != null)
                {
                    cGroup.GroupName = _cGroup.GroupName;
                    cGroup.ParticipationLevelID = _cGroup.ParticipationLevelID;
                    cGroup.ActiveFlg = _cGroup.ActiveFlg;
                    cGroup.ShortDesc = _cGroup.ShortDesc;
                    cGroup.LongDesc = _cGroup.LongDesc;
                    context.SaveChanges();
                }
            }
        }
        #endregion
        #region Deletes
        public void DeleteGroupContext(sp_Group_DM _cGroup)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var GroupToRemove = (from n in context.tblGroups where n.GroupID == _cGroup.GroupID select n).FirstOrDefault();
                context.tblGroups.Remove(GroupToRemove);
                context.SaveChanges();

            }
        }
        #endregion

    }
}
