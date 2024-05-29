### Description:
This project is a system for managing lists of circles. It is implemented using ASP.NET to create the API, Vue.js + Vite for the frontend, and Entity Framework for database operations. The primary goal of the project is to provide an interface for viewing and adding circles on the client side, which are stored in a database.

### Technologies Used:

### ASP.NET:

Controllers: Handle HTTP requests and interact with services and repositories to execute business logic.
Models: Define the data structure and serve as the basis for database creation through Entity Framework.
Services: Contain business logic and facilitate interaction between controllers and repositories.
Entity Framework:

Migrations: Manage the database schema and allow changes to the table structure.
Repositories: Provide an abstraction over data access and enable CRUD operations.
Vue.js + Vite:

Components: Ensure modularity and reusability of client-side code.
Vue Router: Manages client-side routing, ensuring smooth transitions between pages.

DTOs are used for requests to transfer data between the client and server, ensuring a clear contract and reducing data over-fetching.

### Application Architecture:
The project uses a microservices architecture. Each service is responsible for a specific part of the functionality, ensuring scalability and maintainability.

### Project Features:

CRUD Operations: The project allows creating, reading, updating, and deleting circles.
Interactive Interface: The frontend provides an intuitive interface for user interaction with circles.
Canvas Implementation: A canvas on the client side is implemented to visually display circles added by the user.
Data Validation: Utilizes DataAnnotations attributes for data validation on the server side.

### Microservices Architecture:
The project is designed with a microservices architecture, which means it is divided into small, independently deployable services. Each microservice handles specific business functionalities, communicates over HTTP, and ensures the system's overall scalability and resilience.
