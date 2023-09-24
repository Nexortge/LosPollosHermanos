using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // MySQL

namespace Lj2Dd1En2.Models
{
    internal class LosPollosHermanosDB
    {
        private string _connectionString =
            ConfigurationManager.ConnectionStrings["LosPollosHermanosDBConn"].ConnectionString;


        public string Getmeals(ICollection<Meal> meals)
        {
            if (meals == null)
            {
                throw new ArgumentNullException("Ongeldig argument bij gebruik van GetMeals()");

            }
            string methodResult = "";
            using (MySqlConnection conn = new(_connectionString))
            {

            }
    }
    }

    
}
