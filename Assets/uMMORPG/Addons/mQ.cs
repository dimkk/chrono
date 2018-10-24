using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mQ
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
        }
        else
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