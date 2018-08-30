using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TheChamaApp.Service.EmailBusiness
{
    public class EmailService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly string _From;
        private readonly string _Sendgrid_Key;
        private readonly string _FromDescription;

        private static string _To;
        private static string _Subject;
        private static string _Body;
        
        #endregion

        #region # Constructor

        public EmailService(string To,string Subject,string Body)
        {
            _From = this.GetEmailFrom();
            _FromDescription = this.GetEmailFromDescription();
            _To = To;
            _Subject = Subject;
            _Body = Body;
            _Sendgrid_Key = this.GetApiKey();
        }

        #endregion

        #region # Methods

        /// <summary>
        /// E-Mail de teste sistema
        /// </summary>
        /// <returns></returns>
        public async Task EnviarAsync()
        {
            try
            {
                var client = new SendGridClient(_Sendgrid_Key);
                var from = new EmailAddress(_From, _FromDescription);
                var subject = _Subject;
                var to = new EmailAddress(_To, "Example User");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }    
        }

        #endregion

        #region # Private Members

        /// <summary>
        /// Retorna o Key - SENDGRID
        /// </summary>
        /// <returns></returns>
        private string GetApiKey()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var apiKey = (config.GetSection("AppSettings:SENDGRID_KEY").Value);
            return apiKey;
        }

        /// <summary>
        /// Retorna á Conta de E-Mail Padrão de envio (FROM)
        /// </summary>
        /// <returns></returns>
        private string GetEmailFrom()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var apiKey = (config.GetSection("AppSettings:EMAIL_FROM").Value);
            return apiKey;
        }

        /// <summary>
        /// Retorna á Descrição do E-Mail From 
        /// </summary>
        /// <returns></returns>
        private string GetEmailFromDescription()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var apiKey = (config.GetSection("AppSettings:EMAIL_FROM_DESCRIPTION").Value);
            return apiKey;
        }

        #endregion

    }
}
