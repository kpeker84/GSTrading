using GSTradingProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.BLL.Patterns.Singleton
{
    public class DBTool
    {

        private DBTool() { }

        private static GSTradingContext _dbInstance;

        public static GSTradingContext DBInstance
        {
            get
            {

                if (_dbInstance == null)
                {

                    _dbInstance = new GSTradingContext();
                }

                return _dbInstance;

            }
        }












    }
}
