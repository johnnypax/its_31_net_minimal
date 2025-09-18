# Progetto C# .NET e REST API

Realizzare una tesina e un progetto pratico in .NET 8-9 Minimal API per dimostrare la comprensione dei principi delle REST API e la capacità di sviluppare un’applicazione funzionante.

### Parte 1 – Tesina teorica

Redigere un elaborato che contenga i seguenti punti:

- Definizione di REST API: principi fondamentali e caratteristiche.
- Confronto tra REST e altre architetture (SOAP, GraphQL).
- Metodi HTTP principali: GET, POST, PUT, DELETE (con esempi d’uso).
- Codici di stato HTTP più comuni.
- Autenticazione e sicurezza (API Key, JWT – anche solo a livello introduttivo).
- Documentazione delle API: OpenAPI/Swagger.

### Parte 2 – Progetto pratico

Sviluppare un’applicazione Minimal API in C# .NET 8 che soddisfi i seguenti requisiti:

### Requisiti obbligatori

- Definire **almeno 2 entità collegate** (esempi: Studente–Corso, Libro–Autore, Utente–Task).
- Implementare **operazioni CRUD complete** per entrambe le entità.
- Fornire **almeno un endpoint di ricerca o filtro** (es. tutti i corsi di uno studente, tutti i libri di un autore).
- (OPZIONALE) Utilizzare **SQLite e Entity Framework Core** (Code First).
- Documentare gli endpoint con **Swagger/OpenAPI**.

### Requisiti facoltativi (per un punteggio aggiuntivo)

- Validazione dei dati in input.
- Middleware personalizzato per logging o gestione errori.
- Autenticazione base

## Consegna

1. **Relazione scritta** (max 10 pagine) che includa:
   1. Parte teorica.
   2. Descrizione del progetto sviluppato.
   3. Documentazione degli endpoint con esempi di chiamata (Postman o curl).
   4. Diagramma UML delle entità.
2. **Repository GitHub** contenente:
   1. Codice sorgente del progetto (URL incluso nella tesina).