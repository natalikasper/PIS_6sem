IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\lab4')
BEGIN
    CREATE LOGIN [IIS APPPOOL\lab4] 
      FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
      DEFAULT_LANGUAGE=[us_english]
END
GO
CREATE USER [WebDatabaseUser] 
  FOR LOGIN [IIS APPPOOL\lab4]
GO
EXEC sp_addrolemember 'db_owner', 'WebDatabaseUser'
GO