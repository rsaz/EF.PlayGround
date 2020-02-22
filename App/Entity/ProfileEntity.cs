using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Entity
{
    class ProfileEntity : IDisposable, IProfile
    {
        private readonly ApplicationContext context;

        public ProfileEntity()
        {
            context = new ApplicationContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Create(Profile p)
        {
            context.Profile.Add(p);
            context.SaveChanges();
        }

        public IList<Profile> Retrieve()
        {
            return context.Profile.ToList();
        }

        public void Update(Profile p)
        {
            context.Profile.Update(p);
            context.SaveChanges();
        }

        public void Delete(Profile p)
        {
            context.Profile.Remove(p);
            context.SaveChanges();
        }
    }
}
