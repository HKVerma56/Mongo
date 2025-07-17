# MongoUtility

A reusable C# class library for basic and advanced MongoDB operations, including single/bulk insert, find, update, delete, and aggregate. Easily integrate this utility into any C# project.

## Features
- Insert single or multiple documents
- Find documents with filters
- Update documents
- Delete documents
- Aggregate queries

## Getting Started

### Prerequisites
- .NET 6.0 or later
- MongoDB server (local or remote)

### Setup
1. Clone this repository or copy the `MongoUtility` project into your solution.
2. Add a reference to `MongoUtility` from your main project (e.g., web app, console app).
3. Install the MongoDB.Driver NuGet package if not already present:
   ```sh
   dotnet add package MongoDB.Driver
   ```

### Usage Example
```
csharp
using MongoUtility;
using MongoDB.Driver;

// Initialize utility
var mongoUtil = new MongoDbUtility("mongodb://localhost:27017", "YourDatabaseName");

// Insert a document
mongoUtil.InsertDocument("YourCollection", new YourModel { /* ... */ });

// Find documents
var filter = Builders<YourModel>.Filter.Eq(x => x.Property, "value");
var results = mongoUtil.FindDocuments("YourCollection", filter);

// Update documents
var update = Builders<YourModel>.Update.Set(x => x.Property, "newValue");
mongoUtil.UpdateDocuments("YourCollection", filter, update);

// Delete documents
mongoUtil.DeleteDocuments("YourCollection", filter);

// Aggregate
var pipeline = new EmptyPipelineDefinition<YourModel>()
    .Match(filter)
    .Group(new BsonDocument { { "_id", "$Property" }, { "count", new BsonDocument("$sum", 1) } });
var aggregateResults = mongoUtil.Aggregate<YourModel, BsonDocument>("YourCollection", pipeline);
```

