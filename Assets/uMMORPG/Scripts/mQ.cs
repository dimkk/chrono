using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using UnityEngine;

namespace Assets.uMMORPG.Scripts
{
    class mQ
    {
        private ConnectionFactory _factory;
        private IConnection _conn;
        private IModel _channel;
        private bool initialized = false;

        public mQ(string address, string login, string password)
        {
            _factory = new ConnectionFactory() { HostName = address, UserName = login, Password = password };
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            initialized = true;
        }

        public IModel getChannel()
        {
            if (initialized)
            {
                return _channel;
            } else
            {
                throw new Exception("mq not initialized");
            }
        }

        public void off()
        {
            _conn.Dispose();
            _channel.Dispose();
        }

    }
}
