using Business.Interface;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IGenericRepository<Role> _repository;

        public RoleRepository(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }

        public void AddRole(Role role)
        {
            _repository.Add(role);
        }

        public void DeleteRole(Role role)
        {
            _repository.Delete(role);
        }

        public Role GetRoleById(int id)
        {
            var result = _repository.Get(x=>x.Id == id);
            return result;
        }

        public List<Role> GetRolesAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public void UpdateRole(Role role)
        {
            _repository.Update(role);
        }
    }
}
