using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public Int32 Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string HiringLocation { get; set; }
        public virtual Class Classes { get; set; }
        //public virtual Religion Religions { get; set; }
        //public virtual Village Villages { get; set; }
    }
}
