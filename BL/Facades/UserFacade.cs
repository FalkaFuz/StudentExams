using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using BL.DTO;
using DAL;
using DAL.IdentityEntities;
using Microsoft.AspNet.Identity;

namespace BL.Facades
{
    public class UserFacade
    {
        public void Register(UserDTO user)
        {
            var userManager = new AppUserManager(new AppUserStore(new AppDbContext()));

            AppUser appUser = Mapping.Mapper.Map<AppUser>(user);

            userManager.Create(appUser, user.Password);

            var ourUser = userManager.FindByName(appUser.UserName);

            var roleManager = new AppRoleManager(new AppRoleStore(new AppDbContext()));

            if (user.RegistrationCode != null)
            {
                if (user.RegistrationCode.Equals("KNOWLEDGE"))
                {
                    if (!roleManager.RoleExists("Teacher"))
                    {
                        roleManager.Create(new AppRole { Name = "Teacher" });
                    }

                    userManager.AddToRole(ourUser.Id, "Teacher");
                }
            } else
            {
                if (!roleManager.RoleExists("Student"))
                {
                    roleManager.Create(new AppRole { Name = "Student" });
                }

                userManager.AddToRole(ourUser.Id, "Student");
            }
        }

        public List<UserDTO> GetAllStudents()
        {
            var context = new AppDbContext();
            var studentRole = context.Roles.Where(x => x.Name.Equals("Student")).First();
            if (studentRole == null) {
                var list = new List<UserDTO>();
                return list;
            }
            return Mapping.Mapper.Map<List<AppUser>, List<UserDTO>>(context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(studentRole.Id)).ToList());
        }
        

        public ClaimsIdentity Login(string email, string password)
        {
            var userManager = new AppUserManager(new AppUserStore(new AppDbContext()));

            var wantedUser = userManager.FindByEmail(email);


            if (wantedUser == null)
            {
                return null;
            }

            AppUser user = userManager.Find(wantedUser.UserName, password);

            if (user == null)
            {
                return null;
            }

            return userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
