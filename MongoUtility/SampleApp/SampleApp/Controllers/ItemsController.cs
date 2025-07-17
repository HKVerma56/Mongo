using MongoUtility;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly MongoDbUtility _mongoDbUtility;
        private const string CollectionName = "items";

        public ItemsController()
        {
            // For demo: use local MongoDB, database 'testdb'
            _mongoDbUtility = new MongoDbUtility("mongodb://localhost:27017", "testdb");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var filter = Builders<Item>.Filter.Empty;
            var items = _mongoDbUtility.FindDocuments(CollectionName, filter);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);
            var items = _mongoDbUtility.FindDocuments(CollectionName, filter);
            return Ok(items.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _mongoDbUtility.InsertDocument(CollectionName, item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Item item)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);
            var update = Builders<Item>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Value, item.Value);
            var result = _mongoDbUtility.UpdateDocuments(CollectionName, filter, update);
            return Ok(result.ModifiedCount);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);
            var result = _mongoDbUtility.DeleteDocuments(CollectionName, filter);
            return Ok(result.DeletedCount);
        }
    }

    public class Item
    {
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; }
    }
}
