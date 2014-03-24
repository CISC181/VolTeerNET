using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.IO;


namespace VolTeer.App_Code
{
    public class cMail
    {
        public static void SendMessage(string fromEmail, string toEmail, string subject, string body)
        {
            MailMessage message = new MailMessage(
               fromEmail,
               toEmail,
               subject,
               body);

            message.IsBodyHtml = true;

            var section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = section.Network.Host.ToString();
            client.Port = section.Network.Port;
            client.EnableSsl = section.Network.EnableSsl;
            client.Credentials = new System.Net.NetworkCredential(section.Network.UserName.ToString(), section.Network.Password.ToString());

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static string PopulateBody(string TemplateLoc, string[,] MergeValues)
        {
            
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(TemplateLoc)))
            {
                body = reader.ReadToEnd();
            }

            for (int i = 0; i < MergeValues.Length-1; i++)
            {
                body = body.Replace(MergeValues[i, 0], MergeValues[i, 1]);
            } 

            return body;
        }

    }
}