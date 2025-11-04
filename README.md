# Talkthrough_API — Backend de mensajería y llamadas en .NET

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-En%20desarrollo-yellow)

---

## Descripción general

**TalkthroughAPI** es un proyecto backend desarrollado en **.NET 8 / ASP.NET Core Web API** con el objetivo de ofrecer una base moderna, escalable y segura para una aplicación de **mensajería y llamadas en tiempo real**.

Además de su propósito funcional, el proyecto sirve como práctica para mejorar en conceptos como **Clean Code**, **arquitectura backend** y **organización de proyectos**.

---

## Estado del proyecto

* Autenticación y registro de usuarios
* Mensajería en tiempo real *(en diseño, planificado para implementarse con SignalR)*
* Llamadas y señalización *(en diseño)*
* Base de datos en SQL Server

---

## Objetivos principales

* Implementar un backend unificado para mensajería y llamadas.
* Permitir comunicación en tiempo real sin recargas.
* Gestionar usuarios, sesiones y conversaciones de forma segura.
* Escalar horizontalmente mediante **SignalR** y **Entity Framework Core**.

---

## Tecnologías principales

* **.NET 8 / ASP.NET Core Web API**
* **Entity Framework Core**
* **SignalR** (comunicación en tiempo real)
* **SQL Server**
* **Swagger** (documentación de API)

---

## Arquitectura prevista

```
Talkthrough_API/
├── Controllers/
│   ├── AuthController.cs          → Registro y login
│   ├── MessagesController.cs      → Mensajería vía REST
│   └── CallsController.cs         → Control de llamadas
│
├── Hubs/
│   ├── ChatHub.cs                 → Mensajería en tiempo real
│   └── CallHub.cs                 → Señalización de llamadas
│
├── Services/
│   ├── MessageService.cs
│   └── CallService.cs
│
├── Data/
│   ├── TalkthroughContext.cs      → EF Core context
│   └── Migrations/
│
├── Models/                        → Entidades y DTOs
├── Mappings/                      → Configuración de AutoMapper
└── Program.cs                     → Configuración principal
```

---

## Ejemplo conceptual (mensajería)

1. El usuario **A** envía un mensaje al usuario **B** a través del **ChatHub**.
2. El servidor reenvía el mensaje a los clientes conectados de **B** mediante SignalR.
3. El mensaje se almacena en la base de datos, pero **sin contenido confidencial** (solo metadatos).
4. Si **B** no está conectado, el mensaje queda en **cola** hasta su reconexión.

---

## Futuras mejoras

* Integración de **WebRTC** para transmisión de audio y video.
* Soporte de **notificaciones push**.
* Panel administrativo para monitoreo de sesiones.
* Despliegue en la nube (**Azure** o **AWS**).

---

## Instalación básica

**Clonar el repositorio:**

```bash
git clone https://github.com/tuusuario/Talkthrough_API.git
cd Talkthrough_API
```

**Configurar la conexión a SQL Server en `appsettings.json`:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TalkthroughDB;Trusted_Connection=True;"
}
```

**Aplicar migraciones e iniciar el servidor:**

```bash
dotnet ef database update
dotnet run
```

**Abrir la documentación en Swagger:**

```
https://localhost:5001/swagger
```

---

## Autor

**Desarrollado por:** Álvaro Angulo Cortés
**LinkedIn:** [linkedin.com/in/álvaro-angulo-cortés-993b92337](https://www.linkedin.com/in/álvaro-angulo-cortés-993b92337)
**Propósito:** Proyecto de portfolio para demostrar arquitectura backend con .NET y SignalR.

---


## Licencia

Este proyecto está bajo la licencia **MIT**.
