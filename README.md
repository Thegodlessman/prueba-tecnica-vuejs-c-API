# Prueba Técnica Full Stack Vue.js & .NET

Este proyecto es la resolución de una prueba técnica Full Stack, dividida en dos partes: un frontend desarrollado con Vue.js y un backend API desarrollado con .NET. Ambas partes se encuentran en este mismo repositorio para facilitar la revisión y ejecución.

## Parte 1: Frontend (Vue.js)

**Ubicación:** `./frontend`

**Objetivo:** Crear una aplicación sencilla en Vue.js que consume una API externa y muestra datos en una tabla interactiva, además de tener un estilizado básico.

**Características implementadas:**

* Consumo de la API REST `https://jsonplaceholder.typicode.com/users` para obtener datos de usuarios.
* Visualización de la lista de usuarios en una tabla con columnas: Nombre, Email, Teléfono.
* Barra de búsqueda funcional para filtrar usuarios por nombre o email en tiempo real.
* Botón "Ver detalles" en cada fila para mostrar la información completa del usuario en un modal.
* Estilizado básico de la interfaz (tabla, búsqueda, modal) utilizando **Bootstrap 5**.

**Tecnologías utilizadas (Frontend):**

* Vue.js 3
* Vue CLI (para la estructura del proyecto y build)
* Axios (para peticiones HTTP a la API)
* Bootstrap 5 (vía CDN para estilizado)
* HTML5, CSS3, JavaScript

### Configuración y Ejecución del Frontend

Asegúrate de tener Node.js (v12 o superior recomendado) y npm (o yarn) instalados.

1.  Clona este repositorio a tu máquina local.
2.  Abre tu terminal y navega a la carpeta del frontend:
    ```bash
    cd frontend
    ```
3.  Instala las dependencias del frontend:
    ```bash
    npm install
    # O si usas yarn:
    # yarn install
    ```
4.  Inicia el servidor de desarrollo:
    ```bash
    npm run serve
    # O si usas yarn:
    # yarn serve
    ```
    El frontend estará disponible específicamente en `http://localhost:8765/`. El frontend actualmente consume la API pública de `jsonplaceholder.typicode.com` para la lista de usuarios.

![Demostración de la búsqueda de usuarios](docs/images/Frontend-clip.mkv)

## Parte 2: Backend (API .NET)

**Ubicación:** `./backend`

**Objetivo:** Desarrollar una API REST en .NET 6+ que gestione una entidad "Productos" con funcionalidad CRUD, utilizando una base de datos en memoria.

**Características implementadas:**

* API RESTful desarrollada con **ASP.NET Core Web API (.NET 6+)**.
* Gestión de la entidad "Productos" con los campos: Id (int, autoincremental), Nombre (string, requerido), Precio (decimal, requerido), Stock (int, requerido).
* Implementación completa de los endpoints **CRUD** para Productos:
    * `GET /api/Productos` → Obtener lista de productos.
    * `GET /api/Productos/{id}` → Obtener un producto por su ID.
    * `POST /api/Productos` → Crear un nuevo producto.
    * `PUT /api/Productos/{id}` → Actualizar un producto.
    * `DELETE /api/Productos/{id}` → Eliminar un producto.
* Uso de **Base de datos en memoria** gestionada por **Entity Framework Core**.
* Configuración de **CORS** para permitir peticiones desde el frontend (aunque la integración con el frontend no es parte de los requisitos base de esta API, está configurada para ser consumida).
* **Documentación de los endpoints con Swagger/OpenAPI**.

**Extras Implementados (Parte 2):**

* Agregado un **test unitario** para el endpoint `GET /api/Productos/{id}` para verificar su correcto funcionamiento en diferentes escenarios.

**Tecnologías utilizadas (Backend):**

* .NET 6+
* ASP.NET Core Web API
* Entity Framework Core (Proveedor In-Memory para pruebas)
* Swagger/Swashbuckle
* xUnit y VSTest (para pruebas unitarias)

### Configuración y Ejecución del Backend

Asegúrate de tener el SDK de .NET 6+ instalado.

1.  Clona este repositorio a tu máquina local.
2.  Abre tu terminal y navega a la carpeta del backend:
    ```bash
    cd backend
    ```
3.  Restaura las dependencias de .NET:
    ```bash
    dotnet restore
    ```
4.  Inicia la API:
    ```bash
    dotnet run
    ```
    La API se ejecutará específicamente en `https://localhost:5240/` (y `http://localhost:5240/`). La base de datos en memoria se inicializará con algunos datos de ejemplo al iniciar.
5.  Accede a la documentación de Swagger UI en la ruta `/swagger` (ej: `https://localhost:5240/swagger`) para explorar y probar los endpoints de Productos.

### Ejecución de Pruebas Unitarias del Backend

Para ejecutar las pruebas unitarias del backend:

1.  Abre tu terminal y navega a la carpeta del proyecto de pruebas:
    ```bash
    cd tests
    ```
    (Asegúrate de estar en la carpeta correcta donde creaste el proyecto de pruebas, por ejemplo, `./tests` en la raíz del repositorio).
2.  Ejecuta el comando de prueba:
    ```bash
    dotnet test
    ```
    Esto construirá y ejecutará las pruebas unitarias, mostrando los resultados en la consola.

---

**Autor:** Luis Chang
