using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class StudentParam
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
<<<<<<< HEAD
        public Int32 Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
=======
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string HiringLocation { get; set; }
        public int? Class_Id { get; set; }
        public int? Religion_Id { get; set; }
        public int? Village_Id { get; set; }
    }
}
