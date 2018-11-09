using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TheChamaApp.Infra.CrossCutting.Util
{
    public class BaseMail
    {
        #region # Static Members
        public static string Smtp { get; set; }
        public static string From { get; set; }
        public static string Subject { get; set; }
        #endregion

        #region # Methods

        public static void Enviar(string[] Emails, string Body)
        {

        }

        #endregion

        private static void send()
        {
            IEnumerable<string> mails = new List<string>() { "hzjfj", "polivenok.k@gmail.com", "hjkjgfffff" };
            var exceptions = new ConcurrentQueue<Exception>();
            MailAddress address = null;
            Parallel.ForEach(mails, async (mail) =>
            {
                using (MailMessage message = new MailMessage()
                {
                    From = new MailAddress("huiko@gmail.com"),
                    Subject = "test subject",
                    Body = "test body"
                })
                {
                    try
                    {
                        address = new MailAddress(mail);
                    }
                    catch (Exception e)
                    {
                        exceptions.Enqueue(new Exception($"wrong email adress - {mail}", e));
                        address = null;
                    }
                    if (address != null)
                    {
                        message.To.Add(address.Address);
                        await SendEMail(message)
                         .ContinueWith((task) =>
                         {
                             Console.WriteLine($"{mail} sended " + task.IsCompleted);
                         }, TaskContinuationOptions.OnlyOnRanToCompletion)

                             .ContinueWith((task) =>
                             {
                                 Console.WriteLine("pizda " + task.Exception);
                             }, TaskContinuationOptions.OnlyOnFaulted)
              .ContinueWith((task) =>
              {
                  Console.WriteLine($"{mail} canceled " + task.IsCanceled);
              }, TaskContinuationOptions.OnlyOnCanceled);

                    }



                }



            });

            if (exceptions.Count > 0)
            {
                // throw new AggregateException(exceptions);
                var ex = new AggregateException(exceptions);
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }


        #region # Private Methods

        private static async Task SendEMail(MailMessage message)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("polivenok.k@gmail.com", @"nikita_30041979");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                await client.SendMailAsync(message);

            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SmtpStatusCode code = ((SmtpException)e.Error).StatusCode;
                // throw new SmtpException(code, e.Error.Message);
            }
        }

        #endregion
    }
}
