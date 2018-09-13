using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteServer.Models;
using System.Web.Script.Services;

namespace NoteServer.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public User Get(int id)
        {
            User user = new User();

            return user;
        }

        // POST: api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User value)
        {
            bool recordExisted = false;
            UserPercistance pp = new UserPercistance();
            recordExisted = pp.saveUser(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.Found);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.Created);

            }
            return response;

        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]User value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }

        [Route("api/login")]
        [HttpPost]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public HttpResponseMessage checkLogin([FromBody]User value)
        {
            bool recordExisted = false;
            HttpResponseMessage response;
            UserPercistance pp = new UserPercistance();
            recordExisted = pp.checkLogin(value.username, value.password);
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);

            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);

            }
            return response;
        }

    }

    
}
