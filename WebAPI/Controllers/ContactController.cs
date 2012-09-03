using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactWebPack;

namespace WebAPI.Controllers
{
    public class ContactController : ApiController
    {
        public Contact[] _Contacts =
        {
            new Contact {FirstName = "Bob", LastName = "Brown"},
            new Contact {FirstName = "Mary", LastName = "Smith"},
            new Contact {FirstName = "Dave", LastName = "Wood"}
        };
        
        public HttpResponseMessage Get(int id)
        {
            var contact = _Contacts[id];
            
            return Request.CreateResponse(HttpStatusCode.OK, contact, Formatters.XML);
        }

        public HttpResponseMessage Post(Contact contact)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, contact); 
            return response;
        }
    }
}
