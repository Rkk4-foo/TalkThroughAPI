namespace TalkThroughAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string username, int expireHours = 2);

    }
}
