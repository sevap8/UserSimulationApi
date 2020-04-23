using System;
using System.Collections.Generic;
using System.Text;
using UserSimulation.Core.Models;
using UserSimulation.Data.Context.Interfaces;

namespace UserSimulation.Data.Context
{
    public class DataContext : IDataContext
    {
        public static List<UserEntity> Data = new List<UserEntity>();
    }
}
