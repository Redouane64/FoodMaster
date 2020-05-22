using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FoodMaster.WebSite.Data
{
    public class FoodMasterDataContext : DbContext
    {
        public FoodMasterDataContext(DbContextOptions<FoodMasterDataContext> options)
            : base(options)
        { }
    }
}
