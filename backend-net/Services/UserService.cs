using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public interface IUserService
{
    IEnumerable<User> GetUsers(string? orgId, string? role, string? active);
    User? GetUser(string id);
}

public sealed class UserService(MockStore store) : IUserService
{
    public IEnumerable<User> GetUsers(string? orgId, string? role, string? active)
    {
        IEnumerable<User> data = store.Users;

        if (!string.IsNullOrWhiteSpace(orgId))
        {
            data = data.Where(user => user.OrgId == orgId);
        }

        if (!string.IsNullOrWhiteSpace(role))
        {
            data = data.Where(user => user.Role == role);
        }

        if (active is not null)
        {
            data = data.Where(user => user.Active == (active == "true"));
        }

        return data;
    }

    public User? GetUser(string id) =>
        store.Users.FirstOrDefault(candidate => candidate.Id == id);
}
