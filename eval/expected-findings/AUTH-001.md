# AUTH-001: Missing JWT Audience Validation

## Branch

`feature/auth0-middleware-change`

## Category

Authentication / Authorization

## Severity

High

## Expected Finding

The ASP.NET Core API accepts JWTs without validating the expected audience. Issuer validation alone is insufficient because a token issued by the trusted issuer for a different API could be accepted.

## Expected Location

`src/Api/Program.cs`

## Good Reviewer Behavior

The reviewer should call out that the API must validate token audience and must not rely only on issuer validation.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
