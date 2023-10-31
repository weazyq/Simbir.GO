using Npgsql;
using System.Diagnostics;

namespace Run
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин суперпользователя PostgreSQL: ");
            String? username = Console.ReadLine();

            Console.WriteLine("Введите пароль суперпользователя PostgreSQL: ");
            String? password = Console.ReadLine();

            String connectionString = $"Host=localhost;Port=5432;Username={username};Password={password};Database=postgres";

            using (NpgsqlConnection conn = new(connectionString))
            {
                conn.Open();
                Console.WriteLine("Успешно подключено к PostgreSQL!");

                String createDataBaseCommandScript = File.ReadAllText("create_database.sql");

                using (var createDataBaseCommand = new NpgsqlCommand(createDataBaseCommandScript, conn))
                    try
                    {
                        createDataBaseCommand.ExecuteNonQuery();
                        Console.WriteLine("База данных успешно создана.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при выполнении SQL-скрипта: {ex.Message}");
                    }
            }

            connectionString = $"Host=localhost;Port=5432;Username={username};Password={password};Database=simbirgo";
            using (NpgsqlConnection conn = new(connectionString))
            {
                conn.Open();
                String sqlScript = File.ReadAllText("basescript.sql");
                using (NpgsqlCommand baseCommand = new NpgsqlCommand(sqlScript, conn))
                    try
                    {
                        baseCommand.ExecuteNonQuery();
                        Console.WriteLine("База данных успешно заполнена.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при выполнении SQL-скрипта: {ex.Message}");
                    }
            }

            Console.ReadKey();
        }
    }
}