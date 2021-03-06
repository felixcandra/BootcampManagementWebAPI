﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IOrganizationRepository
    {
        bool insert(OrganizationParam organizationParam);
        bool update(int? id, OrganizationParam organizationParam);
        bool delete(int? id);
        List<Organization> Get();
        Organization Get(int? id);
    }
}
