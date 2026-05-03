# Document Ingestion

🌍 Language:
- 🇬🇧 English (default)
- 🇫🇷 [Français](../fr/ingestion.md)

---

## Overview

The ingestion pipeline transforms raw documents into searchable vector data.

---

## MVP Pipeline

1. Read document content
2. Split text into chunks
3. Generate embeddings
4. Store chunks and embeddings in PostgreSQL + pgvector
5. Attach RBAC permissions to the document
6. Mark the document as indexed

---

## MVP Scope

The MVP currently supports:

- Plain text documents
- Simple fixed-size chunking
- One embedding per chunk
- Role-based document permissions
- PostgreSQL + pgvector storage

---

## Embedding Dimension Decision

For the MVP, the vector dimension is set to:

```text
vector(768)

Reason:

Ollama nomic-embed-text returns 768-dimensional embeddings.
The project currently prioritizes local development with Ollama.
OpenAI support remains available, but multi-dimension support will be handled later.
Current Limitation

The MVP does not yet support:

PDF parsing
OCR
advanced chunking
async ingestion jobs
multi-provider embedding dimensions
document versioning
Future Improvements
PDF and Markdown parsing
smarter chunking by sections/titles
background ingestion jobs
embedding model validation
multi-dimension strategy for OpenAI/Ollama
ingestion status dashboard
