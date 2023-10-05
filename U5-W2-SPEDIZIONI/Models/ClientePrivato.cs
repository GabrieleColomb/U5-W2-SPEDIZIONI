using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_SPEDIZIONI.Models
{
    public class ClientePrivato
    {
        public int IdClientePrivato { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio.")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "Il campo Luogo di Nascita è obbligatorio.")]
        public string LuogoNascita { get; set; }

        [Required(ErrorMessage = "Il campo Residenza è obbligatorio.")]
        public string Residenza { get; set; }

        [Required(ErrorMessage = "Il campo Data di Nascita è obbligatorio.")]
        public DateTime DataNascita { get; set; }

        public static List<ClientePrivato> GetClienti()
        {
            List<ClientePrivato> ListaClienti = new List<ClientePrivato>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from ClientePrivato", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ClientePrivato ClientePrivato = new ClientePrivato();
                    ClientePrivato.IdClientePrivato = Convert.ToInt32(sqlDataReader["IdClientePrivato"]);
                    ClientePrivato.Cognome = sqlDataReader["Cognome"].ToString();
                    ClientePrivato.Nome = sqlDataReader["Nome"].ToString();
                    ClientePrivato.CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                    ClientePrivato.LuogoNascita = sqlDataReader["LuogoNascita"].ToString();
                    ClientePrivato.Residenza = sqlDataReader["Residenza"].ToString();
                    ClientePrivato.DataNascita = Convert.ToDateTime(sqlDataReader["DataNascita"]);
                    ListaClienti.Add(ClientePrivato);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaClienti;
        }

        public static ClientePrivato CreaClienti(ClientePrivato clientePrivato)
        {
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("INSERT INTO ClientePrivato (Nome, Cognome, CodiceFiscale, LuogoNascita, Residenza, DataNascita) VALUES (@Nome, @Cognome, @CodiceFiscale, @LuogoNascita, @Residenza, @DataNascita)", sql);

            try
            {
                sql.Open();

                cmd.Parameters.AddWithValue("@Nome", clientePrivato.Nome);
                cmd.Parameters.AddWithValue("@Cognome", clientePrivato.Cognome);
                cmd.Parameters.AddWithValue("@CodiceFiscale", clientePrivato.CodiceFiscale);
                cmd.Parameters.AddWithValue("@LuogoNascita", clientePrivato.LuogoNascita);
                cmd.Parameters.AddWithValue("@Residenza", clientePrivato.Residenza);
                cmd.Parameters.AddWithValue("@DataNascita", clientePrivato.DataNascita);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Inserimento riuscito!");
                }
                else
                {
                    Console.WriteLine("Nessuna riga inserita.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
            finally
            {
                sql.Close(); 
            }

            return clientePrivato;
        }
    }
}