namespace AzureServiceBusAPI.Services
{
   
        public interface IOrderBusService
        {
            // Method to send a message to the Azure Service Bus queue
            Task SendMessageAsync(string message);

        // Method to receive messages from the Azure Service Bus queue
        Task<string> ReceiveMessagesAsync();
        }
    }

