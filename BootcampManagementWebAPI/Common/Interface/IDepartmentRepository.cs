﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IDepartmentRepository
    {
        bool insert(DepartmentParam departmentParam);
        bool update(int? id, DepartmentParam departmentParam);
        bool delete(int? id);
        List<Department> Get();
        Department Get(int? id);
    }
}
