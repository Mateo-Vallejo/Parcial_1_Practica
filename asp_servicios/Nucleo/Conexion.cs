using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace asp_servicios.Nucleo
{
    public partial class Conexion : DbContext
    {
        private int tamaño = 20;
        public string? StringConnection { get; set; }
        protected override void
       OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(this.StringConnection!, p =>{ });

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected DbSet<Personas>? Personas { get; set; }
        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }
        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>()
            .Take(tamaño)
            .ToList();
        }
        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>()
            .Where(condiciones)
            .Take(tamaño)
            .ToList();
        }
        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }
        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }
        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }
        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }
        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State =
           EntityState.Detached;
        }
        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }

    }
}