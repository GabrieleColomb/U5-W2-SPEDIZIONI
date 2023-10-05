using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U5_W2_SPEDIZIONI.Models
{
    public class Spedizione
    {
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Il campo Destinatario è obbligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Il campo Indirizzo Destinazione è obbligatorio.")]
        public string IndirizzoDestinazione { get; set; }

        [Required(ErrorMessage = "Il campo Città Destinazione è obbligatorio.")]
        public string CittaDestinazione { get; set; }

        [Required(ErrorMessage = "Il campo Peso (in kg) è obbligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Il campo Peso deve essere maggiore di zero.")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "Il campo Costo è obbligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Il campo Costo deve essere maggiore di zero.")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Il campo Data di Spedizione è obbligatorio.")]
        [DataType(DataType.Date)]
        public DateTime DataSpedizione { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataConsegnaPrevista { get; set; }

        public int? ClientePrivatoId { get; set; }

        public int? ClienteAziendaId { get; set; }

        public string MittenteTipo { get; set; }

        public ClientePrivato ClientePrivato { get; set; }
        public ClienteAzienda ClienteAzienda { get; set; }

        public static Spedizione FindSpedizione(string numeroSpedizione)
        {
            Spedizione SpedizioneDaRestituire = new Spedizione();

            string Connection = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection(Connection);

            SqlCommand cmd = new SqlCommand("select * from Spedizione WHERE IdSpedizione = @id", sql);
            cmd.Parameters.AddWithValue("@id", numeroSpedizione);

            SqlDataReader sqlDataReader;
            try
            {
                sql.Open();

                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    SpedizioneDaRestituire.IdSpedizione = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                    SpedizioneDaRestituire.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                    SpedizioneDaRestituire.Peso = Convert.ToDecimal(sqlDataReader["PesoKg"]);
                    SpedizioneDaRestituire.CittaDestinazione = sqlDataReader["CittàDestinazione"].ToString();
                    SpedizioneDaRestituire.IndirizzoDestinazione = sqlDataReader["IndirizzoDestinazione"].ToString();
                    SpedizioneDaRestituire.Costo = Convert.ToDecimal(sqlDataReader["Costo"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return SpedizioneDaRestituire;
        }

    }
}