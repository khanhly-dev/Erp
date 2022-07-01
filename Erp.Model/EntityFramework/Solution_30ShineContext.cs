using Erp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Model.EntityFramework
{
    public partial class Solution_30ShineContext : DbContext
    {
        public Solution_30ShineContext(DbContextOptions<Solution_30ShineContext> options) : base(options) { }
        public virtual DbSet<Customer> Customer { get; set; }
    }   
}
