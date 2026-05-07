# AUTH-002: Client-Side Entitlement Trust

## Branch

`feature/client-side-entitlement-check`

## Category

Authentication / Authorization

## Severity

High

## Expected Finding

The front-end hides privileged actions based on a client-side entitlement check, but the API endpoint does not enforce the equivalent authorization policy.

## Expected Location

`src/Web/app/page.tsx` and `src/Api/Program.cs`

## Good Reviewer Behavior

The reviewer should identify that authorization must be enforced on the server and not trusted from browser-side checks.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
