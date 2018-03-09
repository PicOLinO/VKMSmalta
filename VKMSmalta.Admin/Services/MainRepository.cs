using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VKMSmalta.Admin.Models;
using VKMSmalta.Admin.Models.Domain;

namespace VKMSmalta.Admin.Services
{
    public class MainRepository
    {
        private ApplicationContext DbContext;

        public MainRepository()
        {
            DbContext = new ApplicationContext();
        }

        public List<Team> GetTeams()
        {
            DbContext.Teams.Load();
            return DbContext.Teams.Local.ToList();
        }
    }
}