# Providers IA — Secure RAG Agent

🌍 Langue :

* 🇫🇷 Français
* 🇬🇧 [English](../en/ai-providers.md)

---

## Vue d’ensemble

Secure RAG Agent supporte plusieurs providers IA via une couche d’abstraction.

L’objectif est de rendre le système **indépendant du provider**, afin de pouvoir basculer facilement entre cloud et local.

---

## Providers supportés (MVP)

* OpenAI (cloud)
* Ollama (local)

---

## Architecture

```text
Couche Application
   ↓
ILlmProvider / IEmbeddingProvider
   ↓
Couche Infrastructure
   ↓
Implémentations OpenAI / Ollama
```

---

## Interfaces principales

### ILlmProvider

Responsable de la génération de texte :

```csharp
Task<LlmChatResponse> ChatAsync(...)
```

---

### IEmbeddingProvider

Responsable de la génération d’embeddings :

```csharp
Task<EmbeddingResponse> EmbedAsync(...)
```

---

## Sélection du provider

Le provider actif est défini par configuration :

```json
"Ai": {
  "Provider": "OpenAI"
}
```

Valeurs supportées :

* OpenAI
* Ollama

---

## Provider OpenAI

### Caractéristiques

* Exécution cloud
* Haute qualité de réponse
* Suivi des tokens et du coût
* Utilise le SDK officiel OpenAI .NET

### Cas d’usage

* Environnement production
* Besoin de haute précision
* Scénarios d’évaluation

---

## Provider Ollama

### Caractéristiques

* Exécution locale
* Pas de dépendance API externe
* Coût réduit (pas de tokens facturés)
* Qualité variable selon modèle

### Cas d’usage

* Développement local
* Environnements sensibles (privacy)
* Optimisation des coûts

---

## Décisions de conception

### Abstraction des providers

La couche Application ne dépend d’aucun provider.

Cela permet :

* Changer de provider sans modifier le code métier
* Tester en local
* Ajouter facilement d’autres providers

---

### Isolation Infrastructure

Les types OpenAI ou Ollama ne doivent jamais apparaître hors Infrastructure.

---

### Configuration centralisée

Le choix du provider est entièrement piloté par la configuration.

---

## Limites MVP

* Pas de retry automatique
* Pas de streaming
* Pas de batch
* Pas de fallback multi-provider
* Pas de gestion du rate limiting

---

## Améliorations futures

* Ajout de retry / résilience
* Support du streaming
* Fallback multi-provider
* Observabilité par provider
* Optimisation des coûts
