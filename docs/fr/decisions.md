# Décisions d’Architecture (ADR)

🌍 Langue :

* 🇫🇷 Français
* 🇬🇧 [English](../en/decisions.md)

---

## ADR-001 — Abstraction LLM

Décision :
Utiliser une abstraction des providers LLM.

Raison :
Permettre OpenAI ou Ollama sans impact métier.

---

## ADR-002 — RBAC avant retrieval

Décision :
Filtrer avant la recherche vectorielle.

Raison :
Éviter toute fuite de données.

---

## ADR-003 — Sources obligatoires

Décision :
Réponses avec sources obligatoires.

Raison :
Limiter hallucinations.

---

## ADR-004 — Guardrails intégrés

Décision :
Guardrails avant et après LLM.

Raison :
Sécurité et conformité.

---

## ADR-005 — Observabilité complète

Décision :
Tracer toutes les requêtes RAG.

Raison :
Audit, debug, coût.
