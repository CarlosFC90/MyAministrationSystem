using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndCards.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string Cvv { get; set; }
    }
}
