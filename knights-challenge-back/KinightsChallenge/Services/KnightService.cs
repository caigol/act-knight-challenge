using KinightsChallenge.Models;
using MongoDB.Driver;

namespace KinightsChallenge.Services
{
    public class KnightService : IKnightService
    {
        private readonly IMongoCollection<Knight> _knightsCollection;

        public KnightService(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration["MongoDBSettings:DatabaseName"];
            var collectionName = configuration["MongoDBSettings:CollectionName"];
            var database = mongoClient.GetDatabase(databaseName);
            _knightsCollection = database.GetCollection<Knight>(collectionName);
        }

        public async Task<IEnumerable<Knight>> GetAllKnightsAsync()
        {
            return await _knightsCollection.Find(knight => true).ToListAsync();
        }

        public async Task<IEnumerable<Knight>> GetHeroKnightsAsync()
        {
            return await _knightsCollection.Find(knight => knight.Attributes.Charisma > 10).ToListAsync();
        }

        public async Task<Knight> GetKnightByIdAsync(string id)
        {
            return await _knightsCollection.Find<Knight>(knight => knight.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Knight> CreateKnightAsync(Knight knight)
        {
            await _knightsCollection.InsertOneAsync(knight);
            return knight;
        }

        public async Task<bool> DeleteKnightAsync(string id)
        {
            var result = await _knightsCollection.DeleteOneAsync(knight => knight.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<Knight> UpdateKnightAsync(string id, Knight knight)
        {
            await _knightsCollection.ReplaceOneAsync(k => k.Id == id, knight);
            return knight;
        }
    }
}
