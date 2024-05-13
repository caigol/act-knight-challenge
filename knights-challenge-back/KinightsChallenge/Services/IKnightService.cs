using KinightsChallenge.Models;

namespace KinightsChallenge.Services
{
    public interface IKnightService
    {
        Task<IEnumerable<Knight>> GetAllKnightsAsync();
        Task<IEnumerable<Knight>> GetHeroKnightsAsync();
        Task<Knight> GetKnightByIdAsync(string id);
        Task<Knight> CreateKnightAsync(Knight knight);
        Task<bool> DeleteKnightAsync(string id);
        Task<Knight> UpdateKnightAsync(string id, Knight knight);
    }
}
