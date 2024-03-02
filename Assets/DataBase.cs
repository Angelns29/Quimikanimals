using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class Database : MonoBehaviour
{
    [SerializeField] private SOInfo soInfo;

    void Start()
    {
        //Limpiamos Las listas para los nuevos datos
        soInfo.infoList.Clear();
        soInfo.elementos.Clear();
        soInfo.habitats.Clear();


        //Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();

        dbCommandReadValues.CommandText = "SELECT * FROM QUIMIKANIMALS";
        using (IDataReader reader = dbCommandReadValues.ExecuteReader())
        {
            while (reader.Read())
            {
                //Quimikanimal
                soInfo.infoList.Add(new SOInfo.QuimikInfo(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetFloat(5), reader.GetInt32(6), reader.GetString(7)));
            }
            reader.Close();
        }
        //IDataReader dataReader = dbCommandReadValues.ExecuteReader();
        dbCommandReadValues.CommandText = "SELECT * FROM HABITAT";
        using (IDataReader reader = dbCommandReadValues.ExecuteReader())
        {
            while (reader.Read())
            {
                soInfo.habitats.Add(new SOInfo.Habitats(reader.GetInt32(0), reader.GetString(1)));
            }
            reader.Close();
        }
        dbCommandReadValues.CommandText = "SELECT * FROM ELEMENTO";
        using (IDataReader reader = dbCommandReadValues.ExecuteReader())
        {
            while (reader.Read())
            {
                soInfo.elementos.Add(new SOInfo.Elementos(reader.GetInt32(0), reader.GetString(1)));
            }
            reader.Close();
        }


        
        Debug.Log("Se conecto y se hizo");
        dbConnection.Close();
    }

    private IDbConnection CreateAndOpenDatabase()
    {
        string dbUri = $"URI=file:{Application.persistentDataPath}/MyDatabase.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        // Creates a table for the quimikanimals in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS ELEMENTO  (\r\nnum_elemento INT," +
            "\r\ntipo VARCHAR NOT NULL," +
            "\r\nPRIMARY KEY (num_elemento)" +
            "\r\n);" +
            "\r\n" +
            "\r\nCREATE TABLE IF NOT EXISTS HABITAT (" +
            "\r\nid_habitat INT," +
            "\r\nnombreHabitat VARCHAR NOT NULL," +
            "\r\nPRIMARY KEY (id_habitat)" +
            "\r\n);" +
            "\r\nCREATE TABLE IF NOT EXISTS QUIMIKANIMALS (" +
            "\r\nnum INT," +
            "\r\nelemento1 INT," +
            "\r\nelemento2 INT," +
            "\r\nnombre VARCHAR NOT NULL," +
            "\r\naltura FLOAT(2)," +
            "\r\npeso FLOAT(2)," +
            "\r\nhabitat INT NOT NULL," +
            "\r\ndescripcion VARCHAR NOT NULL," +
            "\r\nPRIMARY KEY (num,nombre)," +
            "\r\nFOREIGN KEY (elemento1) REFERENCES ELEMENTO(num_elemento)," +
            "\r\nFOREIGN KEY (elemento2) REFERENCES ELEMENTO(num_elemento)" +
            "\r\nFOREIGN KEY (habitat) REFERENCES HABITAT(id_habitat)" +
            "\r\n);";
        dbCommandCreateTable.ExecuteReader();

        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT OR IGNORE INTO ELEMENTO VALUES (0,'none');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (8,'Oxigeno');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (9,'Fluor');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (15,'Fosforo');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (19,'Potasio');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (20,'Calcio');" +
            "\r\nINSERT OR IGNORE INTO ELEMENTO VALUES (78,'Platino');" +
            "\r\n" +    
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (1,'Huesudo Valley');" +
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (2,'Geox');" +
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (3,'Rocas Sulfúricas');" +
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (4,'Barceloneta');" +
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (5,'Palm Beach');" +
            "\r\nINSERT OR IGNORE INTO HABITAT VALUES (6,'PanTano');" +
            "\r\n" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (1,78,0,'Patoto',0.05,1.3,6,'Unas nobles criaturas que a pesar de siempre actuar con grandeza suelen sacan a relucir una gran torpeza. Los patoto son de lo más valiosos, tanto en investigación como en utilidad, pues el elemento que más abunda en ellos tiene una serie de propiedades muy destacadas y es de los principales catalizadores. Esto por desgracia ha llevado a que el secuestro de los mismos por los bandidos de Bad’Ahlona sea común, pues se venden bien en cualquier mercado.');" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (2,19,0,'Kotano',0.80,3,5,'Uno de los quimikanimals más curiosos, aunque parezca que las pieles de plátano se las ponen ellos en realidad son parte de su cuerpo, nunca dejan de crecer y los Kotanos, que se han desarrollado como seres vanidosos y presumidos, siempre buscan nuevas formas de lucirlas. También usan accesorios, pero estos suelen robárselos a las personas, pues aunque no parezcan muy espabilados son tremendamente astutos.');" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (3,9,0,'Fosh',0.13,13,4,'Antes de que el verter residuos tóxicos al agua fuese habitual, existían unos pececillos de apariencia divertida que no se asustaban ante las personas. Ahora que las negras aguas de la Barceloneta impiden ver que se oculta bajo las mismas, nadie sabe qué les ocurrió. Estos quimikanimals solían aparecer ante la gente que les sonreía en esas playas y quién sabe, si te atreves a hacerlo, tal vez te llevas una sorpresa…');" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (4,16,0,'Alejandra',0.33,3,3,'Las simpáticas Alejandras son criaturas amigables que para su desgracia han resultado ser tremendamente peligrosas. Su piel secreta una sustancia tan tóxica que el mero contacto con ella puede llegar a ser mortal, haciendo que ningún ser se atreva a acercárseles. Estudios recientes han descubierto que la sustancia que secretan tiene incontables efectos beneficiosos no activos y que si se aíslan podrían ser de gran ayuda en distintas áreas. ');" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (5,8,0,'Osox',0.64,8.3,2,'Reside en entornos llenos de praderas donde el aire puro es esencial para su existencia. Su pelaje es denso y esponjoso con tonalidades blancas, azules y verdes, que se asemejan a las nubes y las plantas que se pueden encontrar en su hábitat. Es conocido por su naturaleza amigable y protectora, su presencia suele indicar la calidad del aire ya que esta especie prospera en entornos limpios y saludables.');" +
            "\r\nINSERT OR IGNORE INTO QUIMIKANIMALS VALUES (6,20,0,'Cameyoyo',2.13,420,1,'Uno de los pocos habitantes de las áridas y crueles tierras de Huesudo Valley. Siglos de evolución dotaron a estas criaturas de una estructura física perfecta para sobrevivir en un entorno tan hostil, no dependen de agua ni de alimento alguno, son seres que vagan eternamente por un desierto en el que nadie puede vivir. Esto ha llevado a pensar que ni siquiera están verdaderamente vivos. Pero nadie se atreve a estudiarlos, pues lejos de su existencia no se sabe de ellos, ni si son peligrosos ni qué riesgos puede llevar un acercamiento a estos, el temor a lo desconocido echa atrás a quienes buscan respuestas.');";
        Debug.Log("Ha sido creado");
        dbCommandInsertValue.ExecuteNonQuery();

        string path = $"jar:file://{Application.dataPath}!/assets/Mydatabase.sqlite";
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(path);
        unityWebRequest.SendWebRequest();
        while (!unityWebRequest.isDone) { }
        if (unityWebRequest.result == UnityWebRequest.Result.Success)
        {
            byte[] data = unityWebRequest.downloadHandler.data;
            File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "MyDatabase.sqlite"), data);
        }
        else Debug.LogError("Failed download db: " + unityWebRequest.error);

        return dbConnection;
    }
}
