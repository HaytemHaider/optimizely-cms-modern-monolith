# Optimizely CMS + Inertia + React Hybrid Demo

Developer-focused proof-of-concept showing:

- Optimizely page routing for `HomePage` + `SubPage`
- Inertia + React rendering for HTML responses
- Same friendly URL returning JSON when `Accept: application/json` + `Routed-By-ContentApi: 1`
- In-process Content Delivery API conversion (`IContent` -> `ContentApiModel`) without internal HTTP self-calls

## Project structure

- `src/OptimizelyCmsInertiaDemo` — ASP.NET Core + Optimizely + Inertia backend
- `src/frontend` — Vite + React + TypeScript frontend
- `test/OptimizelyCmsInertiaDemo.Tests` — xUnit unit tests
- `e2e` — Playwright E2E tests

## Prerequisites

- .NET SDK 8 (LTS) or compatible SDK for the configured `TargetFramework`
- Node.js 20+
- npm 10+

---

## Setup

Run these once after cloning:

### 1) Backend dependencies

```bash
dotnet restore src/OptimizelyCmsInertiaDemo/OptimizelyCmsInertiaDemo.csproj
dotnet restore test/OptimizelyCmsInertiaDemo.Tests/OptimizelyCmsInertiaDemo.Tests.csproj
```

### 2) Frontend dependencies

```bash
cd src/frontend
npm install
```

### 3) Playwright browsers (for E2E)

```bash
cd e2e
npx playwright install
```

---

## Run

Run backend and frontend dev server in separate terminals.

### Terminal A — run backend

```bash
dotnet run --project src/OptimizelyCmsInertiaDemo/OptimizelyCmsInertiaDemo.csproj
```

### Terminal B — run frontend (Vite)

```bash
cd src/frontend
npm run dev
```

---

## Run frontend only

Use this when you only want to iterate on React/Vite assets.

```bash
cd src/frontend
npm run dev
```

Optional production build check:

```bash
cd src/frontend
npm run build
```

---

## Test

### Unit tests (xUnit)

```bash
dotnet test test/OptimizelyCmsInertiaDemo.Tests/OptimizelyCmsInertiaDemo.Tests.csproj
```

### E2E tests (Playwright)

Make sure the app is running first (backend + frontend), then:

```bash
cd e2e
npx playwright test
```

---

## Notes

- `OptimizelyCdaInertiaContentProjector` centralizes CDA conversion so controllers stay thin.
- Some Optimizely CDA converter signatures differ by package version. Search for `TODO: verify package version signature` and align the converter context/services with your installed Optimizely packages.
