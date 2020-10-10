using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SelahSeries.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
 
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string subject, string message)
        {
            

                using (var client = new SmtpClient())
                {
                client.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = _configuration["Email:Email"],
                        Password = _configuration["Email:Password"]
                    };

                    client.Credentials = credential;
                    client.Host = _configuration["Email:Host"];
                    client.Port = int.Parse(_configuration["Email:Port"]);
                    client.EnableSsl = true;
                    
                   using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(_configuration["Email:Email"]));
                        emailMessage.From = (new MailAddress(_configuration["Email:Email"]));
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                    try
                    {
                        client.Send(emailMessage);

                    }catch(SmtpException ex)
                    {
                        throw ex;
                    }


                    }
                }
                await Task.CompletedTask;
            
        
        }

        public async Task SendEmailTo(string subject, string message, string toEmail)
        {


            using (var client = new SmtpClient())
            {
                client.UseDefaultCredentials = false;
                var credential = new NetworkCredential
                {
                    UserName = _configuration["Email:Email"],
                    Password = _configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = _configuration["Email:Host"];
                client.Port = int.Parse(_configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(toEmail));
                    emailMessage.From = (new MailAddress(_configuration["Email:Email"]));
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    try
                    {
                        client.Send(emailMessage);

                    }
                    catch (SmtpException ex)
                    {
                        throw ex;
                    }


                }
            }
            await Task.CompletedTask;


        }
    }
}

