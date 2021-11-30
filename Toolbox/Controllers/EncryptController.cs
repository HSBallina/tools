using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Toolbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        [HttpGet]
        public string Get(string s = null)
        {
            return s == null ? "Usage: encrypt?s=[string to sign]" : GenerateSign(s);
        }

        private static string GenerateSign(string signString)
        {
            using var sha384Hash = SHA384.Create();
            
            var sourceBytes = Encoding.UTF8.GetBytes(signString);
            var hashBytes = sha384Hash.ComputeHash(sourceBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", "");

            return hash.ToLower();
        }

    }
}
