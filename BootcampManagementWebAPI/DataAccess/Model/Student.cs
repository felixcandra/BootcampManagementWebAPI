using Core;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student : BaseModel
    {
<<<<<<< HEAD
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
=======
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public System.Nullable<DateTimeOffset>  DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public System.Nullable<bool> Status { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string HiringLocation { get; set; }
        [Required]
        public virtual Class Classes { get; set; }
        public virtual Religion Religions { get; set; }
        public virtual Village Villages { get; set; }
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
    }
}
