using System.Data;
using BookStore.Data.Abstraction;
using BookStore.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BookStore.Data.MongoDB;

public class Database : IDatabase
{
    private readonly MongoClient client;
    private readonly IMongoDatabase db;

    public Database(IDatabaseConfiguration configuration)
    {
        RegisterCustomMappings();
        
        client = new MongoClient(configuration.ConnectionString);
        db = client.GetDatabase(configuration.DatabaseName);
    }

    public TCollection GetCollection<TCollection, TItem>(string collectionName) where TCollection : class
    {
        return db.GetCollection<TItem>(collectionName) as TCollection ?? throw new NoNullAllowedException();
    }

    private void RegisterCustomMappings()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Book)))
        {
            BsonClassMap.RegisterClassMap<Book>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(book => book.Id)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                
                cm.AutoMap();
                cm.MapMember(book => book.AuthorId)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
                
                cm.AutoMap();
                cm.MapMember(
                        book => book.PublisherId)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.SetIgnoreExtraElements(true);
                
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}