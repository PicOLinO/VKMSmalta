using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VKMSmalta.Admin.Models;
using VKMSmalta.Admin.Models.Domain;

namespace VKMSmalta.Admin.Services
{
    public class MainRepository
    {
        private readonly ApplicationContext dbContext;

        public MainRepository()
        {
            dbContext = new ApplicationContext();
        }

        public List<Team> GetTeams()
        {
            dbContext.Teams.Load();
            return dbContext.Teams.Local.ToList();
        }
    }
}