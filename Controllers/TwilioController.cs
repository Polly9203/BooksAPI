using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string messageText, string phoneNumber)
        {
            var accountSid = "AC1d827686a2b4f75978ed0695ff0bf696";
            var authToken = "e045dedbe80b3fac5328e3dbf425b84d";

            TwilioClient.Init(accountSid,authToken);

            var message = MessageResource.Create
            (
                body: messageText,
                from: new Twilio.Types.PhoneNumber("+17036344743"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );

            return Ok(message);
        }
    }
}
