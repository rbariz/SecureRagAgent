## `docs/fr/database.md`

```md
# Schéma Base de Données — Secure RAG Agent

🌍 Langue :
- 🇫🇷 Français
- 🇬🇧 [English](../en/database.md)

---

## Vue d’ensemble

Le projet utilise PostgreSQL avec pgvector comme couche de persistance et de recherche vectorielle.

La base de données est gérée avec les migrations EF Core.

---

## Tables principales

### Identity / RBAC

- app_users
- app_roles
- user_roles

Ces tables supportent le modèle MVP de contrôle d’accès par rôle.

---

### Documents

- documents
- document_chunks
- document_permissions

`document_chunks` stocke les morceaux de documents indexés.

La colonne `embedding` est stockée sous forme :

```text
vector(1536)

Cette dimension est compatible avec OpenAI text-embedding-3-small pour le MVP.

Chat
chat_sessions
chat_messages

Ces tables permettent de suivre les conversations utilisateur.

Monitoring
rag_queries

Cette table trace chaque requête RAG, incluant le provider, le modèle, le statut, les tokens, le coût estimé et la latence.

Guardrails
guardrail_events

Cette table trace les événements de sécurité comme les questions hors périmètre, la détection PII, les injections de prompt, l’absence de sources ou les sorties sensibles.

Evaluations
eval_cases

Cette table stocke les cas d’évaluation MVP pour la qualité RAG et la validation RBAC.

Décisions de conception
Domain sans dépendance infrastructure

La couche Domain ne référence pas Pgvector.

Le champ embedding est configuré dans Infrastructure comme propriété EF Core shadow.

Schéma compatible RBAC

Les permissions documentaires sont modélisées séparément via document_permissions.

Cela permet de filtrer les documents par rôle avant la recherche vectorielle.

Dates UTC

Toutes les entités auditables stockent les dates en UTC.

Limites MVP

La base MVP n’inclut pas encore :

isolation multi-tenant avancée
provider d’identité externe
audit log complet
historique complet des runs d’évaluation
table détaillée d’usage LLM

Ces éléments seront ajoutés progressivement.