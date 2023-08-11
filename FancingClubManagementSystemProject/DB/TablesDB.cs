using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancingClubManagementSystemProject.DB
{
    internal class TablesDB
    {
        Connector connector;
        private NpgsqlCommand cmd;

        public TablesDB(Connector connector) 
        { 
            this.connector = connector;
        }
        public async Task CreateTableUser()
        {
            var sql = $"CREATE TABLE if not exists Users " +
                $"(" +
                $"idUser serial PRIMARY KEY, " +
                $"name VARCHAR (100) NOT NULL, " +
                $"login VARCHAR (100) NOT NULL, " +
                $"password VARCHAR (100) NOT NULL, " +
                $"dateCreated timestamp " +
                $")";

            cmd = new NpgsqlCommand(sql, connector.con);

            await cmd.ExecuteNonQueryAsync();

        }
    }
}
