﻿using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using AzureServiceBusAPI.Services;
using Microsoft.Extensions.Configuration;

namespace AzureServiceBusAPI.Services
{
    public class OrderBusService : IOrderBusService
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _queueName;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;
        private readonly ServiceBusProcessor _processor;

        public OrderBusService(IConfiguration configuration)
        {
            _serviceBusConnectionString = configuration["AzureServiceBus:ConnectionString"];
            _queueName = configuration["AzureServiceBus:QueueName"];
            _client = new ServiceBusClient(_serviceBusConnectionString);
            _sender = _client.CreateSender(_queueName);

            _processor = _client.CreateProcessor(_queueName, new ServiceBusProcessorOptions());
        }

        public async Task SendMessageAsync(string message)
        {
            ServiceBusMessage busMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(message));
            await _sender.SendMessageAsync(busMessage);
        }

        public async Task<string> ReceiveMessagesAsync()
        {
            string receivedMessage = string.Empty;
            _processor.ProcessMessageAsync += async args =>
            {
                string body = args.Message.Body.ToString();
                Console.WriteLine($"Received: {body}");
                receivedMessage = body;
                await args.CompleteMessageAsync(args.Message);
            };
            _processor.ProcessErrorAsync += args =>
            {
                Console.WriteLine($"Message handler encountered an exception: {args.Exception}");
                return Task.CompletedTask;
            };
            await _processor.StartProcessingAsync();
            await Task.Delay(500);
            await _processor.StopProcessingAsync(); return receivedMessage;
        }


        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Message handler encountered an exception: {args.Exception}");
            return Task.CompletedTask;
        }
    }
}
