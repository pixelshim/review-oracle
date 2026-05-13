# AUTH-002: Client-Side Entitlement Trust

## Branch

`feature/client-side-entitlement-check`

## Category

Authentication / Authorization

## Severity

High

## Expected Finding

The front-end hides controls using a client-side role check, but the API endpoint lacks equivalent authorization enforcement.

## Expected Location

`src/Web/app/page.js` and `src/Api/Program.cs`

## Good Reviewer Behavior

The reviewer should explain that UI checks are not authorization and that server-side policy enforcement is required.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
