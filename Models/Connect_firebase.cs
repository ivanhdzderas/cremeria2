using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cremeria.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace Cremeria.Models
{
	public abstract  class Connect_firebase
	{
		IFirebaseConfig config = new FirebaseConfig();

		public IFirebaseClient cliente;

		public void conetar(string xml)
		{
			config.AuthSecret = "b0XxnSJaXkbSpqaI9OTw7udzNOnUCacbEXSgSBvV";
			config.BasePath = "https://prueba-c-64168.firebaseio.com/";
			cliente = new FireSharp.FirebaseClient(config);


			if (cliente != null)
			{
				MessageBox.Show("entrado");
			}

			
		}

	}
}
