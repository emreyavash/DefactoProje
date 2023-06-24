using Business.Interface;
using DataAccess;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _repository;
        private readonly DefactoContext _context;

        public UserRepository(IGenericRepository<User> repository,DefactoContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void AddUser(User user)
        {
            _repository.Add(user);
        }

        public void DeleteUser(User user)
        {
            _repository.Delete(user);
        }

        public List<Role> GetRoles(User user)
        {
            var roles = new List<Role>();
            var userRole = _context.UserRoles.Where(x => x.UserId==user.Id).ToList();
            foreach (var item in userRole)
            {

                var role = _context.Roles.Where(x => x.Id == item.RoleId).FirstOrDefault();
                roles.Add(role);
            }
            return roles.ToList();

        }

        public User GetUserById(int id)
        {
            var result = _repository.Get(x=>x.Id == id);
            return result;
        }

        public User GetUserByMail(string mail)
        {
            var result = _repository.Get(x => x.Email == mail);
            return result;
        }

        public List<User> GetUsersAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }
    }
}
