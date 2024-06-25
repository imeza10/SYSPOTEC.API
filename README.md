# SYSPOTEC S.A.S - Prueba Técnica API

Bienvenidos a la prueba técnica de SYSPOTEC S.A.S.

Este proyecto fue desarrollado en C# .NET Core 8 y sigue una arquitectura limpia (Clean Architecture). Se implementaron principios SOLID y el patrón CQRS para separar las operaciones de lectura y escritura usando comandos (commands) y consultas (queries) junto con un mediador (MediatR) y notificaciones (INotifications). También se implementó JWT para la generación y validación de tokens.

## Descripción del Proyecto

El propósito de esta API es proporcionar una capa de backend para la gestión de clientes y usuarios administradores de SYSPOTEC S.A.S. 

### Características

- **Arquitectura Limpia**: Se sigue el principio de Clean Architecture para una mejor separación de responsabilidades y mantenibilidad del código.
- **Principios SOLID**: Implementación de principios SOLID para escribir un código más flexible y mantenible.
- **CQRS**: Uso del patrón CQRS para separar las operaciones de lectura y escritura.
- **Mediador**: Uso de MediatR para la mediación de comandos y consultas.
- **JWT**: Implementación de JWT para la generación y validación de tokens de seguridad.

## Instalación y Configuración

Para ejecutar esta API en tu máquina local, sigue los siguientes pasos:

### Prerrequisitos

- .NET Core SDK 8
- SQL Server

### Instalación

1. **Clona el repositorio**:

    ```bash
    git clone https://github.com/imeza10/SYSPOTEC.API.git
    cd SYSPOTEC.API
    ```

2. **Configura la base de datos**:

    Crea una instancia de la base de datos llamada `syspotecsasbd` y asegúrate de configurar la cadena de conexión en `appsettings.json`:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=DESKTOP-93H006O\\LOCALHOST;Database=syspotecsasbd;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
    }
    ```

3. **Realiza la migración de la base de datos**:

    Navega al proyecto `Persistence.Database` y ejecuta los siguientes comandos para aplicar las migraciones:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

    Estos comandos crearán las tablas necesarias en la base de datos.

4. **Ejecuta la API**:

    En la raíz del proyecto, ejecuta el siguiente comando:

    ```bash
    dotnet run
    ```

    La API debería estar corriendo en `https://localhost:5001` o `http://localhost:5000`.

## Uso

1. **Autenticación**:
   - Utiliza el endpoint de autenticación para obtener un token JWT.
   - Incluye el token en el encabezado de autorización para acceder a los endpoints protegidos.

2. **Endpoints Principales**:
   - /api/Users/Login
   - /api/Users/ValidateToken
   - /api/Users/GetAllUsers
   - /api/Users/GetUsersById
   - /api/Users/GetUsersByDocument
   - /api/Users/CreateUser
   - /api/Users/UpdateUsers
  
   - /api/Roles/GetAllRoles
   - /api/Roles/GetRolByID


## Contacto

Para más información, puedes contactar a:

- Ismael Meza - [imeza010@gmail.com](mailto:imeza010@gmail.com)

¡Gracias por visitar este proyecto!

