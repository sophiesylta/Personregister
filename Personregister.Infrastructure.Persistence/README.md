## Migrering og oppdatering av databasn
Disse kommandoen utføerer migrering og oppdatering av databasen:


eksempler:
Add-migration kallenavn -project Personregister.Infrastructure.Persistence -startupproject Personregister.WebAPI -Context Personregistercontext
Update-Database  -project Personregister.Infrastructure.PersistenceI -startupproject Personregister.WebAPI  -Context Personregistercontext


Remove-Migration -project Personregister.Infrastructure.Persistence -startupproject Personregister.WebAPI -Context Personregistercontext

//for å fjerne migrasjon fra db , bruk tidliger migrasjon
 Update-Database <LegemiddelverketHenteDato> -Context Personregistercontext


//hvordan scaffolidng en db
Scaffold-DbContext ""Data Source = 127.0.0.1, 1401; Initial Catalog = Personregister; User ID = SA; Password = Password9!"" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domene -Context "Personregistercontext" -f