using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRoleRepository
    {
        List<Role> GetRolesAll();
        Role GetRoleById(int id);
        void DeleteRole(Role role);
        void AddRole(Role role);
        void UpdateRole(Role role);
    }
}
