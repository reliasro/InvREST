# Scalable Inventory Web API + Client Applications
Inventory RESTful web service for handling products and transactions.

This is intentended to be used as starting point for developing your own web services.
Also you can evaluate best practices and architecture.

Please read and let me know how I can help you.

### Features
- Entity Framework 
- MediatR for Mediator pattern (CQRS)
- Clean Code archictecture
- DDD Driven Design (Aggregates, domain events)
- AutoMapper for translating Dtos to Commands/Queries and viceversa
- CollectionServices for IoC
- SQLite so you can test the solution faster and then move to Mysql/SQL Server
- Fluent Validation ready
- Fluent Validation IPipelineBehavior for automatic commands validations
- MediatR notifications between commands
- Generic Repository pattern
- CORS policy enabled so you can test it from any client App in no time
- Console application with HttpClient injected as service
- Razor application (CRUD)
- Commands structured as Features/Use cases for easy collaboration/maintenance
- Bootstrap components 
- One solution for fast implementation
- Services registered in every proyect as needed for more organized code/maintenance


### Use cases
- Add product
- Edit product
- Read product
- Read product list
- Purchase transaction
- Sale transaction
- Current stock


### Startup project

The startup project is the Web API. But you can add more launch profiles in .vscode/Launch.json, .vscode/tasks.json.

You will find two profiles:
- **.NET Core Launch - Web API** : run this one for the RESTful API
- **.NET Core Launch - Webapp** : run this one for the Razor Web App

Run the console application for testing the end points of the web service.


### Projects description

For easy understanding, there is a small description of the role of each component of the solution.

- **Soinsoft.Inventory.Domain.Model** : entities of the business
- **Soinsoft.Inventory.Domain.Contracts** : Dtos 
- **Soinsoft.Inventory.Application.Contracts** : only IRepository interface, but it will be used for adding more services
- **Soinsoft.Inventory.Application.Commands** : features of the application in the form of commands, queries, validators and notifications
- **Soinsoft.Inventory.Infra.Persistence** : Entity Framerwork implemented for persisting information in SQLite
- **Soinsoft.Inventory.Presentation.ConsoleClient** : for testing this RESTful service
- **Soinsoft.Inventory.Presentation.WebAPI** : this is the implementation of the Web Service
- **Soinsoft.Inventory.Presentation.WebApp** : a small Razo CRUD web app for the REST service



### Next steps

I will be adding more features like paging, authentication, uses cases, docker image/compose and deploy to Azure.

Thank you for reading and enjoy!

---
**God bless you**.


