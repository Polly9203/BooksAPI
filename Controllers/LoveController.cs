using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BooksAPI.Models;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoveController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLoveStats(string fname, string sname)
        {
            if (fname == null || sname == null)
            {
                return BadRequest();
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://love-calculator.p.rapidapi.com/getPercentage?fname={fname}&sname={sname}"),
                Headers =
                {
                    { "x-rapidapi-key", "72698e36cemshc098e0c3758b8dfp10a0a0jsne6a2328d933c" },
                    { "x-rapidapi-host", "love-calculator.p.rapidapi.com" },
                },
            };
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var answer = JsonConvert.DeserializeObject<LoveAnswer>(body);
            return Ok(answer);
        }
    }
}