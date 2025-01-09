using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BDUgram.BL.Services.interfaces;

namespace BDUgram.BL.Services.implements
{
    public class EmailService : IEmailService
    {

        public void EmailConfirmation(string emailadress, string name)
        {
            SmtpClient smtp = new();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("cavidanbm-bp215@code.edu.az", "lvht hxma hwuq gouq");
            smtp.EnableSsl = true;
            MailAddress from = new MailAddress("cavidanbm-bp-215@code.edu.az", name);
            MailAddress to = new MailAddress(emailadress);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Confirm gmail";
            msg.Body = "confirm your gmail please  ";
            smtp.Send(msg);



        }

    }
}
