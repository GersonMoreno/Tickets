Se debe crear la migracion: se va a la terminal y ejecuta:
--- cd DAL
luego ejecutar:
--- dotnet-ef migrations add tickets -s ../Tickets
Para crear la base de datos ejecutar:
--- cd ../Tickects
luego ejecutar
--- dotnet-ef database update
ahora si ejecutar el programa y luego dirigirse a swagger:
--- https://localhost:44344/swagger/index.html
Estaran dos controladores (ticket y ususarios) donde usuarios es donde visualizan los tickets que tiene asignado