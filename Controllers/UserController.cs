using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWeb.Dominio;
using RestApiWeb.Models;
namespace RestApiWeb.Controllers
{
    public class UserController : ApiController
    {
        // GET api/values
        [Route("api/user/v1/GetObtenerDatos")]
        [HttpGet]
        public HttpResponseMessage GetObtenerDatos()
        {
            try {
                Usuarios usuario = new Usuarios();
                return Request.CreateResponse(HttpStatusCode.OK, usuario, Configuration.Formatters.JsonFormatter);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        
        }

        [Route("api/user/v1/RegistraUser")]
        [HttpPost]
        public HttpResponseMessage RegistraUser(User user)
        {
            DResponseMsg msg = new DResponseMsg();
            try
            {
                DUser usuario = new DUser();               
                string resultado = usuario.GuardarUser(user.Username);
                msg.status = (int)HttpStatusCode.OK;
                msg.msg = resultado;
            }
            catch (Exception ex)
            {

                msg.status = (int)HttpStatusCode.InternalServerError;
                msg.msg = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, msg, Configuration.Formatters.JsonFormatter);
        }



    }
}
