using Azure.Storage.Queues;
using System;
using System.Threading.Tasks;

namespace AzureHelper
{
    public class AzureQueue
    {
        private readonly QueueClient _queue;

        public AzureQueue(string connectionString, string queueName)
        {
            _queue = new QueueClient(connectionString, queueName); 
        }

        public async Task SendMessage(string message, int delaySeconds = 10, int TTLSeconds = 15)
        {
            TimeSpan delay = TimeSpan.FromSeconds(delaySeconds);
            TimeSpan TTL = TimeSpan.FromSeconds(TTLSeconds);
            await _queue.SendMessageAsync(message, delay, TTL);
        }
    }
}
