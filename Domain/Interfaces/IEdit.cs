﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        TEntity Edit(TEntity entity);
    }
}
