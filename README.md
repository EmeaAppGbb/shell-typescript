# spec2cloud · Next.js + TypeScript Shell

**Describe what to build → AI agents handle the how → deploy to Azure.**

spec2cloud is a GitHub template that turns a product requirements document into a deployed full-stack app. AI agents drive every phase — from spec refinement and interactive UI prototypes to test generation, implementation, and Azure deployment — with human approval gates at each step.

## Why spec2cloud?

| Problem | How spec2cloud solves it |
|---------|--------------------------|
| AI writes code that doesn't match your intent | You approve **browsable UI prototypes** before any code is generated |
| Generated tests miss real user flows | **Gherkin scenarios trace back to prototype screens** — nothing is invented in a vacuum |
| Stale APIs and deprecated patterns | Agents **query live docs** (Microsoft Learn, Context7, DeepWiki) before writing a single line |
| "It works on my machine" | **Aspire orchestration** locally, **Azure Container Apps** in production — same topology |

## How it works

> **[▶ View the interactive animated flow](docs/spec2cloud-flow.html)** — open in your browser to see the Ralph Loop, phase pipeline, and increment delivery cycle in action.

```
PRD ──► Spec Refinement ──► UI/UX Prototypes ──► Gherkin & Tests ──► Contracts ──► Implementation ──► Deploy
          (FRDs)           (browsable HTML)      (red baseline)     (API specs,     (API → Web →       (Azure
         ▲ approve          ▲ approve            ▲ approve          shared types)    Integration)       Container
                                                                                   ▲ approve            Apps)
                                                                                                      ▲ verify
```

Human approval gates pause the pipeline at every critical transition — nothing ships without your sign-off.

1. **Write a PRD** — plain-language product requirements in `specs/prd.md`
2. **Agents refine** — PRD → FRDs, reviewed through product + technical lenses
3. **Prototype** — interactive HTML wireframes you browse and approve in your browser
4. **Test-first** — Gherkin scenarios + Playwright e2e + Vitest unit tests, all failing (red baseline)
5. **Contracts** — API specs, shared TypeScript types, and infra requirements generated from specs
6. **Implement** — agents write code to make tests green (API slice → Web slice → Integration)
7. **Ship** — `azd up` deploys to Azure Container Apps; smoke tests verify production

## Quick start

```bash
# Create your repo from this template
gh repo create my-app --template EmeaAppGbb/spec2cloud-shell-nextjs-typescript
cd my-app && npm install
cd src/web && npm install && cd ../..
cd src/api && npm install && cd ../..

# Run locally (Aspire recommended)
npm run dev:aspire        # API + Web + Docs with service discovery

# Write your PRD and let agents take over
code specs/prd.md

# Deploy to Azure
azd auth login && azd up
```

## Tech stack

| Layer | Technology |
|-------|-----------|
| Frontend | Next.js · TypeScript · App Router · Tailwind CSS |
| Backend | Express.js · TypeScript · Node.js |
| Testing | Playwright (e2e) · Cucumber.js (BDD) · Vitest + Supertest (unit) |
| Docs | MkDocs Material — auto-generated from wireframes + Gherkin + screenshots |
| Local orchestration | .NET Aspire (service discovery & dashboard) |
| Deployment | Azure Container Apps via Azure Developer CLI (`azd`) |
| AI research | Microsoft Learn · Context7 · DeepWiki · Azure Best Practices MCP |

## Key commands

| Command | What it does |
|---------|-------------|
| `npm run dev:aspire` | Run all services with Aspire |
| `npm run dev:all` | API + Web + Docs concurrently |
| `npm run test:all` | Unit + BDD + e2e tests |
| `npm run build:all` | Production build (API + Web) |
| `npm run docs:full` | Capture screenshots + generate docs |
| `azd up` | Provision + deploy to Azure |

## Extending

- **Skills** (`.github/skills/`) — reusable agent procedures following the [agentskills.io](https://agentskills.io) standard
- **Orchestrator** (`AGENTS.md`) — the central loop; modify phases, gates, or add new ones
- **Stack-agnostic** — swap Next.js/Express for any framework; the pipeline works at the spec level

## License

ISC
