using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using UniversityApp;
using System.Web.Cors;
using System.Web.Http.Controllers;

namespace WebAPI.Controllers
{
    public class ClassRoomController : ApiController
    {
		[HttpPost]
		[ActionName("GetClassRooms")]
		[UniversityBasicAuthentication]
		public HttpResponseMessage GetClassRooms([FromBody] ClassAPIRoomRequest request)
		{
			if (request == null)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request was null");
			}

			var classRoomReservationList = new ClassRoomReservationList(request);

			// convert the data into json
			var jsonData = JsonConvert.SerializeObject(classRoomReservationList);

			var resp = new HttpResponseMessage();
			resp.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			return resp;
		}
    }
}
