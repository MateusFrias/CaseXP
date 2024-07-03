using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CaseXP.ConsoleApp.AlertaVencimentoProdutos.Service
{
    internal class EmailService
    {
        private SmtpSender CreateSender()
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential ("mateusmfrias@live.com", "#Spititout123")
                //DeliveryMethod = SmtpDeliveryMethod.Network,
                //Port = 25
            });

            return sender;
        }

        public async void SendEmail(string to, string subject, string body)
        {
            try
            {
                
                Email.DefaultSender = CreateSender();

                var email = await Email
                    .From("mateusmfrias@live.com")
                    .To(to)
                    .Subject(subject)
                    .Body(body)
                    .SendAsync();
            }
            catch (Exception ex) {
                Console.WriteLine("Exceção no envio de e-mail: " + ex.Message);
            }

        }
    }
}
