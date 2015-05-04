﻿// This program is a private software, based on c# source code.
// To sell or change credits of this software is forbidden,
// except if someone approve it from MANAGER INC. team.
//  
// Copyrights (c) 2014 MANAGER INC. All rights reserved.

using System;
using System.Data;
using System.Data.SqlClient;

using Connection;

namespace ConnectionGit
{
    internal sealed class ConnectionSqlServer : Connection
    {
        private static SqlConnection _connection;
        private static Boolean _connectionIsStarted;

        private ConnectionSqlServer()
        {
            _connection = new SqlConnection(Const.connectionString);
            _connection.Open();
            _connectionIsStarted = true;
        }

        private static SqlConnection GetConnection()
        {
            if (!_connectionIsStarted)
            {
                new ConnectionSqlServer();
            }
            return _connection;
        }

        public new static IDbCommand Command(string query)
        {
            return new SqlCommand { Connection = GetConnection(), CommandText = query };
        }

        public new static IDbCommand CommandStored(string query)
        {
            return new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = GetConnection(), CommandText = query };
        }
    }
}