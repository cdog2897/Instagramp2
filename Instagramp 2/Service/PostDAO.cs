using ClassLibrary;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace Instagramp_2.Service
{
    public class PostDAO : IPostDAO
    {
        private readonly IMongoCollection<PostModel> _posts;

        public PostDAO()
        {
            var client = new MongoClient("mongodb+srv://Ace:squirty115@cluster0.og5dfyn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("insta-gramp-2");
            _posts = database.GetCollection<PostModel>("posts");
        }

       /* public PostModel DeserializePostModelFromBson(BsonDocument bsonDocument)
        {
            PostModel post = BsonSerializer.Deserialize<PostModel>(bsonDocument);
            // Check for null or empty Category property and initialize as empty list if null or empty
            if (post.Category == null)
            {
            }
            return post;
        }*/
        public async Task Create(PostModel post)
        {
            await _posts.InsertOneAsync(post);
        }

        public PostModel GetById(string id)
        {
            var filter = Builders<PostModel>.Filter.Eq(p => p.Id, id);
            return _posts.Find(filter).FirstOrDefault();
        }

        public List<PostModel> GetAll()
        {
            return _posts.Find(_ => true).ToList();
        }

        public void Update(string id, PostModel post)
        {
            var filter = Builders<PostModel>.Filter.Eq(p => p.Id, id);
            _posts.ReplaceOne(filter, post);
        }

        public void Delete(string id)
        {
            var filter = Builders<PostModel>.Filter.Eq(p => p.Id, id);
            _posts.DeleteOne(filter);
        }
    }
}
