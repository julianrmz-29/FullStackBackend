# FullStackBackend
API's created in C# using .NET 9

# Notes:
- Backend to manage the task crud
- Open the solution with Visual Studio 2022
- By default, data storage is implemented in memory, but if you prefer to use a SQL Server database, you must create the database and then migrate the table or manually create the ToDo table.
- If you decide to use a SQL Server database and migration, uncomment the connection string in program and comment out the in-memory DB section. Save the changes, open the NuGet Package Manager console, and enter the command: add-migration 'name-migration' -Context 'EntityContext'.
- If there are no errors, the Migrations folder should appear in the Solution Explorer.
- If the folder is present, type 'update.database' in the console.
- If you get an error, check program and appsettings to verify the connection string to the database or if any file displays an error.

- ## Methods implemented in the API:
- **GET**, **POST**, **PUT**, **DELETE**

### JSON body for POST and PUT
```json
   {
       "taskName": "string",
       "completed": false
   }
   Where:
      "taskName" is a string value,
      "completed" is a Boolean value

   DELETE: {id} receives as a parameter an integer value corresponding to the ID of the item to be deleted
  
- By default, when compiling the solution, it opens in the browser with the SCALAR documentation, but if you prefer to use Swagger, just change the URL path: https://localhost:{port}/swagger/index.html
- CORS enabled for "http://localhost:3000" and "http://localhost:4200"
