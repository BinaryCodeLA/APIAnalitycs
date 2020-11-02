using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWeb.Dominio;
using RestApiWeb.Models;
using System.Web.Http.Cors;
namespace RestApiWeb.Controllers
{
    //[EnableCors(origins: "http://127.0.0.1:5500/", headers: "*", methods: "POST")]
    public class ContactController : ApiController
    {
        //[EnableCors(origins: "http://127.0.0.1:5500/", headers: "*", methods: "POST")]
        [Route("api/contact/v1/GuardaContacto")]
        [HttpPost]
        public HttpResponseMessage GuardaContacto(Contact collection)
        {
            DResponseMsg msg = new DResponseMsg();
            try
            {
                DContacto _contacto = new DContacto();

                string resultado = _contacto.GuardaContacto(collection);
                msg.status = (int)HttpStatusCode.OK;
                msg.msg = resultado;

            }
            catch(Exception ex)
            {
                msg.status = (int)HttpStatusCode.InternalServerError;
                msg.msg = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, msg, Configuration.Formatters.JsonFormatter);
        }
    }
}
