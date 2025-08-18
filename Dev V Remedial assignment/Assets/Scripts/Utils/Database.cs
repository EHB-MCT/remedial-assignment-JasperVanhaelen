using System.IO;
using SQLite;
using UnityEngine;

public static class Database
{
    private static string dbFileName = "EconomyDB.db";
    private static string dbPath;
    private static SQLiteConnection connection;

    /// Returns the SQLite database connection.
    /// Creates the database file and tables if they don’t exist yet.
    public static SQLiteConnection GetConnection()
    {
        if (connection == null)
        {
            // Determine path to store DB
            dbPath = Path.Combine(Application.persistentDataPath, dbFileName);
    
            // Open or create the database
            connection = new SQLiteConnection(dbPath);
    
            // Create tables if they do not exist
            connection.CreateTable<PlayerMoneyData>();
            connection.CreateTable<GemData>();
            connection.CreateTable<TransactionData>();
    
            Debug.Log($"[Database] Database initialized at: {dbPath}");
        }
        return connection;
    }

}
