﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Model.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> listData { get; set; }
    }
}
