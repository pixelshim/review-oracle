# NEXTJS-001: Secret Exposed Through NEXT_PUBLIC_

## Branch

`feature/nextjs-public-secret`

## Category

Configuration / Secrets Management

## Severity

High

## Expected Finding

A value intended to stay server-side is defined with the `NEXT_PUBLIC_` prefix, making it available to all browser clients.

## Expected Location

`src/Web/.env.example`

## Good Reviewer Behavior

The reviewer should identify that `NEXT_PUBLIC_` values are bundled for client use and must never contain secrets.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
