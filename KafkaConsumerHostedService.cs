﻿using Kafka.Public.Loggers;
using Kafka.Public;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace KafkaConsumer_LSPorts
{
    public class KafkaConsumerHostedService : IHostedService
    {
        private ILogger<KafkaConsumerHostedService> _logger;
        private ClusterClient _cluster;

        public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger)
        {
            _logger = logger;
            _cluster = new ClusterClient(new Configuration
            {
                Seeds = "localhost:9092"
            }, new ConsoleLogger());
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cluster.ConsumeFromLatest("LSports");
            _cluster.MessageReceived += record =>
            {
                _logger.LogInformation($"Recived {Encoding.UTF8.GetString(record.Value as byte[])}");
            };
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cluster?.Dispose();
            return Task.CompletedTask;
        }
    }
}
