/* 
 * Entity Framework Playground
 * Author: Richard Zampieri
 */

using App.ADO;
using App.Entity;
using App.Models;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateUsingADO();
            CreateUsingEntity();
        }

        // Using ADO Model
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

        // Using Entity
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

    }
}
