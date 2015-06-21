using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
	public class VerifyCredentials 
	{
		public bool AuthorizeUser(string userId, string password)
		{
			//TODO: replace this hard-coded example with a database lookup
			if (userId == "MyUserName" && password == "RandomLongPassword")
			{
				return true;
			}

			return false;
		}
	}
}
