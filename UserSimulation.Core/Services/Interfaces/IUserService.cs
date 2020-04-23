using System;
using System.Collections.Generic;
using System.Text;
using UserSimulation.Core.Models;

namespace UserSimulation.Core.Services.Interfaces
{
    public interface IUserService
    {
        public void AddUser(UserEntity userEntity);
        public UserEntity GetUserById(int id);
        public void PutUserById(int id, UserEntity userEntity);
    }
}
