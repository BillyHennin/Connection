// This program is a private software, based on c# source code.
// To sell or change credits of this software is forbidden,
// except if someone approve it from MANAGER INC. team.
//  
// Copyrights (c) 2014 MANAGER INC. All rights reserved.

using System.Data;

namespace Connection
{
    internal sealed class ConnectionMySql : Connection
    {
        private static MySqlConnection _connection;

        private static void MySql()
        {
            _connection = new MySqlConnection(Const.connectionString);
            _connection.Open();
            ConnectionIsStarted = true;
        }

        private static MySqlConnection GetConnection()
        {
            if (!ConnectionIsStarted)
            {
               MySql();
            }
            return _connection;
        }

        public new static IDbCommand Command(string query)
        {
            return new MySqlCommand { Connection = GetConnection(), CommandText = query };
        }

        public new static IDbCommand CommandStored(string query)
        {
            return new MySqlCommand { CommandType = CommandType.StoredProcedure, Connection = GetConnection(), CommandText = query };
        }
    }
}