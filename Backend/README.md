# Iniciar el proyecto
Inicial el proyecto con la base de datos sql server configurada en un contenedor.
- Instalar docker 
- Ubicarse en la ruta c17-117-t-csharp\Backend y ejecutar el comando:
  
  `docker-compose up -d`
  
  Puedes ver el contenedor con Docker Desktop
  ![image](https://github.com/No-Country/c17-117-t-csharp/assets/160936645/5774642d-2c57-4131-a3dc-2a6dea0af7a7)
- Ubicarse en la ruta c17-117-t-csharp\Backend\API y ejecutar el comando:
  
  `dotnet ef database update`

- Ahora ya puedes iniciar el proyecto

## Comandos 
- Añadir una migración
  `dotnet ef migrations add [NombreDeLaMigracion]`
  
- Ejecutar una migración
  `dotnet ef database update`
## Conectarse a la base de datos desde SSMS
- El contenedor debe estar ejecutandose.
- Loggin
  
  ![image](https://github.com/No-Country/c17-117-t-csharp/assets/160936645/db664b24-b75e-4c0a-ba86-4383ff61da74)

  El password es Pa55w0rd!
  


  

