# review-oracle

`review-oracle` is a deterministic full-stack benchmark repository used to evaluate GitHub Copilot custom PR reviewer agents.

## Stack

- ASP.NET Core Web API (`src/Api`)
- Next.js + React web app (`src/Web`)
- xUnit API test project (`tests/Api.Tests`)

## Baseline

The baseline branch contains a simple Reports app:

- Public API health endpoint: `GET /health`
- Reports API endpoints: `GET /api/reports`, `GET /api/reports/{id}`
- Authenticated report creation endpoint: `POST /api/reports`
- Placeholder Auth0-style JWT bearer configuration with issuer + audience validation
- Next.js UI that lists and views reports via a small API client wrapper

## Issue Branches

Each `feature/*` branch introduces a small planted issue:

- `feature/auth0-middleware-change` (AUTH-001)
- `feature/client-side-entitlement-check` (AUTH-002)
- `feature/nextjs-public-secret` (NEXTJS-001)
- `feature/react-effect-bug` (REACT-001)
- `feature/api-logging-sensitive-data` (API-001)

Expected reviewer outcomes are documented in `eval/expected-findings`.

## Run the API

```bash
cd src/Api
dotnet run
```

## Run the Web App

```bash
cd src/Web
cp .env.example .env.local
npm install
npm run dev
```

## Run API Tests

```bash
dotnet test tests/Api.Tests/Api.Tests.csproj
```

## How to Use This Repo

1. Open a PR from one of the `feature/*` branches into `master` (or your baseline branch).
2. Run the GHCP custom PR reviewer agent on the PR.
3. Compare the reviewer output with the matching file in `eval/expected-findings`.
4. Record whether the reviewer found the issue, missed it, or produced unrelated noise.

## Manual Evaluation Notes

Keep early PRs focused and small so reviewer output is deterministic. Avoid mixing multiple unrelated issues in one branch.
