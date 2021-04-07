# NetCore.UserApiExample
Net Core User Api Example. This is a base project trying to follow the best practices.


## Project Structure

 - InnoCVUserAPI: This is a web application project with .NetCore 3.1 and includes the controllers and Global Exception Handling
 - InnoCV.DatabaseModel: Class library with the Database entities for Entity Framework. Also includes Mapping classes to map entity classes to view model classes.
 - InnoCV.Model: Includes View Model classes, custom exceptions, result codes and dictionary.
 - InnoCV.Infrastructure: Project with all the logic of the application. In this case the logic is only the user manager to do all the CRUD operations
 - InnoCV.Test: Example unit testing project with a test for User Mapping class.

## Some details about the project

 - The API only exposes the View Model classes and the Entity classes are the ones that the application uses in business logic. In this case the classes are very similar but this only a sample application.
 - NetCore API is using global Exception handling to manage all the exceptions, that's the reason of no one of the controllers method have any try-catch block.
 - Database Context is configured to be created using Dependency injection and the controllers use it
 - Api is configured to use Swagger to show all endpoint methods and test them
 - The GET method to get all users is implemented in async mode to show one implementation example
 - The View Model classes have been configured to do validation and the NetCore app is configured to lauch automatic validation in requests
 - There are some Results Code defined with corresponding messages and they are used also as HttpStatus Code for results
 - Database Context is configured to connect to an SQLite Database. Database will be created automatically if it doesn't exists


> SQLite is not the best option to use in web application because it's a file resource and can cause problems when trying to open concurrently. This is just an example approach for simplify
