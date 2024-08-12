# .NET/C# API Backend with T-SQL Database

This project is a .NET/C# API backend application that uses a T-SQL database. The API provides endpoints to manage a Kanban board, including columns and cards.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Contributing](#contributing)
- [License](#license)

## Overview

This project is designed to provide a backend API for managing a Kanban board. The API is built using .NET Core and Entity Framework Core, and it connects to a T-SQL database. The application supports CRUD operations for columns and cards on the Kanban board.

## Features

- CRUD operations for Kanban columns and cards
- In-memory database support for development and testing
- T-SQL database integration for production
- RESTful API design

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for production)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other C# IDE

## Setup

### Clone the Repository

```bash
git clone https://github.com/yourusername/your-repo-name.git
cd your-repo-name
```

### Configure the Database
1. In-Memory Database (Development): No additional setup is required for the in-memory database. The application will use an in-memory database by default for development.

2. T-SQL Database (Production): Update the connection string in appsettings.json to point to your SQL Server instance.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  }
}
```

### Apply Migrations

Run the following commands to apply migrations and create the database schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Running the Application

### Run the API

```bash
dotnet run
```

The API will be available at `http://localhost:5000`.

### Run the Angular Application

If you have an Angular frontend, navigate to the Angular project directory and run:

```bash
ng serve
```

The Angular application will be available at http://localhost:4200.

