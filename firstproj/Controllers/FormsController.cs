using firstproj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace firstproj.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FormsController : ApiController
    {
        FormsDbService service = new FormsDbService();

        // GET: api/Forms
        public List<Form> Get()
        {
            return service.Get(); 
        }

        // GET: api/Forms/5
        public List<Field> Get(int id)
        {
            return service.Get(id);
        }

        // POST: api/Forms
        public void Post(ParticialForm f) { 
            service.insert(f);
        }

        // PUT api/Forms/5
        public void Put(int id, [FromBody]Form form)
        {
            service.update(id, form);
        }



    }
}
