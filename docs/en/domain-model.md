# Domain Model — Secure RAG Agent

🌍 Language:
- 🇬🇧 English (default)
- 🇫🇷 [Français](../fr/domain-model.md)

---

## Overview

This document describes the initial domain model of Secure RAG Agent.

The domain layer contains pure business concepts and must not depend on EF Core, PostgreSQL, OpenAI, Ollama, or any infrastructure concern.

---

## Main Domains

### Identity / RBAC

Entities:

- AppUser
- AppRole
- UserRole

Purpose:

- Represent users and roles
- Support role-based access control
- Prepare secure document filtering

---

### Documents

Entities:

- Document
- DocumentChunk
- DocumentPermission

Purpose:

- Store document metadata
- Represent indexed chunks
- Define which roles can access which documents

Important rule:

RBAC must be enforced before retrieval. Unauthorized chunks must never be retrieved.

---

### Chat

Entities:

- ChatSession
- ChatMessage

Purpose:

- Track user conversations
- Store user and assistant messages

---

### Monitoring

Entities:

- RagQuery

Purpose:

- Track each RAG request
- Store provider, model, status, tokens, cost, and latency

---

### Guardrails

Entities:

- GuardrailEvent

Purpose:

- Track safety events
- Detect out-of-scope questions, PII, prompt injection, missing sources, or sensitive output

---

### Evaluations

Entities:

- EvalCase

Purpose:

- Define test cases for RAG quality, RBAC behavior, and answer reliability

---

## Design Rules

- Domain must remain infrastructure-free
- No EF Core attributes in domain entities
- No OpenAI or Ollama dependency in domain
- IDs are Guid-based
- Timestamps use UTC
- Business rules should live close to the domain model