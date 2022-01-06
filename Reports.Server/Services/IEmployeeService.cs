﻿using System;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        Employee Create(string name, Guid leadId);
        Employee FindByName(string name);

        Employee FindById(Guid id);
    }
}