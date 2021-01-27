In order to run this repository code we need to configure the SQL Server database:

The faster way to do so is with Docker.
  1 - Run the following command:
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Thomson123!@' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
  2 - Now we need to create the database with its sctucture:
    Open your SQL Management system, I am particulary using 'Azure Data Studio'(https://docs.microsoft.com/pt-br/sql/azure-data-studio/download-azure-data-studio)
    Inside Thomson.Assessment/Infrastructure/Scripts, there is just one script that you need to run to perform the creation of the database.
    
After database configuration and creation, to run the application just open your favorite console, make sure to be inside the folder Thomson.Assessment and type `dotnet run`.

It is a pre-requisite to have dotnet 5 SDK(https://dotnet.microsoft.com/download/dotnet/5.0)

--
Talking about the application itself. 

In short, this application is build with the new release of dotnet 5 ASP.NET Core. 

The main packages inside this code are:

Dapper(https://stackexchange.github.io/Dapper/) - Database access and micro mapping the table to our class.
FluentValidator(https://fluentvalidation.net/)  - Separate models validation. I think with FluentValidation, the models keep simpliers(without the data annotations).
FluentAssertions(https://fluentassertions.com/) - With this package the assertion part of the unit tests become more readable.
Moq(https://github.com/moq/moq4)                - Mock framework for unit testing
MsTest(https://github.com/microsoft/testfx)     - Unit test framework, for this application I found that mstest would fit taking in account the complexity of the code.
