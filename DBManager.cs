using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6SaraUras
{
    class DBManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                "Initial Catalog = AgentePolizia;" +
                "integrated Security= true;";

        internal static void VisualizzaAgenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // !!!!
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "select * from dbo.Agente";



                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Agenti Polizia");
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var codice = reader["CodiceFiscale"];
                    var geo = reader["AreaGeo"];
                    var anno = reader["AnnoInizioAttivita"];
                    Console.Write($"\n Nome {nome}");
                    Console.Write($"\n Cognome: {cognome} ");
                    Console.Write($"\n Codice fiscale: {codice}");
                    Console.Write($"\n Area Geo: {geo}");
                    Console.Write($"\n Anno Inizio Attivita: {anno}");
                }




                connection.Close(); // !!!
            }
        }

        internal static void MostraAgentiAreaGeo(string geo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;



                command.CommandText = "select * from dbo.Agente  where AreaGeo = @AreaGeo";

                command.Parameters.AddWithValue("@AreaGeo", geo);

                SqlDataReader reader = command.ExecuteReader();

               
                while (reader.Read())
                {
                   

                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var CodiceFiscale = reader["CodiceFiscale"];                  
                    var anni = reader["AnnoInizioAttivita"];

                    Console.WriteLine($"Agenti di Area geografica {geo}");
                    Console.WriteLine($"\n Nome {nome}");
                    Console.WriteLine($"\n Cognome: {cognome}");
                    Console.WriteLine($"\n CodiceFiscale: {CodiceFiscale}");
                    Console.WriteLine($"\n Anni Servizio Attivita: {anni}");




                }



                connection.Close(); // !!!
            }
        }
        internal static bool Check(string codice)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Agente";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string codice2 = (string)reader["CodiceFiscale"];
                    if (codice2 == codice)
                        return true;
                }
                connection.Close();
            }
            return false;
        }


        // mostra gli agenti con anni di servizio maggiori o uguali rispetto  all’input 
        internal static void MostraAgentiAnniServizio(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;



                command.CommandText = "select * from dbo.Agente where AnniInizioAttivita => @AnnoInizioAttivita";

                command.Parameters.AddWithValue("@AnnoInizioAttivita", anni);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Agenti anni servizio {anni}");
                while (reader.Read())
                {
                    Console.WriteLine("Libro Audio");
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var CodiceFiscale = reader["CodiceFiscale"];
                   
                    Console.WriteLine($"\n Nome {nome}");
                    Console.WriteLine($"\n Cognome: {cognome}");
                    Console.WriteLine($"\n CodiceFiscale: {CodiceFiscale}");
                    Console.WriteLine($"\n Anni Servizio Attivita: {anni}");




                }



                connection.Close(); // !!!
            }
        
    }
        // Inserimento agente con controllo per evitare duplicati il controllo viene effetuato da codice fiscale
        internal static void InserisciAgente(string codice, string nome, string cognome, int anni, string areageo)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agente values (@Nome, @Cognome, @CodiceFiscale, @AreaGeo, @AnnoInizioAttivita)";
                if (!Check(codice))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cognome", cognome);
                    command.Parameters.AddWithValue("@CodiceFiscale", codice);
                    command.Parameters.AddWithValue("@AreaGeo", areageo);
                    command.Parameters.AddWithValue("@AnnoInizioAttivita", anni);


                    command.ExecuteNonQuery();
                }
                if (Check(codice))
                {

                    Console.WriteLine("L Agente e gia presente nel database");
                }
                   
               
                connection.Close();
            }
        }
    }
}
