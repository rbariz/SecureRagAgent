## `docs/fr/ingestion.md`

```md
# Ingestion documentaire

🌍 Langue :
- 🇫🇷 Français
- 🇬🇧 [English](../en/ingestion.md)

---

## Vue d’ensemble

Le pipeline d’ingestion transforme un document brut en données vectorielles exploitables par le moteur RAG.

---

## Pipeline MVP

1. Lecture du contenu du document
2. Découpage du texte en chunks
3. Génération des embeddings
4. Stockage des chunks et embeddings dans PostgreSQL + pgvector
5. Association des permissions RBAC au document
6. Passage du document au statut indexé

---

## Portée MVP

Le MVP supporte actuellement :

- documents texte simples
- chunking fixe basique
- un embedding par chunk
- permissions documentaires par rôle
- stockage PostgreSQL + pgvector

---

## Décision sur la dimension des embeddings

Pour le MVP, la dimension vectorielle est fixée à :

```text
vector(768)

Raison :

Ollama nomic-embed-text retourne des embeddings de 768 dimensions.
Le projet privilégie actuellement le développement local avec Ollama.
Le support OpenAI reste prévu, mais la gestion multi-dimensions sera traitée plus tard.
Limites actuelles

Le MVP ne supporte pas encore :

parsing PDF
OCR
chunking avancé
jobs d’ingestion asynchrones
dimensions différentes selon provider
versioning documentaire
Améliorations futures
parsing PDF et Markdown
chunking intelligent par sections/titres
jobs d’ingestion en arrière-plan
validation du modèle d’embedding
stratégie multi-dimension OpenAI/Ollama
dashboard de suivi d’ingestion