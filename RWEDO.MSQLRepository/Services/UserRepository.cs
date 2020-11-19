using RWEDO.DataTransferObject;
using RWEDO.MSQLRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly RWEDODbContext context;
        public UserRepository(RWEDODbContext context)
        {
            this.context = context;
        }
        public User GetUserUsingCredentials(string userName, string password)
        {
            return context.Users.Find(new User { UserName=userName,Password=password});
        }
    }
}
