# AI Providers — Secure RAG Agent

🌍 Language:

* 🇬🇧 English (default)
* 🇫🇷 [Français](../fr/ai-providers.md)

---

## Overview

The Secure RAG Agent supports multiple AI providers through an abstraction layer.

The goal is to ensure that the system remains **provider-agnostic**, allowing seamless switching between cloud and local models.

---

## Supported Providers (MVP)

* OpenAI (cloud)
* Ollama (local)

---

## Architecture

```text
Application Layer
   ↓
ILlmProvider / IEmbeddingProvider
   ↓
Infrastructure Layer
   ↓
OpenAI / Ollama implementations
```

---

## Core Interfaces

### ILlmProvider

Responsible for text generation:

```csharp
Task<LlmChatResponse> ChatAsync(...)
```

---

### IEmbeddingProvider

Responsible for embedding generation:

```csharp
Task<EmbeddingResponse> EmbedAsync(...)
```

---

## Provider Selection

The active provider is selected via configuration:

```json
"Ai": {
  "Provider": "OpenAI"
}
```

Supported values:

* OpenAI
* Ollama

---

## OpenAI Provider

### Characteristics

* Cloud-based
* High quality responses
* Token usage and cost tracking available
* Uses official OpenAI .NET SDK

### Use cases

* Production environments
* High accuracy requirements
* Evaluation scenarios

---

## Ollama Provider

### Characteristics

* Local execution
* No external API dependency
* Lower cost (no token billing)
* Lower quality compared to OpenAI (depending on model)

### Use cases

* Local development
* Privacy-sensitive environments
* Cost optimization

---

## Design Decisions

### Provider Abstraction

The Application layer does not depend on any specific AI provider.

This allows:

* Switching providers without code changes
* Testing with local models
* Future integration with other providers (Anthropic, Gemini, etc.)

---

### No Provider Leakage

OpenAI or Ollama types must not appear outside Infrastructure.

---

### Configuration-Driven

Provider selection is entirely driven by configuration, not code.

---

## Limitations (MVP)

* No retry policy yet
* No streaming support
* No batching
* No fallback provider strategy
* No rate limit handling

---

## Future Improvements

* Add retry and resilience policies
* Streaming responses
* Multi-provider fallback
* Observability (latency per provider)
* Cost optimization strategies
