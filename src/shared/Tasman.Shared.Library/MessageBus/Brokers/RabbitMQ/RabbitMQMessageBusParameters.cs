namespace Tasman.Shared.Library.MessageBus.Brokers.RabbitMQ;

public record RabbitMQMessageBusParameters(string HostName, string UserName, string Password, string VirtualHost);