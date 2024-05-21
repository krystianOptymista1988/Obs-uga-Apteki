using Obsługa_Apteki;
using Obsługa_Apteki.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Obsługa_Apteki.Entities.AptekaDbContext;

public class SqlDatabaseService
{
    private static SqlDatabaseService instance = null;
    private static readonly object padlock = new object();
    private SqlConnection connection;
    private AptekaDbContext context;

    private SqlDatabaseService() { }

    public static SqlDatabaseService Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new SqlDatabaseService();
                }
                return instance;
            }
        }
    }

    public void Initialize(string server, string database, string user, string password)
    {
        connection = new SqlConnection();
        
    }

    public void OpenConnection()
    {
        if (connection == null)
        {
            throw new InvalidOperationException("DatabaseService is not initialized.");
        }

        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
    }

    public void CloseConnection()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public DataTable ExecuteQuery(string query)
    {
        if (connection == null || connection.State != ConnectionState.Open)
        {
            throw new InvalidOperationException("Connection is not open.");
        }

        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

        try
        {
            dataAdapter.Fill(dataTable);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd pobierania danych: {ex.Message}");
        }

        return dataTable;
    }

    



}
