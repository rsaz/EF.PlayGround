using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    interface IProfile
    {
        void Create(Profile p);
        IList<Profile> Retrieve();
        void Update(Profile p);
        void Delete(Profile p);
    }
}
