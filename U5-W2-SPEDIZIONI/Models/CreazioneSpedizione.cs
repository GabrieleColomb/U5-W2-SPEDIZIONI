using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U5_W2_SPEDIZIONI.Models
{
    public class CreazioneSpedizione
    {
        public Spedizione Spedizione { get; set; }
        public List<ClientePrivato> ClientiPrivati { get; set; }
        public List<ClienteAzienda> ClientiAzienda { get; set; }
    }
}