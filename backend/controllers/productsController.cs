using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data; 
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor que recibe el ApplicationDbContext por inyección de dependencias
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet] // Define que este método responde a peticiones GET a la ruta base (/api/Productos)
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            // Obtiene todos los productos de la base de datos de forma asíncrona
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")] // Define que este método responde a peticiones GET a /api/Productos/{id}
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            // Busca un producto por su Id de forma asíncrona
            var producto = await _context.Productos.FindAsync(id);

            // Si no se encuentra el producto, devuelve un resultado 404 Not Found
            if (producto == null)
            {
                return NotFound();
            }

            // Si se encuentra, devuelve el producto
            return producto;
        }

        // POST: api/Productos
        [HttpPost] // Define que este método responde a peticiones POST a la ruta base (/api/Productos)
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            // Añade el nuevo producto al DbSet
            _context.Productos.Add(producto);
            // Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // Devuelve un resultado 201 Created, con el producto creado
            // y un encabezado Location que indica la URL para obtener el nuevo recurso (GET /api/Productos/id)
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // PUT: api/Productos/:id
        [HttpPut("{id}")] // Define que este método responde a peticiones PUT a /api/Productos/{id}
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            // Verifica si el Id en la URL coincide con el Id en el cuerpo de la petición
            if (id != producto.Id)
            {
                // Si no coinciden, devuelve un resultado 400 Bad Request
                return BadRequest();
            }

            // Indica a EF Core que la entidad producto ha sido modificada
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                // Intenta guardar los cambios
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductoExists(id))
                {
                    // Si no existe, devuelve 404 Not Found
                    return NotFound();
                }
                else
                {
                    // Si el error no es por que no exista, lanza la excepción
                    throw;
                }
            }

            // Si los cambios se guardaron correctamente, devuelve 204 No Content (respuesta típica para PUT exitoso)
            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")] // Define que este método responde a peticiones DELETE a /api/Productos/{id}
        public async Task<IActionResult> DeleteProducto(int id)
        {
            // Busca el producto por Id
            var producto = await _context.Productos.FindAsync(id);

            // Si no se encuentra, devuelve 404 Not Found
            if (producto == null)
            {
                return NotFound();
            }

            // Remueve el producto del DbSet
            _context.Productos.Remove(producto);
            // Guarda los cambios
            await _context.SaveChangesAsync();

            // Devuelve 204 No Content (respuesta típica para DELETE exitoso)
            return NoContent();
        }

        // Método auxiliar privado para verificar si un producto existe por Id
        private async Task<bool> ProductoExists(int id)
        {
            return await _context.Productos.AnyAsync(e => e.Id == id);
        }
    }
}