using System.Collections;
using System.Collections.Generic;
using Npgsql;
using UnityEngine;

public class DataBase : MonoBehaviour
{

    // Información de conexión a la base de datos
    private string host = "dumbo.db.elephantsql.com";
    private string dbName = "BBDD_Quimikanimals";
    private string userName = "yanick.garcia.7e6@itb.cat";
    private string password = "5H_vo_Eppi7rQ3f2BxLlYHFVKbrw24Yia";
    private NpgsqlConnection connection;

    void Start()
    {
        // Construir la cadena de conexión
        string connectionString = $"Host={host};Username={userName};Password={password};Database={dbName}";

        // Intentar establecer la conexión
        try
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Debug.Log("Conexión establecida con éxito a la base de datos.");

            // Ahora puedes ejecutar consultas SQL u otras operaciones en la base de datos aquí

            // No olvides cerrar la conexión cuando hayas terminado de usarla
            connection.Close();
        }
        catch (NpgsqlException ex)
        {
            Debug.LogError($"Error al conectar a la base de datos: {ex.Message}");
        }
    }
}
