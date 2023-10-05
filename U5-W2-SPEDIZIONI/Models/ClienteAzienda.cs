using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;

namespace U5_W2_SPEDIZIONI.Models
{
    public class ClienteAzienda
    {
        public int IdClienteAzienda { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string NomeAzienda { get; set; }

        [Required(ErrorMessage = "Il campo Partita IVA è obbligatorio.")]
        public string PartitaIVA { get; set; }

        [Required(ErrorMessage = "Il campo Indirizzo Sede è obbligatorio.")]
        public string IndirizzoSede { get; set; }

        [Required(ErrorMessage = "Il campo Città Sede è obbligatorio.")]
        public string CittaSede { get; set; }

        public static List<ClienteAzienda> GetAziende()
        {
            List<ClienteAzienda> ListaAziende = new List<ClienteAzienda>();
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from ClienteAzienda", sql);
            SqlDataReader sqlDataReader;

            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ClienteAzienda ClienteAzienda = new ClienteAzienda();
                    ClienteAzienda.IdClienteAzienda = Convert.ToInt32(sqlDataReader["IdClienteAzienda"]);
                    ClienteAzienda.NomeAzienda = sqlDataReader["NomeAzienda"].ToString();
                    ClienteAzienda.PartitaIVA = sqlDataReader["PartitaIVA"].ToString();
                    ClienteAzienda.IndirizzoSede = sqlDataReader["IndirizzoSede"].ToString();
                    ClienteAzienda.CittaSede = sqlDataReader["CittàSede"].ToString();
                    ListaAziende.Add(ClienteAzienda);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaAziende;
        }

        public static ClienteAzienda CreaAzienda(ClienteAzienda clienteAzienda)
        {
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("INSERT INTO ClienteAzienda (NomeAzienda, PartitaIVA, IndirizzoSede, CittàSede) VALUES (@NomeAzienda, @PartitaIVA, @IndirizzoSede, @CittàSede)", sql);

            try
            {
                sql.Open();

                cmd.Parameters.AddWithValue("@NomeAzienda", clienteAzienda.NomeAzienda);
                cmd.Parameters.AddWithValue("@PartitaIVA", clienteAzienda.PartitaIVA);
                cmd.Parameters.AddWithValue("@IndirizzoSede", clienteAzienda.IndirizzoSede);
                cmd.Parameters.AddWithValue("@CittàSede", clienteAzienda.CittaSede);

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

            return clienteAzienda;
        }
    }
}