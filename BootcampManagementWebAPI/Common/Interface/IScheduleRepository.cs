﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IScheduleRepository
    {
        bool insert(ScheduleParam scheduleParam);
        bool update(int? id, ScheduleParam scheduleParam);
        bool delete(int? id);
        List<Schedule> Get();
        Schedule Get(int? id);
    }
}
