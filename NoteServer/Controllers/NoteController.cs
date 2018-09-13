using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteServer.Models;
using System.Web.Script.Services;
using System.Collections;

namespace NoteServer.Controllers
{
    public class NoteController : ApiController
    {
        // GET: api/Note
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ArrayList Get()
        {
            NotePercistance note = new NotePercistance();
            return note.getNote();
     
        }

        // GET: api/Note/5
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        
        public ArrayList Get(String username)
        {
            NotePercistance note = new NotePercistance();
          
            return note.getNotebyId(username);
        }

        // POST: api/Note
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Note value)
        {
            bool recordExsisted = false;
            NotePercistance note = new NotePercistance();
            recordExsisted = note.saveNote(value);
            HttpResponseMessage response;

            if (recordExsisted) {

                response=Request.CreateResponse(HttpStatusCode.Found);
            }

            else

            {
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            return response;


        }

        // PUT: api/Note/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Note value)
        {
            NotePercistance pp = new NotePercistance();
            bool recordExisted = false;
            recordExisted = pp.updateNote(id,value);
            HttpResponseMessage response;

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

        // DELETE: api/Note/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            NotePercistance note = new NotePercistance();
            bool recordExsisted = false;
            recordExsisted = note.deleteNote(id);
            HttpResponseMessage response;

            if (recordExsisted)
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
