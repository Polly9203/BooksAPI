using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Newtonsoft.Json;
using System.Net.Http;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            TwilioClient.Init("AC1d827686a2b4f75978ed0695ff0bf696", "e045dedbe80b3fac5328e3dbf425b84d");

            var message = MessageResource.Create
            (
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+17036344743"),
                to: new Twilio.Types.PhoneNumber("+375291754988")
            );

            return Ok(message);
        }
    }
}
