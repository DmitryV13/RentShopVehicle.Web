using RentShopVehicle.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class EmailSenderS: IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //Password_from_my_app
            //PswF_0rExsrS
            //vUMT8pw43jznB8aE2aWu
            var mail = "rentshopvehicle.webapplication@mail.ru";
            var psw = "vUMT8pw43jznB8aE2aWu";
            var client = new SmtpClient("smtp.mail.ru", 465)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail, psw),
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
