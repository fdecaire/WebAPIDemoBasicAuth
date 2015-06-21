using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var webApiRetreiver = new WebAPIRetriever();
			webApiRetreiver.JSONRetriever();
		}
	}
}
