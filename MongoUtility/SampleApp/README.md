# SampleApp

This is an ASP.NET Core Web API project that demonstrates how to use the reusable `MongoDbUtility` class library for MongoDB operations (CRUD, bulk, aggregate, etc.).

## Structure
- `SampleApp/` - The web API project
- `MongoUtility/` - The MongoDB utility class library


## API Endpoints

### 1. Get all items
- **Method:** GET
- **URL:** http://localhost:5180/api/items

### 2. Get item by ID
- **Method:** GET
- **URL:** http://localhost:5180/api/items/{id}

### 3. Create a new item
- **Method:** POST
- **URL:** http://localhost:5180/api/items
- **Body (JSON):**
  ```json
  {
    "name": "Sample Item",
    "value": 123
  }
  ```

### 4. Update an item
- **Method:** PUT
- **URL:** http://localhost:5180/api/items/{id}
- **Body (JSON):**
  ```json
  {
    "id": "item_id_here",
    "name": "Updated Name",
    "value": 456
  }
  ```

### 5. Delete an item
- **Method:** DELETE
- **URL:** http://localhost:5180/api/items/{id}

You can use Postman, curl, or any HTTP client to test these endpoints.

---

## Getting Started
1. Ensure MongoDB is running locally.
2. Build the solution:
   ```
   dotnet build
   ```
3. Run the web API:
   ```
   dotnet run --project SampleApp/SampleApp.csproj
   ```
4. Use the API endpoints to perform MongoDB operations.

---

For more details, see the code and controllers in the `SampleApp` project.
