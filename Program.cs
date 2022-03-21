using System;
using System.Data.SQLite;

namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=habitTracker.db";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand(); // create a command to send to the database
                // create the database and table
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS WorkoutTracker (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Duration_hrs INTEGER
                    )";
                cmd.ExecuteNonQuery(); //execute the command w/ returning any values
                connection.Close(); // close the connection
            }
            //intro to the app and get user input
            Console.WriteLine("Hello! Welcome to the WorkoutTacker app where you will be able to log your workout.");
            UserInput();
        }
        
        static void UserInput()
        {
            Console.Clear();
            bool closeApp = false;
            int input;
            while (closeApp == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nWhat would you like to do (TYPE A NUMBER)");
                Console.ResetColor();
                Console.WriteLine("0. Close app");
                Console.WriteLine("1. View All Records");
                Console.WriteLine("2. New Record Entry");
                Console.WriteLine("3. Delete Record");
                Console.WriteLine("4. Update Record");
                Console.Write("> ");
                do
                {
                    input = Console.Read();
                }while (input < 0 || input > 4);

                switch (input)
                {
                    case 0:
                        Console.WriteLine("\nGoodbye");
                        closeApp = true;
                        break;
                }
            }
        }
    }
}
