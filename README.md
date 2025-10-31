# Desclution Records

Desclution Records is a web application designed as a record management system. The project features a modern React frontend and a robust .NET backend, supporting user authentication and role-based access control.

---

## Table of Contents
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Backend Overview](#backend-overview)
- [Frontend Overview](#frontend-overview)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- User registration and authentication (JWT-based)
- Role-based authorization (Admin, User, etc.)
- Record item management (create, update, delete records)
- RESTful API with CORS support for frontend integration
- Modern React-based frontend with Vite for fast development

---

## Project Structure

```
Desclution-Records/
│
├── backend/
│   └── RecordManagerApi/
│       ├── Controllers/    # API controllers (e.g., AuthController)
│       ├── DTOs/           # Data Transfer Objects (UserDto, RegisterDto, etc.)
│       ├── Migrations/     # Entity Framework Core migrations
│       └── Program.cs      # Main entry point and configuration
│
└── frontend/
    ├── src/
    │   ├── App.jsx         # Main React application
    │   ├── main.jsx        # React app entry point
    │   └── App.css         # Application styles
    ├── index.html          # HTML entry point
    └── vite.config.js      # Vite configuration
```

---

## Getting Started

### Prerequisites

- [.NET 7+ SDK](https://dotnet.microsoft.com/download)
- [Node.js (v18+)](https://nodejs.org/)
- [npm](https://www.npmjs.com/)

### Backend

1. Navigate to the backend directory:
   ```
   cd backend/RecordManagerApi
   ```
2. Restore dependencies:
   ```
   dotnet restore
   ```
3. Apply migrations and run the API:
   ```
   dotnet ef database update
   dotnet run
   ```

### Frontend

1. Navigate to the frontend directory:
   ```
   cd frontend
   ```
2. Install dependencies:
   ```
   npm install
   ```
3. Start the development server:
   ```
   npm run dev
   ```

---

## Backend Overview

- Built with ASP.NET Core Web API.
- Uses Entity Framework Core for database access and migrations.
- Configures JWT authentication and role-based authorization.
- Swagger is enabled in development mode for API documentation.
- CORS policy allows frontend integration.

**Key Files:**
- `Program.cs`: Sets up authentication, authorization, CORS, AutoMapper, and middleware.
- `Controllers/AuthController.cs`: Handles registration, login, and admin creation endpoints.
- `Migrations/`: Contains database schema migrations.
- `DTOs/UserDto.cs`: Contains DTOs for user registration and login.

---

## Frontend Overview

- Built with [React](https://react.dev/) using [Vite](https://vite.dev/) for fast refresh and build.
- Main entry point is `src/main.jsx`.
- UI logic is in `src/App.jsx`.
- Styling via `src/App.css`.

---

## API Endpoints

The backend exposes the following main endpoints (see `Controllers/AuthController.cs`):

- `POST /api/auth/register` — Register a new user
- `POST /api/auth/login` — Authenticate and receive JWT token
- `POST /api/auth/create-admin` — Create an admin user (restricted access)

Additional endpoints for record management may be present (see other controllers).

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes
4. Push to your fork and open a Pull Request

---

## License

This project is open source; see the [LICENSE](LICENSE) file for details.
