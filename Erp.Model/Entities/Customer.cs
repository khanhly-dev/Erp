using Erp.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Model.Entities
{
    public partial class Customer : BaseEntity<int>
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte? IsDelete { get; set; }

    }
}
