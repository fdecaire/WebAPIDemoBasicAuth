using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp;
using System.Data.Linq;
using Newtonsoft.Json;

namespace DatabaseTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var request = new ClassAPIRoomRequest
			{
				
			};

			//var jsondata = JsonConvert.SerializeObject(request);

			var classRoomReservationList = new ClassRoomReservationList(request);

			foreach (var item in classRoomReservationList.ReservedRoomList)
			{
				Console.WriteLine(item.Name + " " + item.RoomNumber + " " + (item.Reserved ? "Reserved" : ""));
			}
			Console.ReadKey();
		}
	}
}
