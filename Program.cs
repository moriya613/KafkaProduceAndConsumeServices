using Confluent.Kafka;
using Kafka.Public;
using Kafka.Public.Loggers;
using KafkaConsumer_LSPorts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureServices((context, collection) =>
        {
            collection.AddHostedService<KafkaConsumerHostedService>();
            collection.AddHostedService<KafkaProducerHostedService>();


        });   
}

   