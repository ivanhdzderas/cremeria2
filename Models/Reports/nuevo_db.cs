using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cremeria.Models.Reports
{
	public class nuevo_db:ConnectDB
	{
		public void ejecuta(string query)
		{
			runQuery(query);

		}
	}
}
