using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public abstract class ConnectOtherDb: IDisposable
	{
		MySqlConnection databaseConnection = null;
		public void Dispose()
		{

			databaseConnection.Close();
		}
        private MySqlDataReader OpenConnection(string query, string connect)
        {

            databaseConnection = new MySqlConnection(connect);
            try
            {

                if (databaseConnection.State == System.Data.ConnectionState.Open)
                {

                    databaseConnection.Close();
                }


                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                //commandDatabase.CommandTimeout = 60;
                return commandDatabase.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public MySqlDataReader runQuery(string query, string conecction)
        {
            try
            {
                return OpenConnection(query, conecction);
            }
            catch (MySqlException ex)
            {
                throw ex;

            }

        }
    }
}
