# Database Schema — Secure RAG Agent

🌍 Language:
- 🇬🇧 English (default)
- 🇫🇷 [Français](../fr/database.md)

---

## Overview

The project uses PostgreSQL with pgvector as the persistence and vector search layer.

The database is managed through EF Core migrations.

---

## Main Tables

### Identity / RBAC

- app_users
- app_roles
- user_roles

These tables support the MVP role-based access model.

---

### Documents

- documents
- document_chunks
- document_permissions

`document_chunks` stores the indexed document chunks.

The `embedding` column is stored as:

```text
vector(1536)

This dimension is compatible with OpenAI text-embedding-3-small for the MVP.

Chat
chat_sessions
chat_messages

These tables track user conversations.

Monitoring
rag_queries

This table tracks each RAG request, including provider, model, status, tokens, estimated cost, and latency.

Guardrails
guardrail_events

This table tracks safety-related events such as out-of-scope questions, PII detection, prompt injection, missing sources, or sensitive output.

Evaluations
eval_cases

This table stores MVP evaluation cases for RAG quality and RBAC validation.

Design Decisions
Domain stays infrastructure-free

The Domain layer does not reference Pgvector.

The embedding field is configured in Infrastructure as an EF Core shadow property.

RBAC-ready schema

Document permissions are modeled separately using document_permissions.

This enables filtering documents by role before vector retrieval.

UTC timestamps

All auditable entities store timestamps in UTC.

MVP Limitations

The MVP database does not yet include:

advanced tenant isolation
external identity provider tables
full audit log
eval run history
detailed LLM usage table

These can be added incrementally.