# Optimizely CMS + Inertia + React Hybrid Demo

Developer-focused proof-of-concept showing:

- Optimizely page routing for `HomePage` + `SubPage`
- Inertia/React rendering for HTML responses
- Same friendly URL returning JSON when `Accept: application/json` + `Routed-By-ContentApi: 1`
- In-process Content Delivery API conversion (`IContent` -> `ContentApiModel`) without internal HTTP self-calls

## Structure

- `src/OptimizelyCmsInertiaDemo`: ASP.NET Core + Optimizely + Inertia backend
- `src/frontend`: Vite + React + TypeScript UI bundle
- `test/OptimizelyCmsInertiaDemo.Tests`: xUnit unit tests
- `e2e`: Playwright tests

## Setup

1. Restore/build backend:

   ```bash
   dotnet restore src/OptimizelyCmsInertiaDemo/OptimizelyCmsInertiaDemo.csproj
   dotnet run --project src/OptimizelyCmsInertiaDemo/OptimizelyCmsInertiaDemo.csproj
   ```

2. Start frontend dev server:

   ```bash
   cd src/frontend
   npm install
   npm run dev
   ```

3. Run unit tests:

   ```bash
   dotnet test test/OptimizelyCmsInertiaDemo.Tests/OptimizelyCmsInertiaDemo.Tests.csproj
   ```

4. Run e2e tests:

   ```bash
   cd e2e
   npx playwright test
   ```

## Notes

- The `OptimizelyCdaInertiaContentProjector` intentionally centralizes CDA conversion to keep controllers thin.
- Some Optimizely CDA converter signatures differ by package versions. Search for `TODO: verify package version signature` and align constructors/service interfaces with your exact package versions.
