using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoUtility
{
    public class MongoDbUtility
    {
        private readonly IMongoDatabase _database;

        public MongoDbUtility(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Example: Insert a document
        public void InsertDocument<T>(string collectionName, T document)
        {
            var collection = _database.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        // Bulk insert documents
        public void InsertDocuments<T>(string collectionName, IEnumerable<T> documents)
        {
            var collection = _database.GetCollection<T>(collectionName);
            collection.InsertMany(documents);
        }

        // Example: Find documents
        public List<T> FindDocuments<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return collection.Find(filter).ToList();
        }

        // Aggregate operation
        public List<TResult> Aggregate<T, TResult>(string collectionName, PipelineDefinition<T, TResult> pipeline)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return collection.Aggregate(pipeline).ToList();
        }

        // Update documents
        public UpdateResult UpdateDocuments<T>(string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return collection.UpdateMany(filter, update);
        }

        // Delete documents
        public DeleteResult DeleteDocuments<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = _database.GetCollection<T>(collectionName);
            return collection.DeleteMany(filter);
        }
    }
}
