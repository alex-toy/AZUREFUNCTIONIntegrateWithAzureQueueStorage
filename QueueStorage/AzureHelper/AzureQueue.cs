using Azure;
using Azure.Identity;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureHelper
{
    public class AzureQueue : IAzureQueue
    {
        private readonly QueueClient _queue;

        public AzureQueue(string connectionString, string queueName)
        {
            _queue = new QueueClient(connectionString, queueName);
        }

        public AzureQueue(Uri uri, DefaultAzureCredential credentials)
        {
            _queue = new QueueClient(uri, credentials);
        }

        public async Task SendMessage(string message, int delaySeconds = 10, int TTLSeconds = 15)
        {
            TimeSpan delay = TimeSpan.FromSeconds(delaySeconds);
            TimeSpan TTL = TimeSpan.FromSeconds(TTLSeconds);
            await _queue.SendMessageAsync(message, delay, TTL);
        }

        public async Task<T> GetMessage<T>()
        {
            Response<QueueMessage> response = await _queue.ReceiveMessageAsync();
            QueueMessage queueMessage = response.Value;

            if (queueMessage != null)
            {
                T data = JsonSerializer.Deserialize<T>(queueMessage.MessageText);
                await _queue.DeleteMessageAsync(queueMessage.MessageId, queueMessage.PopReceipt);
                return data;
            }

            return default(T);
        }
    }
}
