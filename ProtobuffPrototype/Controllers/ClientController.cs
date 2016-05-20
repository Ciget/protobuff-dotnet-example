using System;
using System.Collections.Generic;
using System.Web.Http;
using ProtobuffPrototype.Models;
using ProtobuffPrototype.Models.Request;
using ProtobuffPrototype.Models.Response;

namespace ProtobuffPrototype.Controllers
{
    public class ClientController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public CreateClientResponse Post(CreateClientRequest model)
        {
            if (model != null)
            {
                return new CreateClientResponse
                {
                    Token = "SuperSecretData",
                    Status = ResponseStatus.Success
                };
            }

            return new CreateClientResponse
            {
                Status = ResponseStatus.Failed
            };
        }
    }
}
