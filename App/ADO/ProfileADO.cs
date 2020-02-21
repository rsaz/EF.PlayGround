using App.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.ADO
{
    class ProfileADO : IDisposable
    {
        private SqlConnection connection;

        public ProfileADO()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        /** CRUD **/
        public void Create(Profile p)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Profile (Name, Gender, Age) VALUES (@name, @gender, @age)";
                
                var paramName = new SqlParameter("name", p.Name);
                cmd.Parameters.Add(paramName);

                var paramGender = new SqlParameter("gender", p.Gender);
                cmd.Parameters.Add(paramGender);

                var paramAge = new SqlParameter("age", p.Age);
                cmd.Parameters.Add(paramAge);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public IList<Profile> Retrieve()
        {
            var profiles = new List<Profile>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Profile";

            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                var p = new Profile();
                p.Id = Convert.ToInt32(result["Id"]);
                p.Name = Convert.ToString(result["Name"]);
                p.Gender = Convert.ToString(result["Gender"]);
                p.Age = Convert.ToInt32(result["Age"]);
                profiles.Add(p);
            }
            result.Close();

            return profiles;
        }



        public void Update(Profile p)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Profile SET Name = @name, Gender = @gender, Age = @age WHERE Id = @id";

                var paramName = new SqlParameter("name", p.Name);
                cmd.Parameters.Add(paramName);

                var paramGender = new SqlParameter("gender", p.Gender);
                cmd.Parameters.Add(paramGender);

                var paramAge = new SqlParameter("age", p.Age);
                cmd.Parameters.Add(paramAge);

                var paramId = new SqlParameter("id", p.Id);
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Delete(Profile p)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Profile WHERE Id = @id";

                var paramId = new SqlParameter("id", p.Id);
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

       

    }
}
