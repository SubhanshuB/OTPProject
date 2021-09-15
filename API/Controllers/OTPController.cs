using GrowIndigo_Otp_Login_DemoProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Runtime.Caching;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowIndigo_Otp_Login_DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly OTPService _otpService;

        public OTPController(OTPService otpService)
        {
            _otpService = otpService;
        }

        // GET: api/<OTPController>
        [HttpGet("{value}")]
        public IActionResult Get(string value)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            string phonenumber = value;

            Random r = new Random();
            int rInt = r.Next(10000, 99999);

            //DateTime currentTime;

            var obj = _otpService.Get(phonenumber);

            if (obj != null)
            {
                rInt = obj.otp;
            }
            else
            {
                PhoneNumber _phone = new PhoneNumber();
                _phone.phonenumber = phonenumber;
                _phone.otp = rInt;
                _otpService.Create(_phone);
            }

            string text = rInt.ToString() + " is your OTP for GrowIndigo";

            string uri = "https://www.thetexting.com/rest/sms/json/Message/Send?api_key=cunqi5wy4tra0do&api_secret=79i8gjzsiptzgqd&from=THETXTNG&to=" + phonenumber + "&text=" + text + "&type=text";

            HttpResponseMessage result;
            try
            {
                result = client.PostAsync(uri, null).Result;
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // POST api/<OTPController>
        [HttpPost]
        public bool Post([FromBody] PhoneNumber obj)
        {
            var phonenumber = _otpService.Get(obj.phonenumber);
            bool ans = false;
            if(phonenumber != null)
                ans = phonenumber.otp == obj.otp;
            _otpService.Remove(obj);

            return ans;
        }

        // PUT api/<OTPController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OTPController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
