﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Data
{
    public class SqlDataQueryResult
    {
        public IEnumerable<SqlDataQueryParameter> OutputParameters { get; set; }
    }
}
