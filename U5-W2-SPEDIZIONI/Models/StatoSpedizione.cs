using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U5_W2_SPEDIZIONI.Models
{
    public class StatoSpedizione
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo spedizione è obbligatorio.")]
        public int SpedizioneId { get; set; }

        [Required(ErrorMessage = "Il campo Stato è obbligatorio.")]
        public string Stato { get; set; }

        [Required(ErrorMessage = "Il campo Luogo è obbligatorio.")]
        public string Luogo { get; set; }

        [Required(ErrorMessage = "Il campo Data e Ora di Aggiornamento è obbligatorio.")]
        [DataType(DataType.DateTime)]
        public DateTime DataOraAggiornamento { get; set; }

    }
}