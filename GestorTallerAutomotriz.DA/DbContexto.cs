using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorTallerAutomotriz.Model;

namespace GestorTallerAutomotriz.DA
{
  public class DbContexto : DbContext
    {

        public DbContexto(DbContextOptions<DbContexto> opciones) : base(opciones)
        {


        }
        public DbSet<Ordenes> Ordenes { get; set; }
    }
}
