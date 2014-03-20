using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Other;

namespace VolTeer.DataAccessLayer.VT.Other
{
    public class sp_State_DAL
    {
        public List<sp_State_Select_DM> ListStates()
        {
            List<sp_State_Select_DM> list = new List<sp_State_Select_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.sp_State_Select()
                        select new sp_State_Select_DM
                        {
                            StateID = result.StateID,
                            StateName = result.StateName,
                            StateAbbr = result.StateAbbr

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }
    }
}
