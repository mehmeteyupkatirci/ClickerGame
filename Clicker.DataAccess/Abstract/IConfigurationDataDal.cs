﻿using Clicker.Core.DataAccess;
using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.DataAccess.Abstract
{
    public interface IConfigurationDataDal : IEntityRepository<ConfigurationData>
    {
    }
}
