using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SakilaWebServer.Models;

namespace SakilaWebServer.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController:Controller
    {
        private SakilaDbContext dataBaseContext;

        public ActorsController(SakilaDbContext dbContext){
            dataBaseContext = dbContext;
        }

        [HttpGet]
        public ActionResult getAllActors()
        {
            return Ok(dataBaseContext.actor.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult getActorById(int id)
        {
            var actorRegistry = dataBaseContext.actor.SingleOrDefault(a => a.Actor_ID == id);
            if(actorRegistry != null)
            {
                return Ok(actorRegistry);
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult createActorRegistry([FromBody]Actor actor)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }
            dataBaseContext.actor.Add(actor);
            dataBaseContext.SaveChanges();
            return Created("api/actors",actor);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteActorRegistry(int id)
        {
            var actorRegistry = dataBaseContext.actor.SingleOrDefault(a => a.Actor_ID == id);
            if(actorRegistry != null){
                dataBaseContext.actor.Remove(actorRegistry);
                dataBaseContext.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult updateActorRegistry(int id, [FromBody]Actor actor)
        {
            var actorRegistry = dataBaseContext.actor.SingleOrDefault(a => a.Actor_ID == id);
            if(actorRegistry != null && ModelState.IsValid)
            {
                actor.Actor_ID = actorRegistry.Actor_ID;
                dataBaseContext.Entry(actorRegistry).CurrentValues.SetValues(actor);
                dataBaseContext.SaveChanges();
                return Ok();
            }else{
                return BadRequest();
            }
        }


    }
}