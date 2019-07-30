using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLITE : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Smalert";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val STRING )";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

    }

    // Update is called once per frame
    public void Guardar()
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Smalert";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Insert values in table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
        cmnd.ExecuteNonQuery();
    }

    public void Leer()
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Smalert";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("val: " + reader[1].ToString());
        }
    }

}
