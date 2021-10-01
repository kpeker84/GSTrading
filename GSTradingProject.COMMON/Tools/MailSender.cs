using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.COMMON.Tools
{
    public class MailSender
    {
        public static void Send(string receiver, string password = "Gsr174Adm?*A", string body = "Test mesajıdır.", string subject = "E-mail testi", string sender = "info@greenstein.co")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            SmtpClient smtp = new SmtpClient()
            {
                Host = "mail.greenstein.co",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            //if (attachments != null)
            //{
            //    foreach (HttpPostedFileBase attachment in attachments)
            //    {
            //        if (attachment != null)
            //        {
            //            string fileName = Path.GetFileName(attachment.FileName);
            //            mail.Attachments.Add(new Attachment(attachment.InputStream, fileName));
            //        }
            //    }
            //}
            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
