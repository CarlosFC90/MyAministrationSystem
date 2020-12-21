using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCards.Models.Request
{
    public class CardsEditRequest
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string CVV { get; set; }
    }
}
