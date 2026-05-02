# Secure RAG Agent

🌍 Langue :

* 🇬🇧 [English](README.md)
* 🇫🇷 Français

---

## Vue d’ensemble

Secure RAG Agent est un système IA orienté entreprise permettant d’interroger des données internes de manière sécurisée via une architecture RAG (Retrieval-Augmented Generation).

Il combine :

* Raisonnement LLM (OpenAI / Ollama)
* PostgreSQL + pgvector pour la recherche vectorielle
* RBAC pour le contrôle d’accès
* Guardrails pour la sécurité
* Monitoring et suivi des coûts

---

## Objectifs

* Répondre à des questions à partir de documents internes
* Appliquer un contrôle d’accès strict (RBAC)
* Éviter toute fuite de données sensibles
* Fournir des réponses fiables avec sources
* Suivre l’usage, le coût et la qualité

---

## Stack technique

* ASP.NET Core
* PostgreSQL + pgvector
* OpenAI / Ollama (interchangeables)
* Architecture modulaire

---

## Statut

🚧 Projet en cours de développement (construction progressive)

---

## Architecture (vue simplifiée)

Client → API → RAG → RBAC → Vector DB → LLM → Guardrails → Monitoring
