# Architecture — Secure RAG Agent

🌍 Language:

* 🇬🇧 English (default)
* 🇫🇷 [Français](../fr/architecture.md)

---

## Overview

Secure RAG Agent is designed as a modular, secure, enterprise-ready system for AI-powered knowledge retrieval.

---

## High-Level Architecture

Client → API → RAG Orchestrator → RBAC → Vector DB → LLM → Guardrails → Monitoring

---

## Solution Structure

* Api → HTTP layer
* Application → business logic
* Domain → core entities
* Infrastructure → DB, LLM, external systems

---

## RAG Pipeline

1. User question
2. Input guardrails
3. RBAC scope resolution
4. Retrieval (pgvector)
5. Prompt construction
6. LLM call
7. Output guardrails
8. Citation validation
9. Response

---

## Key Principles

* RBAC enforced before retrieval
* No answer without sources
* LLM provider abstraction
* Full observability
* Security-first design
Secure RAG Agent

🌍 Language:

* 🇬🇧 English (default)
* 🇫🇷 [Français](README.fr.md)

---

## Overview

Secure RAG Agent is an enterprise-grade AI system designed to provide **secure, role-based access to internal knowledge** using Retrieval-Augmented Generation (RAG).

It combines:

* LLM reasoning (OpenAI / Ollama)
* PostgreSQL + pgvector for vector search
* RBAC for secure access control
* Guardrails for safety
* Monitoring and cost tracking

---

## Goals

* Answer questions using internal documents
* Enforce strict RBAC (Role-Based Access Control)
* Prevent sensitive data leakage
* Provide grounded answers with citations
* Monitor usage, cost, and quality

---

## Tech Stack

* ASP.NET Core
* PostgreSQL + pgvector
* OpenAI / Ollama (interchangeable)
* Modular architecture

---

## Status

🚧 Project in active development (step-by-step build)

---

## 📚 Documentation

* 🇬🇧 [Architecture](docs/en/architecture.md)

* 🇫🇷 [Architecture (FR)](docs/fr/architecture.md)

* 🇬🇧 [Decisions (ADR)](docs/en/decisions.md)

* 🇫🇷 [Décisions (ADR)](docs/fr/decisions.md)

---

## Architecture (high-level)

Client → API → RAG → RBAC → Vector DB → LLM → Guardrails → Monitoring
