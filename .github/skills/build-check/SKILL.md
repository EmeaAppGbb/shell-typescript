---
name: build-check
description: Verify that all project services (API and Web) build successfully. Check compilation errors, type errors, and lint warnings. Use before running tests, before deployment, after code changes, and on resume. Trigger when build verification, compilation check, or pre-test validation is needed.
---

# Build Check

Verify builds succeed before proceeding with tests or deployment.

## Build Commands

| Service | Source Build | Docker Build |
|---------|------------|--------------|
| API (TypeScript) | `cd src/api && npm run build` | `docker build -f src/api/Dockerfile .` |
| Web (Next.js) | `cd src/web && npm run build` | `docker build -f src/web/Dockerfile .` |

## Steps

1. **Identify services** — Read `azure.yaml` or scan `src/` for service directories
2. **Verify domain model artifact** — If contracts exist or implementation has started, verify `specs/docs/architecture/domain-model.md` exists and includes Mermaid domain modeling content (context map plus aggregate/entity diagram)
3. **Build each service** — Run the source build command for each service
4. **Capture errors** — Collect compilation errors, type errors, and warnings
5. **Docker build** (if preparing for deployment) — Run Docker build for each Dockerfile
6. **Report** — Summarize build status per service and whether the domain model artifact is present

## Output Format

```
Domain Model: PASS | FAIL | N/A

Service: <name>
Status: PASS | FAIL
Errors: <count>
Warnings: <count>

Details:
- <file>:<line> <error message>
```

## Notes

- Web (Next.js) requires `output: 'standalone'` in `next.config.ts`
- API uses TypeScript with Express
- The domain model check is a delivery-readiness check, not a quality judgment of the model itself
