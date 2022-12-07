using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KafkaConsumer_LSPorts
{
    public class KafkaProducerHostedService : IHostedService
    {
        private readonly ILogger<KafkaProducerHostedService> _logger;
        private IProducer<Null, string> _producer;

        public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
        {
            _logger = logger;
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092",
                EnableIdempotence = true // This will make sure the messages are senting in the right order

            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (string value in JsonUtils.GetListOfMessagesFromFile())
            {
                await _producer.ProduceAsync("LSports", new Message<Null, string> { Value = value }, cancellationToken);
                _logger.LogInformation($"Produce message '{value}");

            }
            _producer.Flush(TimeSpan.FromSeconds(10));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
