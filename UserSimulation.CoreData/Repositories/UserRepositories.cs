using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSimulation.Core.Models;
using UserSimulation.Core.Repositories;
using UserSimulation.Data.Context;

namespace UserSimulation.Data.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly DataContext dataContext;

        public UserRepositories(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(UserEntity userEntity)
        {
            UserEntity entity = new UserEntity
            { 
                Id = userEntity.Id, 
                Name = userEntity.Name,
                Surname = userEntity.Surname
            };
            DataContext.Data.Add(entity);
        }

        public bool Contains(UserEntity userEntity)
        {
            var result = DataContext.Data.Any(a =>
            a.Id == userEntity.Id
           && a.Name == userEntity.Name
           && a.Surname == userEntity.Surname);

            if (result == null)
            {
                return false;
            }
            return result;
        }

        public bool ContainsId(int entityId)
        {
            return DataContext.Data.Any(a =>
        a.Id == entityId);
        }

        public UserEntity Get(int id)
        {
            return DataContext.Data.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Put(int id, UserEntity userEntity)
        {
            for (int i = 0; i < DataContext.Data.Count; i++)
            {
                if (DataContext.Data[i].Id == id)
                {
                    var index = DataContext.Data.IndexOf(DataContext.Data[i]);
                    DataContext.Data[index] = userEntity;
                }
                break;
            }

        }
    }
}
