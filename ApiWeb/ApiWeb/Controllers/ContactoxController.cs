using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Data;
using ApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoxController : ControllerBase
    {
        private readonly ContactoContexto _cont;

        public ContactoxController(ContactoContexto conte)
        {
            _cont = conte;
        }


        //Esta es una peticion tipo GET: api/contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactos>>> GetInfos()
        {
            return await _cont.ContactosItems.ToListAsync();
        }


        //Peticion de tipo GET: para un solo registro, ejemplo api/contectox/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactos>> GetInfo(int id)
        {
            var infoItem = await _cont.ContactosItems.FindAsync(id);
            if (infoItem == null)
            {
                return NotFound();
            }

            return infoItem;

        }


        //Peticion de tipo POST: api/contactos
        [HttpPost]
        public async Task<ActionResult<Contactos>> Postinfo(Contactos item)
        {
            _cont.ContactosItems.Add(item);
            await _cont.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInfo), new { id = item.Id }, item);
        }


        //Peticion de tipo PUT: api/contactos/2
        [HttpPut("{id}")]
        public async Task<IActionResult> putInfo(int id, Contactos item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _cont.Entry(item).State = EntityState.Modified;
            await _cont.SaveChangesAsync();

            return NoContent();

        }


        //Peticion de tipo DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> delInfo(int id)
        {
            var infoItem = await _cont.ContactosItems.FindAsync(id);

            if (infoItem == null)
            {
                return NotFound();
            }
            _cont.ContactosItems.Remove(infoItem);
            await _cont.SaveChangesAsync();

            return NoContent();

        }
    }
}