using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatDB;

namespace CatRepository
{
    public class DatabaseManager
    {
        private static readonly CATSEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new CATSEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static CATSEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
