# REACT-001: `useEffect` Dependency Bug

## Branch

`feature/react-effect-bug`

## Category

React Correctness

## Severity

Medium

## Expected Finding

A React component has an incorrect dependency array in `useEffect`, causing stale data or missed refresh behavior when inputs change.

## Expected Location

`src/Web/components/*`

## Good Reviewer Behavior

The reviewer should identify the missing or incorrect dependency and explain runtime impact.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
