# DevTrackAI

Production-ready full-stack starter using **ASP.NET Core 8 + Oracle XE 21c + Angular + Tailwind + Docker Compose**.

## Architecture

```text
DevTrackAI/
├── backend/
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── DTOs/
│   ├── Models/
│   ├── Data/
│   ├── Middleware/
│   ├── Helpers/
│   ├── Dockerfile
│   └── DevTrackAI.Api.csproj
├── frontend/
│   ├── src/
│   ├── nginx/
│   └── Dockerfile
└── docker-compose.yml
```

## Stack

- Backend: ASP.NET Core 8 Web API
- Database: Oracle XE 21c (`gvenzl/oracle-xe:21-slim`)
- ORM: `Oracle.EntityFrameworkCore`
- Auth: JWT Bearer
- Frontend: Angular (latest stable config) + Tailwind CSS
- Infrastructure: Docker + Docker Compose

## Backend details

- Clean layered folders (`Controllers`, `Services`, `Repositories`, `Data`, `Models`, `DTOs`, `Middleware`, `Helpers`)
- Oracle DbContext configuration
- Oracle-friendly mappings (`NUMBER`, `VARCHAR2(255)`, `VARCHAR2(100)`, `CLOB`)
- Global exception middleware
- Swagger/OpenAPI
- Environment-based configuration
- Async/await across controllers/services/repositories
- Health endpoints:
  - `GET /api/health`
  - `GET /health/live`

## Docker

### Services in `docker-compose.yml`

1. **oracle**
   - Image: `gvenzl/oracle-xe:21-slim`
   - Container: `oracle`
   - Port: `1521`
   - Env:
     - `ORACLE_PASSWORD=devtrack123`
     - `APP_USER=devtrack`
     - `APP_USER_PASSWORD=devtrack123`
     - `ORACLE_DATABASE=XEPDB1`
   - Persistent volume: `oracle_data`
   - Restart policy: `always`

2. **api**
   - Multi-stage Dockerfile (`sdk:8.0` -> `aspnet:8.0`)
   - Port: `5000`
   - Depends on `oracle`
   - Connection string (container networking):
     - `Data Source=oracle:1521/XEPDB1;User Id=devtrack;Password=devtrack123;`

3. **frontend**
   - Multi-stage Dockerfile (`node:18` -> `nginx:alpine`)
   - Production Angular build served by NGINX
   - Port: `4200`
   - Depends on `api`

## Run locally with Docker

```bash
docker compose up -d --build
```

Then open:
- Frontend: http://localhost:4200
- API Swagger: http://localhost:5000/swagger
- API health: http://localhost:5000/api/health

## API quick test

1. Login to get token:

```bash
curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"admin","password":"admin"}'
```

2. Create task:

```bash
curl -X POST http://localhost:5000/api/tasks \
  -H "Authorization: Bearer <TOKEN>" \
  -H "Content-Type: application/json" \
  -d '{"title":"Set up CI","description":"Add build and deploy pipeline"}'
```

3. List tasks:

```bash
curl http://localhost:5000/api/tasks -H "Authorization: Bearer <TOKEN>"
```

## Notes

- For production, replace `Jwt__Secret` with a strong secret and manage through a secure secret store.
- Oracle startup can take some time on first boot.
