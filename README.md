# Observatorio Astronómico

> Sistema web para la gestión de un observatorio astronómico, desarrollado con ASP.NET Core y una API REST para administrar usuarios, equipamiento, préstamos y observaciones astronómicas.

<!-- Completar esta sección con el contexto, propósito y alcance del proyecto. -->

## 📌 Descripción

El proyecto implementa una solución web compuesta por una aplicación MVC y una API REST. La solución organiza las responsabilidades en capas de lógica de negocio, lógica de aplicación e infraestructura, y utiliza Entity Framework Core para la persistencia de datos.

**Objetivo del proyecto:** <!-- Completar -->

## ✨ Funcionalidades principales

La estructura y los casos de uso presentes en el código, el sistema contempla:

- Gestión de usuarios y acceso mediante inicio de sesión.
- Administración de equipamiento astronómico: telescopios, cámaras, monturas y oculares.
- Gestión y consulta de préstamos de equipamiento.
- Registro de devoluciones y consulta de auditoría de préstamos.
- Registro de observaciones astronómicas asociadas a préstamos y objetos celestes.
- Consulta y ranking de objetos celestes observados.
- Consulta de socios asociados a telescopios.
- Integración con un servicio de IA para evaluar información relacionada con préstamos/observaciones. <!-- Completar proveedor, propósito y requisitos de configuración. -->

## 🧰 Tecnologías utilizadas

- **Lenguaje:** C#
- **Plataforma:** .NET 10 / ASP.NET Core
- **API:** ASP.NET Core Web API
- **Interfaz web:** ASP.NET Core MVC, Razor Views
- **Persistencia:** Entity Framework Core 10
- **Base de datos:** Microsoft SQL Server (configuración local mediante SQL Server LocalDB)
- **Autenticación:** JWT en la API y sesión en la aplicación web
- **Interfaz y estilos:** Bootstrap, CSS y JavaScript
- **Gestión de dependencias:** NuGet
- **Control de versiones:** Git

## 🏗️ Arquitectura y organización

La solución sigue una organización por capas, con proyectos diferenciados para la API, la lógica de aplicación, la lógica de negocio, la infraestructura y la aplicación web.

```text
Observatorio-Astronomico/
├── ObligatorioP3-Api/
│   ├── Obligatorio.WebApi/             # Controladores y configuración de la API REST
│   ├── Obligatorio.LogicaAplicacion/   # Casos de uso, DTOs y mappers
│   ├── Obligatorio.LogicaNegocio/      # Entidades, reglas e interfaces de negocio
│   ├── Obligatorio.Infraestructura/    # Persistencia, repositorios y migraciones EF Core
│   └── Documentacion/                  # Documentación y diagrama UML
└── WebAppFront-end/                    # Aplicación web MVC que consume la API
```

### Responsabilidades por capa

- **Web API:** expone endpoints HTTP mediante controladores y coordina las solicitudes.
- **Lógica de aplicación:** implementa casos de uso, transferencia de datos mediante DTOs y mapeos.
- **Lógica de negocio:** contiene las entidades del dominio, reglas y excepciones específicas.
- **Infraestructura:** implementa el acceso a datos mediante Entity Framework Core, configuraciones de entidades, repositorios, migraciones y datos iniciales.
- **WebAppFront-end:** presenta las vistas y consume la API a través de un cliente HTTP auxiliar.

## 🗂️ Dominio funcional

Entre las entidades identificadas en el código se encuentran:

- **Usuarios:** usuario base y perfiles de administrador, coordinador y socio.
- **Equipos:** equipo base y tipos específicos como telescopio, cámara, montura y ocular.
- **Préstamos:** registro de préstamos y devoluciones de equipamiento.
- **Auditoría:** información de seguimiento de préstamos.
- **Observaciones:** registros de observaciones astronómicas.
- **Objetos celestes:** objetos consultables y utilizados en listados y rankings.

## 🔌 API REST

La API agrupa operaciones en controladores asociados a los distintos perfiles y funcionalidades. Los controladores utilizan rutas con el prefijo `api/`.

| Área | Operaciones identificadas |
|---|---|
| Administración | Alta, consulta, modificación y eliminación de equipamiento; consulta de socios por telescopio |
| Coordinación | Alta y consulta de préstamos, consulta por identificador, devolución y auditoría |
| Socios | Consulta de objetos celestes y ranking; registro de observaciones |
| Usuarios | Registro e inicio de sesión |
| IA | Evaluación relacionada con préstamos/observaciones |

**Documentación detallada de endpoints:** <!-- Completar con método HTTP, ruta, parámetros, cuerpo de solicitud, respuesta y permisos requeridos. -->

## 🔐 Autenticación y seguridad

- La API utiliza autorización basada en JWT en los controladores protegidos.
- La aplicación web guarda en sesión información de la sesión iniciada, incluido el token recibido de la API.
- La configuración local incluye parámetros de JWT y una cadena de conexión a SQL Server LocalDB.

## 🗄️ Base de datos

La persistencia se implementa con Entity Framework Core y SQL Server. El proyecto de infraestructura contiene configuraciones de entidades, repositorios, una migración inicial.

- **Nombre de la base de datos:** `ObservatorioDB` (valor configurado para LocalDB)
- **Datos de prueba / seed:** existe una clase `SeedData`; completar los datos que inicializa y cómo se ejecuta.

## ⚙️ Requisitos previos

Antes de ejecutar el sistema, verificar que estén instalados y configurados:

- [ ] .NET SDK 10.0
- [ ] Visual Studio compatible con .NET 10 o un editor con soporte para .NET
- [ ] SQL Server LocalDB o una instancia de SQL Server configurada
- [ ] Git
- [ ] Clave/API key del servicio de IA, si se desea utilizar esa funcionalidad

## . Configurar secretos

Configurar la clave JWT y, si corresponde, la clave del servicio de IA mediante un mecanismo seguro de configuración. No publicar credenciales reales en el repositorio.


### . Ejecutar la API y la aplicación web

Iniciar `Obligatorio.WebApi` y `WebAppFront-end` desde Visual Studio o mediante `dotnet run` en cada proyecto. Confirmar que la URL base configurada en el cliente HTTP de la aplicación web coincida con la URL donde se ejecuta la API.

- **URL local de la API:** <!-- Completar -->
- **URL local de la aplicación web:** <!-- Completar -->
- **Documentación interactiva (Swagger/OpenAPI), si está habilitada:** <!-- Completar -->

## 📚 Documentación adicional

En la carpeta `ObligatorioP3-Api/Documentacion/` se incluyen archivos de documentación y un diagrama UML del proyecto.

- **Documento funcional/técnico:** <!-- Completar nombre y resumen -->
- **Diagrama UML:** `UMLObligatorioP3.asta`

## 👨‍💻 Autor

**Emanuel Rodriguez**

- GitHub: [@Emanuel-Rodriguez-1996](https://github.com/Emanuel-Rodriguez-1996)
