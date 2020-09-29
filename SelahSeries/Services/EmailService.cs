using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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


            var client = SetupClient();
                    
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
                    finally
                    {
                    client.Dispose();
                    }


               }
                
                await Task.CompletedTask;
            
        
        }
        
        public void SendSubscriptionMail(List<String> emailSubscribers, string title, string message, int postId, string imagePath)
        {
            var client = SetupClient();
            
            var mailMessage = SetupMailMessage(title,message,imagePath,postId);
            
            var senderEmail = _configuration["Email:Email"];
            mailMessage.From = new MailAddress(senderEmail, "Selah Series");

            
            try
            {
                foreach (var emailSubscriber in emailSubscribers)
                {
                    mailMessage.Bcc.Add(emailSubscriber);
                }
                client.Send(mailMessage);

            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
                mailMessage.Dispose();
            }

        }
        private SmtpClient SetupClient()
        {
            var client = new SmtpClient();

            client.UseDefaultCredentials = false;
            var credential = new NetworkCredential
            {
                UserName = _configuration["Email:Email"],
                Password = _configuration["Email:Password"]
            };

            client.Credentials = credential;
            client.Host = _configuration["Email:Host"];
            client.Port = int.Parse(_configuration["Email:Port"]);
            client.EnableSsl = false;
            return client;
        }

        private MailMessage SetupMailMessage(string title, string message, string imagePath,int postId)
        {
           var mailMessage = new MailMessage();
                
           mailMessage.Subject = $"Selah Series Has a New Post: {title}";
                
            Stream fs = File.Open(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            LinkedResource res = new LinkedResource(fs, new ContentType("image/bmp"));

                res.ContentId = Guid.NewGuid().ToString();
                string htmlBody = $@"<html>
                      <body>
                      <h3> {title} </h3>
                        <div>
                           <img src='cid:{res.ContentId}' alt='{title}' width='400' height='300'/>
                            <p>  {message} <a href='https://www.selahseries.com/blog/post/{postId}' style='text-decoration:none;'> read more... </a></p>
                            
                       </div>
                     
                            <a href='https://www.selahseries.com/subscription/unsubscribe/'> Unsubscribe </a>                        
                        </body>
                      </html>
                     ";

                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(res);
                mailMessage.AlternateViews.Add(alternateView);
                mailMessage.IsBodyHtml = true;

                return mailMessage;
            }

        }
}

