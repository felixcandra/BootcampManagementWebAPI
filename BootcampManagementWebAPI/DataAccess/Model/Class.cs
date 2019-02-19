using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Class : BaseModel
    {
        public string Name { get; set; }
        public virtual Department Departments { get; set; }
        public virtual Batch Batches { get; set; }
<<<<<<< HEAD
        //public virtual Employee Employees { get; set; }
=======
        public virtual Employee Employees { get; set; }
>>>>>>> d2905a1880af22bd91c3b074297a75b37bab3a43
    }
}
