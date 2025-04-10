RapidPay API

A RESTful API built with C# for managing payment cards and calculating dynamic transaction fees.
The project uses Entity Framework Core with SQL Server and follows Clean Architecture principles for a scalable and maintainable codebase.


## Project Structure

RapidPay.Domain           → Domain entities
RapidPay.Application      → Interfaces and core business logic 
RapidPay.Infrastructure   → EF Core DB context
RapidPay.Web.Api          → Presentation layer: HTTP controllers and configuration

## Technology Choices

Entity Framework Core: Object-relational mapping (ORM) to manage data persistence
SQL Server: Robust RDBMS, widely used in enterprise solutions
JWT Authentication: Secure, stateless authentication method for APIs
Password Hashing: Improves security for user credentials
Swagger: Developer-friendly API exploration and documentation
Architecture: Clean Architecture to separate concerns, making the system easier to maintain, scale, and adapt to future changes.