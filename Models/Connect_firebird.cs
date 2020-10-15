using System;
using FirebirdSql.Data.FirebirdClient;

namespace Cremeria.Models
{
	public abstract class Connect_firebird : IDisposable
	{

		
		FbConnection db = new FbConnection(@"Server=localhost;User=SYSDBA;Password=aioros;Database=C:\Program Files\Firebird\Firebird_3_0\examples\empbuild\EMPLOYEE.FDB");
		public void Dispose()
		{

			db.Close();
		}
		private FbDataReader OpenConnection(string query)
		{
			try
			{
				if (db.State == System.Data.ConnectionState.Open)
				{
					db.Close();
				}
				db.Open();
				FbCommand commandDatebase = new FbCommand(query,db);
				return commandDatebase.ExecuteReader();
			}catch(Exception ex)
			{
				throw ex;
			}
		}

		public FbDataReader Runquey(string query)
		{
			try
			{
				return OpenConnection(query);

			}catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
