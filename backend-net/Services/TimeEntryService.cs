using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public interface ITimeEntryService
{
    IEnumerable<TimeEntry> GetTimeEntries(string? userId, string? projectId, string? from, string? to);
}

public sealed class TimeEntryService(MockStore store) : ITimeEntryService
{
    public IEnumerable<TimeEntry> GetTimeEntries(string? userId, string? projectId, string? from, string? to)
    {
        IEnumerable<TimeEntry> data = store.TimeEntries;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            data = data.Where(entry => entry.UserId == userId);
        }

        if (!string.IsNullOrWhiteSpace(projectId))
        {
            data = data.Where(entry => entry.ProjectId == projectId);
        }

        if (!string.IsNullOrWhiteSpace(from))
        {
            data = data.Where(entry => string.CompareOrdinal(entry.Date, from) >= 0);
        }

        if (!string.IsNullOrWhiteSpace(to))
        {
            data = data.Where(entry => string.CompareOrdinal(entry.Date, to) <= 0);
        }

        return data;
    }
}
