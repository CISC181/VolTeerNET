using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using VolTeer.DomainModels.AspNet;


namespace VolTeer.DataAccessLayer.AspNet
{
    public class AspNetUsersDAL
    {
        public List<aspnet_Users> ListAspNetUsers()
        {
            List<aspnet_Users> list = new List<aspnet_Users>();
            using (AspNetProviderEntities context = new AspNetProviderEntities())
            {
                list = (from result in context.aspnet_Users
                        select new aspnet_Users
                        {
                            ApplicationId = result.ApplicationId,
                            aspnet_Applications = result.aspnet_Applications,
                            aspnet_Membership = result.aspnet_Membership,
                            aspnet_PersonalizationPerUser = result.aspnet_PersonalizationPerUser,
                            aspnet_Profile = result.aspnet_Profile,
                            aspnet_Roles = result.aspnet_Roles,
                            IsAnonymous = result.IsAnonymous,
                            LastActivityDate = result.LastActivityDate,
                            LoweredUserName = result.LoweredUserName,
                            MobileAlias = result.MobileAlias,
                            UserId = result.UserId,
                            UserName = result.UserName
                        }).ToList();
            } // Guaranteed to close the Connection
            return list;

        }

        public List<vw_aspnet_MembershipUsers_DM> vMembershipUsers_In_Role(string RoleName)
        {
            List<vw_aspnet_MembershipUsers_DM> list = new List<vw_aspnet_MembershipUsers_DM>();
            using (AspNetProviderEntities context = new AspNetProviderEntities())
            {
                list = (from memUsers in context.vw_aspnet_MembershipUsers
                        join memUserInRole in context.vw_aspnet_UsersInRoles on memUsers.UserId equals memUserInRole.UserId
                        join memRole in context.vw_aspnet_Roles on memUserInRole.RoleId equals memRole.RoleId
                        where memRole.RoleName == RoleName
                        select new vw_aspnet_MembershipUsers_DM
                        {
                            ApplicationId = memUsers.ApplicationId,
                            Comment = memUsers.Comment,
                            CreateDate = memUsers.CreateDate,
                            Email = memUsers.Email,
                            FailedPasswordAnswerAttemptCount = memUsers.FailedPasswordAnswerAttemptCount,
                            FailedPasswordAnswerAttemptWindowStart = memUsers.FailedPasswordAnswerAttemptWindowStart,
                            FailedPasswordAttemptCount = memUsers.FailedPasswordAttemptCount,
                            FailedPasswordAttemptWindowStart = memUsers.FailedPasswordAttemptWindowStart,
                            IsAnonymous = memUsers.IsAnonymous,
                            IsApproved = memUsers.IsApproved,
                            IsLockedOut = memUsers.IsLockedOut,
                            LastActivityDate = memUsers.LastActivityDate,
                            LastLockoutDate = memUsers.LastLockoutDate,
                            LastLoginDate = memUsers.LastLoginDate,
                            LastPasswordChangedDate = memUsers.LastPasswordChangedDate,
                            LoweredEmail = memUsers.LoweredEmail,
                            MobileAlias = memUsers.MobileAlias,
                            MobilePIN = memUsers.MobilePIN,
                            PasswordAnswer = memUsers.PasswordAnswer,
                            PasswordFormat = memUsers.PasswordFormat,
                            PasswordQuestion = memUsers.PasswordQuestion,
                            UserId = memUsers.UserId,
                            UserName = memUsers.UserName
                        }).ToList();
            } // Guaranteed to close the Connection
            return list;

        }

    }
}