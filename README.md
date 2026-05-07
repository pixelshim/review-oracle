# review-oracle

`review-oracle` is a deterministic full-stack benchmark repository for evaluating a GitHub Copilot custom PR reviewer agent.

## What this repository is for

This repo provides:

- A clean baseline (`master`) full-stack app.
- Focused `feature/*` branches that intentionally introduce one known issue.
- Ground-truth expected findings in `eval/expected-findings`.

## Baseline architecture

- `src/Api`: ASP.NET Core Web API for `reports` data with JWT bearer auth configuration.
- `src/Web`: Next.js + React UI that lists reports and shows report details.
- `tests/Api.Tests`: basic API unit tests.
- `eval/expected-findings`: expected findings for seeded issue branches.

## Seeded issue branches

- `feature/auth0-middleware-change` (`AUTH-001`)
- `feature/client-side-entitlement-check` (`AUTH-002`)
- `feature/nextjs-public-secret` (`NEXTJS-001`)
- `feature/react-effect-bug` (`REACT-001`)
- `feature/api-logging-sensitive-data` (`API-001`)

## Run the API

```bash
cd src/Api
dotnet run
```

Default local URL example: `http://localhost:5000`.

## Run the web app

```bash
cd src/Web
cp .env.example .env.local
npm install
npm run dev
```

## Run tests

```bash
dotnet test review-oracle.sln
```

## How to Use This Repo

1. Open a PR from one of the `feature/*` branches into `master`.
2. Run the GHCP custom PR reviewer agent on the PR.
3. Compare the reviewer output with the matching file in `eval/expected-findings`.
4. Record whether the reviewer found the issue, missed it, or produced unrelated noise.

## Scope for v1

This first version intentionally does **not** include automated scoring, dashboards, large synthetic PR generation, mutation testing, or real Auth0 tenant integration.
