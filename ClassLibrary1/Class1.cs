using System;

using System.Runtime.InteropServices;
using ClassLibrary1.Model;


namespace ClassLibrary1
{
    public class Class1
    {
        public List<GetUser> Getuser()
        {

            UserDb userDb = new UserDb();
            List<GetUser> getUser = userDb.Getuser();
            if (getUser.Count > 0)
            {
                return getUser;
            }
            else
            {
                List<GetUser> users = new List<GetUser>();
                return users;
            }



        }
        public bool Adduser(string name, string email, string password)
        {

            NewUser user = new NewUser();
            user.Name = name;
            user.Email = email;
            user.Password = password;
            if (!String.IsNullOrEmpty(user.Name) && !String.IsNullOrEmpty(user.Email) && !String.IsNullOrEmpty(user.Password))
            {

                UserDb userDb = new UserDb();
                bool updateUser = userDb.AddUser(user);
                if (updateUser)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool Updateuser(Guid id, string name, string email, string password)
        {

            User user = new User();
            user.Id = id;
            user.Name = name;
            user.Email = email;
            user.Password = password;
            if (id != Guid.Empty && !String.IsNullOrEmpty(user.Name) && !String.IsNullOrEmpty(user.Email) && !String.IsNullOrEmpty(user.Password))
            {

                UserDb userDb = new UserDb();
                bool updateUser = userDb.UpdateUser(user);
                if (updateUser)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool Deleteuser(Guid id)
        {


            if (id != Guid.Empty)
            {

                UserDb userDb = new UserDb();
                bool deleteUser = userDb.DeleteUser(id);
                if (deleteUser)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }

}




