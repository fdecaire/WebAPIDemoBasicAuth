using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniversityApp;
using System.Configuration;
using System.Net;
using System.IO;

namespace WebAPITestConsole
{
	public class WebAPIRetriever
	{
		private readonly string apiURLLocation = ConfigurationManager.AppSettings["ApiURLLocation"];

		public void JSONRetriever()
		{
			var serializer = new JsonSerializer();

			var apiRequest = new ClassAPIRoomRequest
			{
				AllAvailable = true,
				AllReserved = false
			};

			//TODO: replace with database lookup
			string userId = "MyUserName";
			string storePassword = "RandomLongPassword";
			string apiAuthorization = "Basic " + (userId + ":" + storePassword).Base64Encode();

			var request = (HttpWebRequest)WebRequest.Create(apiURLLocation);
			request.ContentType = "application/json; charset=utf-8";
			request.Accept = "application/json";
			request.Method = "POST";
			request.Headers.Add(HttpRequestHeader.Authorization, apiAuthorization);
			request.UserAgent = "ClassAPIRoomRequest";

			//Writes the ApiRequest Json object to request 
			using (var streamWriter = new StreamWriter(request.GetRequestStream()))
			{
				streamWriter.Write(JsonConvert.SerializeObject(apiRequest));
				streamWriter.Flush();
			}

			var httpResponse = (HttpWebResponse)request.GetResponse();

			using (var streamreader = new StreamReader(httpResponse.GetResponseStream()))
			using (var reader = new JsonTextReader(streamreader))
			{
				ClassRoomReservationList classRoomReservationList = new ClassRoomReservationList();
				classRoomReservationList = serializer.Deserialize<ClassRoomReservationList>(reader);
			}
		}
	}
}
