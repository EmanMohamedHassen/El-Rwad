using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Administration.Controllers
{
    public class UsersController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        //Get
        [HttpGet]
        public object SignIn(string userName, string password)
        {
            try
            {
                var user = db.Users.Where(s => s.User_Name == userName && s.User_Pass == password).FirstOrDefault();
                if (user != null)
                {
                    return new
                    {
                        userName = user.User_Name,
                        userId = user.User_ID,
                        userGroupId = user.User_Group_ID,
                        empId = user.Employee_ID,
                        isAdmin = user.IsAdmin.ToString(),
                        lastLogin = DateTime.Now
                    };

                }
                else
                {
                    return new
                    {
                        Id = 0
                    };

                }
            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]
        public dynamic GetUserById(int userId)
        {
            try
            {
                var user = db.Users.Where(s => s.User_ID == userId).FirstOrDefault();
                if (user != null)
                {
                    return new
                    {

                        userGroupId = user.User_Group_ID,
                        userName = user.User_Name,
                        empId = user.Employee_ID,
                        isAdmin = user.IsAdmin.ToString(),
                        lastLogin = user.LastLogIn,
                        notes = user.Notes,
                        lastUpdate = user.LastUpdated.ToString("yyyy-MM-dd")

                    };
                }
                else
                {
                    return new
                    {
                        Id = 0
                    };

                }
            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]
        public dynamic GetAllUsers()
        {
            var user = db.Users.Select(s => new
            {
                userName = s.User_Name,
                userId = s.User_ID,
                empId = s.Employee_ID,
                userGroupId = s.User_Group_ID,
                isAdmin = s.IsAdmin.ToString()

            }).ToList();
            return user;
        }


        //public dynamic GetPassword(int userId,int code)
        //{
        //    try
        //    {
        //        var user = db.Users.Where(s => s.User_ID == userId &&).FirstOrDefault();
        //        if (user != null)
        //        {
        //            return new
        //            {
        //                userId = user.User_ID,
        //                userGroupId = user.User_Group_ID,
        //                userName = user.User_Name,
        //                isAdmin = user.IsAdmin,
        //                lastLogin = user.LastLogIn,
        //                notes = user.Notes,
        //                lastUpdate = user.LastUpdated

        //            };
        //        }
        //        else
        //        {
        //            return new
        //            {
        //                Id = 0
        //            };

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new
        //        {
        //            result = new
        //            {
        //                Id = 0
        //            }
        //        };
        //    }
        //}
        [HttpPost]
        public dynamic PostUser(
            int userGroupId,
            string userName,
            string password,
            bool isAdmin,
            int empId,
            string notes
            )
        {
            db.Users.Add(new User
            {
                User_Group_ID = userGroupId,
                User_Name = userName,
                User_Pass = password,
                Employee_ID = empId,
                IsAdmin = isAdmin,
                Notes = notes,
                LastUpdated = DateTime.Now
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }
        //public dynamic PutForChangeLastLogin(int userId)
        //{
        //    var user = db.Users.Find(userId);
        //    user.LastLogIn = DateTime.Now;
        //    var result = db.SaveChanges() > 0 ? true : false;
        //    return new
        //    {
        //        reslt = result
        //    };
        //}

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutUser(
            int userId,
            int userGroupId,
            string userName,
            string password,
            int empId,
            bool isAdmin,
            string notes
            )
        {
            var user = db.Users.Find(userId);
            user.User_Group_ID = userGroupId;
            user.User_Name = userName;
            user.User_Pass = password;
            user.Employee_ID = empId;
            user.IsAdmin = isAdmin;
            user.Notes = notes;
            user.LastUpdated = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutToChangePassword(int userId, string password, string newPassword)
        {
            var user = db.Users.Find(userId);

            if (password != user.User_Pass)
            {
                return new { result = "false password" };
            }

            user.User_Pass = newPassword;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteUser(int userId)
        {
            var user = db.Users.Where(s => s.User_ID == userId).FirstOrDefault();
            db.Users.Remove(user);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpGet]
        private dynamic UserExists(int userId)
        {
            var user = db.Users.Count(e => e.User_ID == userId) > 0 ? true : false;
            return new
            {
                user = user
            };
        }

    }
}
