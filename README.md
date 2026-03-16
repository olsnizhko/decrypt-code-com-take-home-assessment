# Decryptcode - Senior Full Stack Developer Assessment

This repository contains the migrated solution for the assessment:

- `backend-net` - ASP.NET Core backend
- `frontend-angular` - Angular frontend

The original reference application is also included under `take-home-assessment-main/` and contains the React + Node.js version used as the migration source.
## Assessment Note

This solution was completed as part of a take-home assessment.

During the implementation, I used Codex, Visual Studio Code, and Visual Studio 2026.

I chose Codex because of its strong integration with Visual Studio Code, as well as my ChatGPT Plus subscription, which helped accelerate parts of the analysis, refactoring, and migration process.

Thank you for the interesting assessment.
It was technically demanding and required significant focus, but it also gave me a genuine sense of professional engagement throughout the process.

## What's Included

### Backend (.NET 8 + ASP.NET Core)

- REST API preserving the original contract
- In-memory mock data loaded on startup
- Endpoints for dashboard, organizations, users, projects, time entries, invoices, and health

### Frontend (Angular 18)

- Standalone Angular components
- Dashboard
- Organizations list and detail
- Projects list and detail
- Relative `/api` calls proxied to the backend in development

## How to Run

### Backend

```bash
cd backend-net
dotnet run --project backend.csproj
```

Backend runs at:

```text
http://localhost:4000
```

### Frontend

```bash
cd frontend-angular
npm install
npm start
```

Frontend runs at:

```text
http://localhost:3000
```

## API Summary

| Method | Path | Description |
|---|---|---|
| GET | `/api/dashboard` | Aggregate counts for organizations, users, projects, time entries, and total invoiced |
| GET | `/api/organizations` | List organizations |
| GET | `/api/organizations/:id` | Single organization |
| GET | `/api/organizations/:id/summary` | Organization summary with counts and total invoiced |
| GET | `/api/users` | List users |
| GET | `/api/users/:id` | Single user |
| GET | `/api/projects` | List projects |
| GET | `/api/projects/:id` | Single project with organization and total hours logged |
| GET | `/api/time-entries` | List time entries |
| GET | `/api/invoices` | List invoices |
| GET | `/health` | Health check |

## Notes

- The migration preserves the original route structure and API contract.
- The Angular frontend uses a development proxy so `/api` and `/health` resolve to the backend on port `4000`.
- The projects are intentionally small so the focus stays on migration quality, architecture, and maintainability.

