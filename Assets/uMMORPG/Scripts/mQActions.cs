using Newtonsoft.Json;
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
        private IModel _channel;
        public mQActions(IModel channel)
        {
            _channel = channel;
        }

        public void sendObject(string queue, string exchange, object data)
        {
            try
            {
                _channel.QueueDeclare(queue: queue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                var message = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = _channel.CreateBasicProperties();
                properties.SetPersistent(true);

                _channel.BasicPublish(exchange: exchange,
                                     routingKey: queue,
                                     basicProperties: properties,
                                     body: body);
                Debug.Log(String.Format(" [MQ] Sent {0}", message));
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            
        }
    }
}
