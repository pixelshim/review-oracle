# NEXTJS-001: Secret Exposed Through `NEXT_PUBLIC_`

## Branch

`feature/nextjs-public-secret`

## Category

Secrets Management

## Severity

High

## Expected Finding

A server-only secret is exposed via an environment variable prefixed with `NEXT_PUBLIC_`, which makes it available in browser bundles.

## Expected Location

`src/Web/.env.example` or `src/Web/lib/*`

## Good Reviewer Behavior

The reviewer should call out that `NEXT_PUBLIC_` variables are public and secrets must stay server-only.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
