using System;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public abstract class ConnectDB : IDisposable
    {

      
        MySqlConnection databaseConnection = new MySqlConnection(System.IO.File.ReadAllText(@"conn.txt"));
        public void Dispose() {

            databaseConnection.Close();
        }
        private MySqlDataReader OpenConnection(string query) {


			try{

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

        public MySqlDataReader runQuery(string query) {
            try
            {
                return OpenConnection(query);
            }
            catch (MySqlException ex)
            {
				throw ex;
                
            }
        
        }

    }


}
