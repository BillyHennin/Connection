// This program is a private software, based on c# source code.
// To sell or change credits of this software is forbidden,
// except if someone approve it from MANAGER INC. team.
//  
// Copyrights (c) 2014 MANAGER INC. All rights reserved.

using System;
using System.Data;

namespace Connection
{
    internal sealed class ConnectionOracle : Connection
    {
        private static OracleConnection _connection;

        private static void Oracle()
        {
            _connection = new OracleConnection(Const.connectionString);
            _connection.Open();
            ConnectionIsStarted = true;
        }

        private static OracleConnection GetConnection()
        {
            if (!ConnectionIsStarted)
            {
                Oracle();
            }
            return _connection;
        }

        public new static IDbCommand Command(string query)
        {
            return new OracleCommand { Connection = GetConnection(), CommandText = query, BindByName = true };
        }

        public new static IDbCommand CommandStored(string query)
        {
            return new OracleCommand { CommandType = CommandType.StoredProcedure, Connection = GetConnection(), CommandText = query, BindByName = true };
        }
    }
}