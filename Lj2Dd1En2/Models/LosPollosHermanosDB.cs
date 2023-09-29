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
        public const string OK = "OK";

        private string _connectionString =
            ConfigurationManager.ConnectionStrings["LosPollosHermanosDBConn"].ConnectionString;



        /// <summary>
        /// Pakt alles uit de Meals en zet het in een ICollection
        /// Als de ICollection null is, wordt er een ArgumentNullException gegooid
        /// OK = Geen fouten
        /// Foutmedling = Er is een fout opgetreden
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Getmeals(ICollection<Meal> meals)
        {
            if (meals == null)
            {
                throw new ArgumentNullException("Ongeldig argument bij gebruik van GetMeals()");

            }
            string methodResult = "";
            using (MySqlConnection conn = new(_connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT m.MealId, m.Name, m.Description, m.Price FROM `meals` m";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Meal meal = new Meal()
                        {
                            MealId = (int)reader["MealId"],
                            Name = (string)reader["Name"],
                            Description = reader["Description"] == DBNull.Value  
                                    ? null
                                    : (string)reader["Description"],

                            Price = (decimal)reader["Price"]
                        };
                        meals.Add(meal);
                    }
                    methodResult = OK;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(nameof(Getmeals));
                    Console.WriteLine(ex.Message);
                    methodResult = ex.Message;

                }
            }
            return methodResult;
        }
    }
}
