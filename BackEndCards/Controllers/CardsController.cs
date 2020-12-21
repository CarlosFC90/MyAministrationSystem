using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CreditCardsDBContext db = new Models.CreditCardsDBContext())
            {
                var list = (from d in db.Cards
                            select d).ToList();

                return Ok(list);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.CardsRequest model)
        {
            using (Models.CreditCardsDBContext db = new Models.CreditCardsDBContext())
            {
                Models.Card oCards = new Models.Card();
                oCards.Titular = model.Titular;
                oCards.NumeroTarjeta = model.NumeroTarjeta;
                oCards.FechaExpiracion = model.FechaExpiracion;
                oCards.Cvv = model.CVV;

                db.Cards.Add(oCards);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.CardsEditRequest model)
        {
            using (Models.CreditCardsDBContext db = new Models.CreditCardsDBContext())
            {
                Models.Card oCards = db.Cards.Find(model.Id);
                oCards.Titular = model.Titular;
                oCards.NumeroTarjeta = model.NumeroTarjeta;
                oCards.FechaExpiracion = model.FechaExpiracion;
                oCards.Cvv = model.CVV;

                db.Entry(oCards).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }
        
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.CardsEditRequest model)
        {
            using (Models.CreditCardsDBContext db = new Models.CreditCardsDBContext())
            {
                Models.Card oCards = db.Cards.Find(model.Id);

                db.Remove(oCards);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
