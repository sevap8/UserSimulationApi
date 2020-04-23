using System;
using System.Collections.Generic;
using System.Text;
using UserSimulation.Core.Models;

namespace UserSimulation.Core.Repositories
{
    public interface IUserRepositories
    {
        void Add(UserEntity userEntity);
        UserEntity Get(int id);
        bool ContainsId(int entityId);
        bool Contains(UserEntity userEntity);
        void Put(int id, UserEntity userEntity);
    }
}
