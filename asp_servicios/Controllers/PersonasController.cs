using Microsoft.AspNetCore.Mvc;
using asp_servicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {

        [HttpGet(Name = "GetPersonas")]
        public IEnumerable<Personas> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "Server = CARZAXO\\DEV; Database = db_PagosPersonas; Integrated Security = True; TrustServerCertificate = True";
            // Otra direccion: "server=localhost;database=db_PagosPersonas;uid=sa;pwd=Clas3sPrO2024_!; TrustServerCertificate = true";
            // "server=CARZAXO\\DEV;database=db_PagosPersonas;Integrated\r\nSecurity=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Personas()
            {
                Nombre = "Pepito Perez",
                Cedula = "1019333355",
                Pago = 3500.00M,
                Fecha = DateTime.Now,
                Departamento = "Antioquia",
                Atendido = true,
            });
            conexion.GuardarCambios();

            return conexion.Listar<Personas>();

        }
    }
}
