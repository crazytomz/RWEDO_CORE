using RWEDO.DataTransferObject;
using RWEDO.MSQLRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Services
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RWEDODbContext context;
        public UserRoleRepository(RWEDODbContext context)
        {
            this.context = context;
        }
        public UserRole GetUserRole(int ID)
        {
            return context.UserRoles.Find(ID);
        }
    }
}
