using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsersAll();
        User GetUserById(int id);
        User GetUserByMail(string mail);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<Role> GetRoles(User user);
    }
}
