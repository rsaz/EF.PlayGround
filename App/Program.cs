/* 
 * Entity Framework Playground
 * Author: Richard Zampieri
 */

using App.ADO;
using App.Entity;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateUsingADO();

            CreateUsingEntity();
            RetrieveEntity();

            UpdateEntity();
            RetrieveEntity();
            
            DeleteEntity();
            RetrieveEntity();
        }

        //** Using ADO Model **//
        static void CreateUsingADO()
        {
            // Data Seed
            var profile = new Profile();
            profile.Name = "Profile ADO";
            profile.Gender = "Neutral";
            profile.Age = 1;

            using var ado = new ProfileADO();
            ado.Create(profile);

        }

        //** Using Entity **//

        //Create
        static void CreateUsingEntity()
        {
            // Data Seed
            var profile = new Profile();
            profile.Name = "Profile Entity";
            profile.Gender = "Neutral";
            profile.Age = 2;

            using (var context = new ApplicationContext())
            {
                context.Profile.Add(profile);
                context.SaveChanges();
            }   
        }
        //Retrieve
        static void RetrieveEntity()
        {
            using (var context = new ApplicationContext())
            {
                var profiles = context.Profile.ToList();
                Console.WriteLine($"Data retrieved: {profiles.Count} profile(s)");

                // show in the console the result of profiles
                foreach (var item in profiles)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        // Update item
        static void UpdateEntity()
        {
            using (var context = new ApplicationContext())
            {
                var profileItem = context.Profile.First();
                profileItem.Name = "Profile Entity Updated";
                context.Profile.Update(profileItem);
                context.SaveChanges();
            }
        }
        // Delete all items
        static void DeleteEntity()
        {
            using (var context = new ApplicationContext())
            {
                var profiles = context.Profile.ToList();

                foreach (var item in profiles)
                {
                    context.Profile.Remove(item);
                }

                context.SaveChanges();
            }
        }


    }
}
