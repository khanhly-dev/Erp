using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Model.Common
{
    public partial class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
