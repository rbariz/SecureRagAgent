# Secure RAG Agent

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

* 🇬🇧 [Domain Model](docs/en/domain-model.md)

* 🇫🇷 [Modèle de Domaine](docs/fr/domain-model.md)

---

## Architecture (high-level)

Client → API → RAG → RBAC → Vector DB → LLM → Guardrails → Monitoring
