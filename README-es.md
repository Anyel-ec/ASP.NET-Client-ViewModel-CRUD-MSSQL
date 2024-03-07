# Cliente MVC Application - CRUD in MSSQL

Este proyecto de aplicación ASP.NET MVC está diseñado para gestionar clientes en una base de datos MSSQL. Permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre la entidad "Cliente". La aplicación incluye tres vistas principales: **Index**, **Nuevo**, y **Editar**.

### **Select Language:**
- [Español (Spanish)](README-es.md)
- [English](README.md)
- 
## Result
### Inicio
![Alt text](docs/home.PNG) 
### Nuevo Cliente
![Alt text](docs/new.PNG) 
### Editar Cliente
![Alt text](docs/edit.PNG) 
### Eliminar
![Alt text](docs/alert.PNG) 
### Luego de Eliminar
![Alt text](docs/delete_after.PNG) 

## Tabla de Contenidos
1. [Configuración Inicial](#configuración-inicial)
2. [Estructura del Proyecto](#estructura-del-proyecto)
3. [Vistas Principales](#vistas-principales)
4. [Modelo Cliente](#modelo-cliente)
5. [Controlador Cliente](#controlador-cliente)
6. [Base de Datos](#base-de-datos)

---

### Configuración Inicial

Antes de ejecutar la aplicación, asegúrate de tener configurada tu base de datos MSSQL y de haber ajustado la cadena de conexión en el archivo `web.config` de la aplicación.

```xml
<connectionStrings>
    <add name="lab2Entities" connectionString="TuCadenaDeConexion" providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

### Estructura del Proyecto

- **Models:** Contiene las clases de modelo para la entidad Cliente y la vista modelo utilizada en la vista Index.
- **Views/Cliente:** Contiene las vistas Index, Nuevo y Editar.
- **Controllers:** Contiene el controlador `ClienteController` que gestiona las operaciones CRUD.
- **Scripts:** Contiene scripts jQuery para la funcionalidad del datepicker.
- **Content:** Contiene archivos de estilo CSS.

---

### Vistas Principales

#### Index.cshtml
La vista principal que muestra una tabla con la lista de clientes. Permite realizar operaciones de edición y eliminación.

#### Nuevo.cshtml
Permite agregar nuevos clientes mediante un formulario. Incluye validación de datos utilizando Data Annotations y un datepicker jQuery para la selección de fechas de nacimiento.

#### Editar.cshtml
Similar a Nuevo.cshtml, pero destinado a la edición de clientes existentes.

---

### Modelo Cliente

```csharp
public class ClienteViewModel
{
    // Propiedades del modelo Cliente
    // ...
}

public class ListClienteViewModel
{
    // Propiedades del modelo ListClienteViewModel
    // ...
}
```

---

### Controlador Cliente

El controlador `ClienteController` maneja las operaciones CRUD para la entidad Cliente. Algunas acciones clave son:

- **Index:** Muestra la lista de clientes.
- **Nuevo:** Permite agregar un nuevo cliente.
- **Editar:** Permite editar un cliente existente.
- **Eliminar:** Permite eliminar un cliente.

---

### Base de Datos

La aplicación utiliza una base de datos MSSQL denominada `lab2Entities`. Asegúrate de tener creada la tabla `cliente` con los campos necesarios. Puedes utilizar Entity Framework Code First Migrations para gestionar las migraciones de la base de datos.

---

¡Esperamos que esta aplicación sea de utilidad! Si encuentras algún problema o tienes sugerencias de mejora, no dudes en contribuir al proyecto. ¡Gracias por utilizar esta aplicación ASP.NET MVC!