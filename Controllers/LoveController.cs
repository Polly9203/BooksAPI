using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult GetLoveStats(string fname, string sname)
        {
            if (fname == null || sname == null)
            {
                return BadRequest();
            }

            var client = new RestClient("https://love-calculator.p.rapidapi.com/getPercentage?fname=" + fname + "&sname=" + sname);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "{x-rapidapi-key}");
            request.AddHeader("x-rapidapi-host", "love-calculator.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            Answer answer = JsonConvert.DeserializeObject<Answer>(response.Content);

            return Ok(answer);
        }
    } 
}