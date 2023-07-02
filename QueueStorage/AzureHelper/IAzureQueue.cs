using System.Threading.Tasks;

namespace AzureHelper
{
    public interface IAzureQueue
    {
        Task<T> GetMessage<T>();
        Task SendMessage(string message, int delaySeconds = 10, int TTLSeconds = 15);
    }
}