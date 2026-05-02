# Modèle de Domaine — Secure RAG Agent

🌍 Langue :
- 🇫🇷 Français
- 🇬🇧 [English](../en/domain-model.md)

---

## Vue d’ensemble

Ce document décrit le modèle de domaine initial de Secure RAG Agent.

La couche Domain contient uniquement les concepts métier purs. Elle ne doit pas dépendre d’EF Core, PostgreSQL, OpenAI, Ollama ou de tout autre détail d’infrastructure.

---

## Domaines principaux

### Identity / RBAC

Entités :

- AppUser
- AppRole
- UserRole

Objectif :

- Représenter les utilisateurs et les rôles
- Supporter le contrôle d’accès par rôle
- Préparer le filtrage sécurisé des documents

---

### Documents

Entités :

- Document
- DocumentChunk
- DocumentPermission

Objectif :

- Stocker les métadonnées des documents
- Représenter les chunks indexés
- Définir quels rôles peuvent accéder à quels documents

Règle importante :

Le RBAC doit être appliqué avant la recherche vectorielle. Les chunks non autorisés ne doivent jamais être récupérés.

---

### Chat

Entités :

- ChatSession
- ChatMessage

Objectif :

- Suivre les conversations utilisateur
- Stocker les messages utilisateur et assistant

---

### Monitoring

Entité :

- RagQuery

Objectif :

- Tracer chaque requête RAG
- Stocker le provider, le modèle, le statut, les tokens, le coût et la latence

---

### Guardrails

Entité :

- GuardrailEvent

Objectif :

- Tracer les événements de sécurité
- Détecter les questions hors périmètre, PII, prompt injection, absence de sources ou sortie sensible

---

### Evaluations

Entité :

- EvalCase

Objectif :

- Définir des cas de test pour la qualité RAG, le comportement RBAC et la fiabilité des réponses

---

## Règles de conception

- Domain doit rester indépendant de l’infrastructure
- Pas d’attributs EF Core dans les entités Domain
- Pas de dépendance OpenAI ou Ollama dans Domain
- Les identifiants sont basés sur Guid
- Les dates sont en UTC
- Les règles métier doivent rester proches du modèle de domaine