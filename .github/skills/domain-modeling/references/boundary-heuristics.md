# Boundary Heuristics

Use this reference when creating `specs/docs/architecture/domain-model.md` or when deciding whether to recommend a service split.

## Core Theory

### Strategic DDD

- **Ubiquitous language** aligns specs, conversations, diagrams, and code.
- **Bounded contexts** divide a larger system into internally consistent models.
- **Context maps** make relationships between those contexts explicit.

### Tactical DDD

- **Entities** have identity across time.
- **Value objects** are defined by attributes and invariants, not identity.
- **Aggregates** protect transactional consistency boundaries.
- **Domain services** hold domain behavior that does not belong naturally on an entity/value object.
- **Domain events** capture meaningful business facts that other contexts may react to.

## Signals for a Good Bounded Context

Look for clusters that have most of these traits:

- distinct business purpose
- distinct terminology
- distinct ownership or stakeholder group
- distinct policies and invariants
- data that is mostly created and changed inside the same cluster
- relatively stable interfaces to other parts of the system

## Signals That a Service Split May Be Worth Proposing

Propose a candidate microservice only when the bounded context also has strong operational reasons, such as:

- clearly independent scaling profile
- different availability or latency goals
- separate compliance or security boundary
- different team ownership or release cadence
- frequent change isolated to that context
- integration that can be evented or API-based without constant synchronous chatter

## Signals to Stay Modular

Prefer a modular monolith when you see these conditions:

- heavy cross-context synchronous calls
- shared transactions that are hard to untangle
- one team shipping the whole system together
- limited operational maturity for distributed systems
- no independent scaling or compliance driver
- boundaries are still fuzzy or terminology is unstable

## Common Anti-Patterns

- Splitting by technical layer (`user-service`, `database-service`, `email-service`) instead of business capability
- Treating every entity as its own microservice
- Equating database tables with aggregates
- Using a shared database across proposed services while claiming autonomy
- Proposing service splits without a deployment or ownership reason

## Recommended Artifact Shape

For each domain model, capture:

1. Ubiquitous language glossary
2. Bounded context list
3. Context map diagram
4. Aggregate/entity/value-object diagram
5. Invariants and domain rules
6. Mapping to code/contracts
7. Service boundary assessment

## Sources Used for This Guidance

- Eric Evans, *Domain-Driven Design: Tackling Complexity in the Heart of Software*
- Vaughn Vernon, *Implementing Domain-Driven Design*
- Martin Fowler, "Bounded Context"
- Martin Fowler & James Lewis, "Microservices"
- Microsoft Azure Architecture Center, "Domain analysis for microservices"
