using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Data
{
    public class ContactoContexto : DbContext
    {
        public ContactoContexto(DbContextOptions<ContactoContexto> options) : base(options)
        {
        }

        //Creacion del DbSet
        public DbSet<Contactos> ContactosItems { get; set; }
        //El modelo contacto esta mapeado en ContactosItems
    }
}
