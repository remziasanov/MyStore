using StoreExample.DataBaseManager;
using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StoreExample.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string email)
        {
            string[] roles = new string[] { };
            Purchase purchase = new Purchase();
            using (DataBaseContext db = new DataBaseContext())
            {
                // Получаем пользователя
                purchase = db.Purchases.FirstOrDefault(u => u.Email == email);
                if (purchase != null)
                {
                    // находим роль
                    Role UserRole = db.Roles.Find(purchase.RoleId);
                    if (UserRole != null)
                        roles = new string[] { purchase.Role.Name };
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {

            using (DataBaseContext db = new DataBaseContext())
            {
                // Получаем пользователя
                Purchase user = db.Purchases.FirstOrDefault(u => u.Email == email);

                if (user != null && user.Role != null && user.Role.Name == roleName)
                    return true;
                else
                    return false;
            }


        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}