using System;
using System.Data.SQLite;

namespace HabitTracker
{
    internal class Program
    {
        static string connectionString = @"Data Source=habitTracker.db";
        static void Main(string[] args)
        {
            //string connectionString = @"Data Source=habitTracker.db";
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("> ");
                Console.ResetColor();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye");
                        closeApp = true;
                        break;

                    case "1":
                        GetRecords();
                        break;
                    case "2":
                        AddRecord();
                        break;
                    case "3":
                        DeleteRecord();
                        break;
                    case "4":
                        UpdateRecord();
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid integer (0-4)");
                        break;
                }
            }
        }

        static void GetRecords()  //retrieve records from the server
        {

        }
        private static void AddRecord() //add new record
        {
            string date = DateInput();
            int hoursDuration = HoursInput();
            //now add the user inputs to the database
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText =
                    $"INSERT INTO WorkoutTracker (Date, Duration_hrs) VALUES('{date}', {hoursDuration})";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        internal static string DateInput()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nPlease enter workout date (Format: dd-mm-yy): Enter 0 to return to main menu \n> ");
            Console.ResetColor();
            string dateInput = Console.ReadLine();
            if (dateInput == "0") { UserInput(); }
            return dateInput;
        }
        internal static int HoursInput()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nPlease enter workout duration (Format: Integer only. Round up to nearest whole number): Enter 0 to return to main menu\n> ");
            Console.ResetColor();
            string hoursInput = Console.ReadLine();
            if(hoursInput == "0") { UserInput(); }
            return Int32.Parse(hoursInput);
        }
        static void DeleteRecord() //delete record
        {

        }
        static void UpdateRecord() //Update record
        {

        }
    }
}
