using App.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            DisplayStates(context.ChangeTracker.Entries());
            context.SaveChanges();
        }

        public IList<Profile> Retrieve()
        {
            return context.Profile.ToList();
        }

        public void Update(Profile p)
        {
            context.Profile.Update(p);
            DisplayStates(context.ChangeTracker.Entries());
            context.SaveChanges();
        }

        public void Delete(Profile p)
        {
            context.Profile.Remove(p);
            DisplayStates(context.ChangeTracker.Entries());
            context.SaveChanges();
        }

        public void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, " +
                                  $"State: {entry.State.ToString()}");
            }
        }
    }
}
