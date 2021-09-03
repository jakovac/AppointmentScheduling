using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("ded5695d9167e2627a82e490cfa91b0d", "40135f2025b6583c2450ca5f5e096874")
            {

            };

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
           .Property(Send.FromEmail, "jakovac_milan@hotmail.com")
           .Property(Send.FromName, "Appointment Scheduler")
           .Property(Send.Subject, subject)
           .Property(Send.HtmlPart, htmlMessage)
           .Property(Send.Recipients, new JArray {
                 new JObject {
                  {"Email", email}
                  }
               });
            //MailjetClient client = new MailjetClient(Environment.GetEnvironmentVariable("ded5695d9167e2627a82e490cfa91b0d"), Environment.GetEnvironmentVariable("40135f2025b6583c2450ca5f5e096874"))
            //{
            //};
            //MailjetRequest request = new MailjetRequest
            //{
            //    Resource = Send.Resource,
            //}
            //   .Property(Send.Messages, new JArray {
            //    new JObject {
            //     {"From", new JObject {
            //      {"Email", "jakovac_milan@hotmail.com"},
            //      {"Name", "Appointment Scheduler"}
            //      }},
            //     {"To", new JArray {
            //      new JObject {
            //       {"Email", email},
            //       }
            //      }},
            //     {"Subject", subject},
            //     {"HTMLPart", htmlMessage}
            //     }
            //       });

            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
