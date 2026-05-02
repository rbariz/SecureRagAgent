# Architecture — Secure RAG Agent

🌍 Langue :

* 🇫🇷 Français
* 🇬🇧 [English](../en/architecture.md)

---

## Vue d’ensemble

Secure RAG Agent est conçu comme un système modulaire et sécurisé permettant d’exploiter des données internes via IA.

---

## Architecture globale

Client → API → Orchestrateur RAG → RBAC → Base vectorielle → LLM → Guardrails → Monitoring

---

## Structure de la solution

* Api → couche HTTP
* Application → logique métier
* Domain → entités
* Infrastructure → DB, LLM

---

## Pipeline RAG

1. Question utilisateur
2. Guardrails entrée
3. Résolution RBAC
4. Recherche vectorielle
5. Construction prompt
6. Appel LLM
7. Guardrails sortie
8. Validation des sources
9. Réponse

---

## Principes clés

* RBAC avant retrieval
* Pas de réponse sans source
* Abstraction LLM
* Observabilité complète
* Sécurité prioritaire
