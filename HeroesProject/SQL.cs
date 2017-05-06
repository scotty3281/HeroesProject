using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HeroesProject.SQL
{
    class SQL
    {
        SQLiteConnection m_dbConnection;

        public static void CreateDatabase(string dbName)
        {
            SQLiteConnection.CreateFile(dbName+".sqlite");
            Console.WriteLine("Database: {0} created", dbName);
        }

        static void ConnectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        public void CreateTable(string tableName)
        {
            string sql = $"create table {tableName};)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            Console.WriteLine($"{tableName} created");
        }

        public void AddColumn(string dbName, string name, string type, string length = "max")
        {
            string column = $"ALTER TABLE {dbName} ADD COLUMN {name} ({type} {length});";

            SQLiteCommand command = new SQLiteCommand(column, m_dbConnection);
            command.ExecuteNonQuery();

            Console.WriteLine($"Column: {name}, type: {type}, length: {length}  created");
        }

        public void InsertValues(string tableName, string[] columns, string[] values)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($"insert into {tableName} (");

            for (int i = 0; i<columns.Length; i++)
            {
                sql.Append(columns[i]+", ");
            }

            sql.Append(") VALUES (");

            for(int i = 0; i<values.Length; i++)
            {
                sql.Append(values[i] + ", ");
            }

            sql.Append(");");

            SQLiteCommand command = new SQLiteCommand(sql.ToString(), m_dbConnection);
            command.ExecuteNonQuery();

            Console.WriteLine("Values Inserted");
        }

        public void PrintTableContents(string tableName, string sorter = "null")
        {
            string sql = "";
            if (sorter == "null")
            {
                sql = $"select * from {tableName};";
            }
            else
            {
                sql = $"select * from {tableName} order by {sorter} desc;";
            }
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            for (int i=0; i<=reader.FieldCount;i++)
                Console.WriteLine(reader.GetName(i) + "\t" + reader.GetValue(i));
            Console.ReadLine();
        }
    }
}
