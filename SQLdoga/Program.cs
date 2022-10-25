using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ClonsoeAdatbazis
{

    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT `pazon`, `pnev`, `par` FROM `pizza`;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int pazon = dr.GetInt32("pazon");
                        string pnev = dr.GetString("pnev");
                        int par = dr.GetInt32("par");
                        Console.WriteLine($"{pazon}. {pnev}\t{par}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
            
            
            MySqlConnection feladat23 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "@\"SELECT fnev, Count(DISTINCT razon) FROM futar JOIN rendeles USING(fazon) GROUP BY fazon;\"";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int fazon = dr.GetInt32("fazon");
                        string fnev = dr.GetString("fnev");
                        string futar = dr.GetString("futar");
                        Console.WriteLine($"{fazon}. {fnev}\t{futar}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }


            MySqlConnection feladat24 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT pnev, Sum(db) som FROM pizza JOIN tetel USING(pazon) GROUP BY pazon ORDER BY som DESC;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int pazon = dr.GetInt32("pazon");
                        string pnev = dr.GetString("pnev");
                        string tetel = dr.GetString("tetel");
                        Console.WriteLine($"{pazon}. {pnev}\t{tetel}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }


            MySqlConnection feladat25 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT vnev, Sum(db * par) som FROM vevo JOIN rendeles USING (vazon) JOIN tetel USING(razon) JOIN pizza USING (pazon) GROUP BY vazon ORDER BY som DESC;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int pazon = dr.GetInt32("pazon");
                        string vnev = dr.GetString("vnev");
                        int par = dr.GetInt32("par");
                        string vevo = dr.GetString("vevo");
                        int vazon = dr.GetInt32("vazon");
                        string tetel = dr.GetString("tetel");
                        Console.WriteLine($"{pazon}.{vevo}.{vazon}.{tetel}.{vnev}\t{par}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }


            MySqlConnection feladat26 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT pnev, par FROM pizza ORDER BY par DESC LIMIT 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string pnev = dr.GetString("pnev");
                        int par = dr.GetInt32("par");
                        Console.WriteLine($"{pnev}\t{par}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }


            MySqlConnection feladat27 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT fnev, Count(DISTINCT razon) cunt FROM futar JOIN rendeles USING(fazon) GROUP BY fazon ORDER BY cunt DESC LIMIT 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int razon = dr.GetInt32("razon");
                        string fnev = dr.GetString("fnev");
                        string rendeles = dr.GetString("rendeles");
                        string futar = dr.GetString("futar");
                        int fazon = dr.GetInt32("fazon");
                        Console.WriteLine($"{razon}.{rendeles}.{futar}.{fnev}\t{fazon}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }


            MySqlConnection feladat28 = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT vnev, Sum(db)som FROM vevo JOIN rendeles USING(vazon) JOIN tetel USING(razon) GROUP BY vazon ORDER BY som DESC LIMIT 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int vazon = dr.GetInt32("vazon");
                        string vnev = dr.GetString("vnev");
                        string vevo = dr.GetString("vevo");
                        string rendeles = dr.GetString("rendeles");
                        string tetel = dr.GetString("tetel");
                        int razon = dr.GetInt32("razon");
                        Console.WriteLine($"{vazon}.{rendeles}.{tetel}.{razon}.{vnev}\t{vevo}");
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
    }
}