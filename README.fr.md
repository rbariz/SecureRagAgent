# Secure RAG Agent

🌍 Langue :

* 🇫🇷 Français
* 🇬🇧 [English](README.md)

---

## Vue d’ensemble

Secure RAG Agent est un système IA orienté entreprise permettant d’interroger des données internes de manière sécurisée via une architecture RAG.

Il combine :

* LLM (OpenAI / Ollama)
* PostgreSQL + pgvector
* RBAC (contrôle d’accès)
* Guardrails (sécurité)
* Monitoring + suivi des coûts

---

## Objectifs

* Répondre à des questions sur des documents internes
* Appliquer un contrôle d’accès strict
* Éviter toute fuite de données sensibles
* Fournir des réponses avec sources
* Suivre l’usage, le coût et la qualité

---

## Stack technique

* ASP.NET Core
* PostgreSQL + pgvector
* OpenAI / Ollama
* Architecture modulaire

---

## Statut

🚧 Projet en cours de développement

---

## 📚 Documentation

* 🇫🇷 [Architecture](docs/fr/architecture.md)

* 🇬🇧 [Architecture (EN)](docs/en/architecture.md)

* 🇫🇷 [Décisions (ADR)](docs/fr/decisions.md)

* 🇬🇧 [Decisions (ADR)](docs/en/decisions.md)

* 🇫🇷 [Modèle de Domaine](docs/fr/domain-model.md)

* 🇬🇧 [Domain Model](docs/en/domain-model.md)

* 🇫🇷 [Stratégie i18n](docs/fr/i18n.md)

* 🇬🇧 [Internationalization Strategy](docs/en/i18n.md)

* 🇫🇷 [Schéma Base de Données](docs/fr/database.md)

* 🇬🇧 [Database Schema](docs/en/database.md)

---

## Architecture (vue simplifiée)

Client → API → RAG → RBAC → Vector DB → LLM → Guardrails → Monitoring
