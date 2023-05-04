using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class PostModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ImgURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public PostModel()
        {
        }

        public PostModel(string id, string imgURL, string title, string description, string category)
        {
            Id = id;
            ImgURL = imgURL;
            Title = title;
            Description = description;
            Category = category;
        }

    }
}
