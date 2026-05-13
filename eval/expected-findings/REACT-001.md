# REACT-001: useEffect Dependency Bug

## Branch

`feature/react-effect-bug`

## Category

React Correctness

## Severity

Medium

## Expected Finding

A React `useEffect` uses props/state values but omits one from the dependency array, resulting in stale data and missed refreshes.

## Expected Location

`src/Web/components/ReportList.js`

## Good Reviewer Behavior

The reviewer should identify the dependency mismatch and explain the runtime behavior impact.

## Do Not Require

- Exact wording
- Exact line number
- A specific code fix
