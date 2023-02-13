using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface ILogService
    {
        Task<int> LogException(string method, Exception exception);
    }
}
