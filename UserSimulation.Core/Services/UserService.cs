using System;
using System.Collections.Generic;
using System.Text;
using UserSimulation.Core.Models;
using UserSimulation.Core.Repositories;
using UserSimulation.Core.Services.Interfaces;

namespace UserSimulation.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories userRepositories;
        public UserService(IUserRepositories userRepositories)
        {
            this.userRepositories = userRepositories;
        }

        public void AddUser(UserEntity userEntity)
        {
            if (this.userRepositories.Contains(userEntity))
            {
                throw new ArgumentException("This Entity has been registered. Can't continue");
            }
            this.userRepositories.Add(userEntity);
        }

        public UserEntity GetUserById(int id)
        {
            if (!this.userRepositories.ContainsId(id))
            {
                throw new ArgumentException($"This Entity is missing {id}! ");
            }
            return this.userRepositories.Get(id);
        }

        public void PutUserById(int id, UserEntity userEntity)
        {
            if (!this.userRepositories.ContainsId(id))
            {
                throw new ArgumentException($"This Entity is missing {id} !");
            }

            this.userRepositories.Put(id, userEntity);
        }
    }
}
