# Application Abstractions — Secure RAG Agent

🌍 Language:
- 🇬🇧 English (default)
- 🇫🇷 [Français](../fr/application-abstractions.md)

---

## Overview

The Application layer defines the stable contracts used by the Secure RAG Agent.

It does not depend on OpenAI, Ollama, PostgreSQL, EF Core, or any infrastructure implementation.

---

## Main Abstractions

### AI Providers

- ILlmProvider
- IEmbeddingProvider

Purpose:

- Support interchangeable LLM providers
- Allow OpenAI and Ollama implementations
- Keep business logic provider-agnostic

---

### Retrieval

- IRetrievalService

Purpose:

- Search authorized document chunks
- Enforce RBAC before retrieval

---

### Security / RBAC

- IAccessScopeService

Purpose:

- Resolve user roles and access context
- Provide the retrieval layer with the authorized scope

---

### Guardrails

- IGuardrailService

Purpose:

- Validate user input
- Validate generated output
- Block unsafe or out-of-scope requests

---

### Monitoring

- IRagQueryLogger
- ICostEstimator

Purpose:

- Track RAG requests
- Track token usage and estimated cost
- Support auditability and observability

---

### Documents

- IDocumentIngestionService

Purpose:

- Handle document ingestion
- Create chunks
- Generate embeddings
- Store document permissions

---

### RAG Orchestration

- IRagOrchestrator

Purpose:

- Coordinate the full RAG pipeline
- Apply guardrails
- Resolve RBAC
- Retrieve authorized chunks
- Call the selected LLM provider
- Return grounded answers with sources

---

## Design Rules

- Application defines interfaces only
- Infrastructure implements interfaces
- No provider-specific SDK in Application
- No EF Core dependency in Application
- No direct OpenAI or Ollama usage outside Infrastructure