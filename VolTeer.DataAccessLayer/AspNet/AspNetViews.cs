using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.AspNet;



namespace VolTeer.DataAccessLayer.AspNet
{
    public class AspNetViews
    {

        public vw_aspnet_MembershipUsers_DM ListUser(string strUserName)
        {
            vw_aspnet_MembershipUsers_DM list = new vw_aspnet_MembershipUsers_DM();
            try
            {
                using (AspNetProviderEntities context = new AspNetProviderEntities())
                {
                    list = (from result in context.vw_aspnet_MembershipUsers
                            where result.UserName == strUserName
                            select new vw_aspnet_MembershipUsers_DM
                            {
                                ApplicationId = result.ApplicationId,
                                Comment = result.Comment,
                                CreateDate = result.CreateDate,
                                Email = result.Email,
                                FailedPasswordAnswerAttemptCount = result.FailedPasswordAnswerAttemptCount,
                                FailedPasswordAnswerAttemptWindowStart = result.FailedPasswordAnswerAttemptWindowStart,
                                FailedPasswordAttemptCount = result.FailedPasswordAttemptCount,
                                FailedPasswordAttemptWindowStart = result.FailedPasswordAttemptWindowStart,
                                IsAnonymous = result.IsAnonymous,
                                IsApproved = result.IsApproved,
                                IsLockedOut = result.IsLockedOut,
                                UserId = result.UserId,
                                UserName = result.UserName,
                                LastActivityDate = result.LastActivityDate,
                                LastLockoutDate = result.LastLockoutDate,
                                LastLoginDate = result.LastLoginDate,
                                LoweredEmail = result.LoweredEmail,
                                LastPasswordChangedDate = result.LastPasswordChangedDate
                            }).Single();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }
    }
}
