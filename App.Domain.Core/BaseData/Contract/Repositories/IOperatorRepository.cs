﻿using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface IOperatorRepository
    {
        List<Operator> GetAll();
        Operator GetById(int id);
        void Add(Operator @operator);
        void Remove(int id);

    }
}