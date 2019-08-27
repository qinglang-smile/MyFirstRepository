using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace MailKitDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            try
            {
                var authenticationCode = RandomNumbers();
                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //收件人邮箱
                message.To.Add(new MailboxAddress("18476686118@139.com"));
                //发件人邮箱
                message.From.Add(new MailboxAddress(_config["EmailDeliveryOptions:MailFromName"], _config["EmailDeliveryOptions:MailFromAddress"]));
                //E-mail subject 
                message.Subject = "LQQ Test";
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = $"您好！您的验证码为 { authenticationCode },有效期为2分钟 "
                };

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                    await emailClient.ConnectAsync(_config["EmailDeliveryOptions:ServerHost"],Convert.ToInt32(_config["EmailDeliveryOptions:ServerSslPort"]), Convert.ToBoolean(_config["EmailDeliveryOptions:UseSsl"]));
                    await emailClient.AuthenticateAsync(_config["EmailDeliveryOptions:LoginName"], _config["EmailDeliveryOptions:Password"]);
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }

            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// 生成随机数字(默认6位)
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomNumbers(int length = 6)
        {
            var sb = new StringBuilder();
            var random = new Random();

            do
            {
                var rand = random.Next(0, 10);
                sb.Append(rand);
            } while (sb.Length < length);

            return sb.ToString();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
