using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.Transactions;

namespace TillApp
{
    class DataBaseHelper
    {
        private static string connectionString = @"Data Source = C:\Users\maxro\Desktop\Uni work 2024\Github\TillApp\TillApp\history.db";

        public static DataBaseHelper _instance;

        private DataBaseHelper() { }

        public static DataBaseHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBaseHelper();
                }
                return _instance;
            }
        }

        public List<String> getTransactions()
        {
            List<String> transactions = new List<String>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection Opened");
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM Transactions", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string transaction = reader["TRANSACTION_ID"].ToString();
                    Console.WriteLine(transaction);
                    transactions.Add(transaction);
                }
                return transactions;
            }
        }
        public void addTransaction(List<List<int>> Transaction)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Begin the transaction
                {
                    SQLiteCommand get_latest_id = new SQLiteCommand("SELECT MAX(ORDER_ID) FROM ORDERS", connection, transaction);
                    //SQLiteDataReader reader = get_latest_id.ExecuteReader();
                    var latest_id = get_latest_id.ExecuteScalar();
                    long TransactionID = (long)latest_id + 1;

                    foreach (List<int> item in Transaction)
                    {
                        int itemID = (int)item[0];
                        int quant = (int)item[1];
                        SQLiteCommand add_command = new SQLiteCommand("INSERT INTO ORDERS (ORDER_ID ,ITEM_ID,QUANTITY) VALUES (@TransactionID,@itemID,@quant)", connection, transaction);
                        add_command.Parameters.AddWithValue("@itemID", itemID);
                        add_command.Parameters.AddWithValue("@quant", quant);
                        add_command.Parameters.AddWithValue("@TransactionID", TransactionID);

                        // Execute the command
                        add_command.ExecuteNonQuery();

                    }
                    transaction.Commit();
                }
            }
        }

        public String get_name_from_itemID(int itemID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand get_name_from_itemID = new SQLiteCommand("SELECT ITEM_NAME FROM ITEMS WHERE ITEM_ID =@itemID", connection))
                {
                    get_name_from_itemID.Parameters.AddWithValue("@itemID", itemID);
                    using (SQLiteDataReader reader = get_name_from_itemID.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["ITEM_NAME"].ToString();
                        }
                    }
                }
            }
            return "ERROR";
        }

        public float get_price_from_itemID(int itemID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand get_name_from_itemID = new SQLiteCommand("SELECT PRICE FROM ITEMS WHERE ITEM_ID =@itemID", connection))
                {
                    get_name_from_itemID.Parameters.AddWithValue("@itemID", itemID);
                    using (SQLiteDataReader reader = get_name_from_itemID.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToSingle(reader["PRICE"]);
                        }
                    }
                }
            }
            return 0.0f;
        }

    }
}
