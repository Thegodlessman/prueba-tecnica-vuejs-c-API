using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using backend.Data; // Asegúrate de que el namespace coincide con el de tu DbContext
using backend.Models; // Asegúrate de que el namespace coincide con el de tu modelo
using backend.Controllers; // Asegúrate de que el namespace coincide con el de tu controlador
using Microsoft.AspNetCore.Mvc; // Necesario para ActionResult, NotFoundResult, etc.
using System; // Para Exception

namespace test.Tests // Reemplaza 'TuProyectoBackend' con un nombre para tu namespace de pruebas
{
    public class ProductosControllerTests
    {
        // Método auxiliar para crear un ApplicationDbContext para pruebas con datos iniciales
        private ApplicationDbContext CreateTestContext()
        {
            // Usa un nombre de base de datos único para cada test para evitar conflictos
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Nombre único para cada base de datos en memoria
                .Options;

            var context = new ApplicationDbContext(options);

            // Añade datos de prueba
            context.Productos.AddRange(
                new Producto { Id = 1, Nombre = "Laptop Test", Precio = 1000m, Stock = 5 },
                new Producto { Id = 2, Nombre = "Monitor Test", Precio = 300m, Stock = 15 }
            );
            context.SaveChanges(); // Guarda los datos de prueba en la base de datos en memoria

            return context;
        }

        [Fact] // Atributo que marca este método como una prueba a ejecutar por xUnit
        public async Task GetProducto_ReturnsProduct_ForValidId()
        {
            // Arrange (Preparación)
            // Creamos un contexto de base de datos en memoria para este test
            var context = CreateTestContext();
            // Creamos una instancia del controlador, inyectando el contexto de prueba
            var controller = new ProductosController(context);
            var productId = 1; // Id del producto de prueba que existe

            // Act (Acción)
            // Llamamos al método del controlador que queremos probar
            var result = await controller.GetProducto(productId);

            // Assert (Verificación)
            // Verificamos que el resultado sea un ActionResult que contiene un Producto
            var actionResult = Assert.IsType<ActionResult<Producto>>(result);
            var okResult = Assert.IsType<Producto>(actionResult.Value);

            // Verificamos que el producto retornado sea el correcto
            Assert.Equal(productId, okResult.Id);
            Assert.Equal("Laptop Test", okResult.Nombre);

            // Limpia el contexto (importante en pruebas con bases de datos en memoria)
            context.Dispose();
        }

        [Fact] // Otro test
        public async Task GetProducto_ReturnsNotFound_ForInvalidId()
        {
            // Arrange (Preparación)
            var context = CreateTestContext();
            var controller = new ProductosController(context);
            var productId = 99; // Id de un producto que no existe

            // Act (Acción)
            var result = await controller.GetProducto(productId);

            // Assert (Verificación)
            // Verificamos que el resultado sea un NotFoundResult (código 404)
            Assert.IsType<NotFoundResult>(result.Result);

            // Limpia el contexto
            context.Dispose();
        }
    }
}