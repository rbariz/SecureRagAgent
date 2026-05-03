# Abstractions Application — Secure RAG Agent

🌍 Langue :
- 🇫🇷 Français
- 🇬🇧 [English](../en/application-abstractions.md)

---

## Vue d’ensemble

La couche Application définit les contrats stables utilisés par Secure RAG Agent.

Elle ne dépend pas d’OpenAI, Ollama, PostgreSQL, EF Core ou d’une implémentation d’infrastructure.

---

## Abstractions principales

### Providers IA

- ILlmProvider
- IEmbeddingProvider

Objectif :

- Supporter plusieurs providers LLM
- Permettre OpenAI et Ollama
- Garder la logique métier indépendante du provider

---

### Retrieval

- IRetrievalService

Objectif :

- Rechercher les chunks autorisés
- Appliquer le RBAC avant retrieval

---

### Sécurité / RBAC

- IAccessScopeService

Objectif :

- Résoudre les rôles utilisateur
- Fournir le scope autorisé à la couche retrieval

---

### Guardrails

- IGuardrailService

Objectif :

- Valider l’entrée utilisateur
- Valider la sortie générée
- Bloquer les demandes dangereuses ou hors périmètre

---

### Monitoring

- IRagQueryLogger
- ICostEstimator

Objectif :

- Tracer les requêtes RAG
- Suivre les tokens et le coût estimé
- Supporter l’audit et l’observabilité

---

### Documents

- IDocumentIngestionService

Objectif :

- Gérer l’ingestion documentaire
- Créer les chunks
- Générer les embeddings
- Stocker les permissions documentaires

---

### Orchestration RAG

- IRagOrchestrator

Objectif :

- Coordonner tout le pipeline RAG
- Appliquer les guardrails
- Résoudre le RBAC
- Récupérer les chunks autorisés
- Appeler le provider LLM sélectionné
- Retourner des réponses sourcées

---

## Règles de conception

- Application définit les interfaces
- Infrastructure implémente les interfaces
- Aucun SDK provider dans Application
- Aucune dépendance EF Core dans Application
- Aucun appel direct OpenAI ou Ollama hors Infrastructure