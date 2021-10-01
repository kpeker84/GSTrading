using GSTradingProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {

        }
    }
}
