using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProyectoFinal_MVC__FV__ME.Data
{
    public class ProyectoFinal_MVC__FV__MEContext : DbContext
    {
        public ProyectoFinal_MVC__FV__MEContext(DbContextOptions<ProyectoFinal_MVC__FV__MEContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFinal_MVC__FV__ME.Models.Registro_F> Registro_F { get; set; } = default!;
    }
}
