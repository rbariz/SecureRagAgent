# Architecture Decisions (ADR)

🌍 Language:

* 🇬🇧 English (default)
* 🇫🇷 [Français](../fr/decisions.md)

---

## ADR-001 — LLM Provider Abstraction

Decision:
Use an abstraction layer for LLM providers.

Reason:
Allow switching between OpenAI and Ollama.

---

## ADR-002 — RBAC Before Retrieval

Decision:
Apply RBAC filtering before retrieval.

Reason:
Prevent data leakage.

---

## ADR-003 — Mandatory Citations

Decision:
Answers must include sources.

Reason:
Ensure grounded responses.

---

## ADR-004 — Guardrails in Pipeline

Decision:
Guardrails applied before and after LLM.

Reason:
Ensure safety and compliance.

---

## ADR-005 — Full Observability

Decision:
Track all RAG queries.

Reason:
Enable debugging, cost control, and audits.
