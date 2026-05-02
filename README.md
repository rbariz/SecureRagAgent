# Secure RAG Agent

🌍 Language:

* 🇬🇧 English (default)
* 🇫🇷 [Français](README.fr.md)

---

## Overview

Secure RAG Agent is an enterprise-grade AI system designed to provide secure, role-based access to internal knowledge using Retrieval-Augmented Generation (RAG).

It combines:

* LLM reasoning (OpenAI / Ollama)
* PostgreSQL + pgvector for vector search
* RBAC for secure data access
* Guardrails for safety
* Monitoring and cost tracking

---

## Goals

* Answer questions using internal documents
* Enforce strict role-based access control (RBAC)
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

## Architecture (high-level)

Client → API → RAG → RBAC → Vector DB → LLM → Guardrails → Monitoring
