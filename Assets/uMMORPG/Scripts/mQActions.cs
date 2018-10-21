using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.uMMORPG.Scripts
{


    public class mQActions
    {

        public static void sendDict(IModel channel, string queue, IDictionary table)
        {
            channel.QueueDeclare(queue: queue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = table.ToString();
            var body = Encoding.UTF8.GetBytes(message);

            var properties = channel.CreateBasicProperties();
            properties.SetPersistent(true);

            channel.BasicPublish(exchange: "",
                                 routingKey: queue,
                                 basicProperties: properties,
                                 body: body);
            Debug.Log(String.Format(" [x] Sent {0}", message));
        }
    }

    public static class Exts
    {
        public static string ToString(this IDictionary source, string keyValueSeparator,
                                                       string sequenceSeparator)
        {
            if (source == null)
                throw new ArgumentException("Parameter source can not be null.");

            return source.Cast<DictionaryEntry>()
                         .Aggregate(new StringBuilder(),
                                    (sb, x) => sb.Append(x.Key + keyValueSeparator + x.Value
                                                          + sequenceSeparator),
                                    sb => sb.ToString(0, sb.Length - 1));
        }
    }
}
