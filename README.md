# Planetary Exploration Logs API

## Overview

The Planetary Exploration Logs API is a .NET Core Web API designed to manage and log planetary exploration missions, discoveries, and related data. This API provides endpoints to create, read, update, and delete missions and discoveries, as well as retrieve information about planets and discovery types.

## Project Structure

```tree
PlanetaryExplorationLogs.API/
├── Controllers/
│   ├── DiscoveryController.cs
│   ├── MissionController.cs
│   └── PlanetController.cs
├── Data/
├── Migrations/
├── Properties/
├── Requests/
├── Utility/
├── appsettings.Development.json
├── appsettings.json
├── PlanetaryExplorationLogs.API.csproj
├── Program.cs
└── Instructions.md
```

## Getting Started

### Prerequisites

- .NET Core SDK
- Visual Studio or Visual Studio Code
- SQL Server or SQLite

### Setup

1. Clone the repository:
    ```sh
    git clone <repository-url>
    cd PlanetaryExplorationLogs.API
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Update the database:
    ```sh
    dotnet ef database update
    ```

4. Run the application:
    ```sh
    dotnet run
    ```

### Configuration

The application settings can be configured in the `appsettings.json` and `appsettings.Development.json` files.

### Running the API

The API can be accessed at the following URLs:
- HTTP: `http://localhost:5125`
- HTTPS: `https://localhost:7221`

Swagger UI is available at `/swagger` for exploring and testing the API endpoints.

## API Endpoints

### DiscoveryController

- **GET** `api/discovery/types`: Retrieve all discovery types.
- **GET** `api/discovery/{id}`: Retrieve a specific discovery by ID.
- **PUT** `api/discovery/{id}`: Update an existing discovery.
- **DELETE** `api/discovery/{id}`: Delete a discovery.

### MissionController

- **GET** `api/mission/{id}`: Retrieve a specific mission by ID.
- **POST** `api/mission`: Create a new mission.
- **PUT** `api/mission`: Update an existing mission.
- **DELETE** `api/mission/{id}`: Delete a mission by ID.
- **GET** `api/mission/{missionId}/discovery`: Retrieve all discoveries for a specific mission.
- **POST** `api/mission/{missionId}/discovery`: Create a new discovery under a specific mission.

### PlanetController

- **GET** `api/planet/dropdown`: Retrieve a dropdown list of planets.
- **GET** `api/planet/{id}`: Retrieve a specific planet by ID.
- **POST** `api/planet`: Create a new planet.
- **PUT** `api/planet`: Update an existing planet.



