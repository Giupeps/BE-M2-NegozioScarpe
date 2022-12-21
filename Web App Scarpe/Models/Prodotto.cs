using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App_Scarpe.Models
{
    public class Prodotto
    {
        public int IdProdotto { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string ImmagineCopertina { get; set; }
        public string ImmagineAgg1 { get; set; }
        public string ImmagineAgg2 { get; set; }
        public bool Disponibile { get; set; }
    }
}