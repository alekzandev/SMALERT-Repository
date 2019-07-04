using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.SceneManagement;

public class BDLectura : MonoBehaviour
{
    public static BDLectura instancia;

    public void Awake()
    {
        instancia = this;
    }

    // Use this for initialization
    public void Start()
    {

        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "Ayudame";
        Debug.Log(connection);
        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val STRING )";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        int contador = 0;
        while (reader.Read())
        {
            contador = contador + 1;
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("val: " + reader[1].ToString());
        }

        if(contador == 1)
        {
            SceneManager.LoadScene("Geolocalizacion");
        }

        // Close connection
        dbcon.Close();

    }

    // Update is called once per frame
    void Update()
    {

    }

}
