using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace TheChamaApp.Service.EmailBusiness
{
    public class EmailService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IConfigurationSettingsApplication _IConfigurationSettingsApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;

        #endregion

        #region # Private Propriedades

        private readonly string _From;
        private readonly string _Sendgrid_Key;
        private readonly string _FromDescription;

        //private static string _To;
        private static string _Subject;
        private static string _Body;
        
        #endregion

        #region # Constructor

        public EmailService(IConfigurationSettingsApplication configurationSettingsApplication
            ,ICompanyUnityApplication companyUnityApplication
            , IEvaluatedApplication evaluatedApplication 
            )
        {
            _IConfigurationSettingsApplication = configurationSettingsApplication;
            _ICompanyUnityApplication = companyUnityApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _From = this.GetEmailFrom();
            _FromDescription = this.GetEmailFromDescription();
            _Subject = this.GetEmailFromDescription(); 
            //_Body = Body;
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
                //var to = new EmailAddress(_To, "Example User");
                var to = new EmailAddress("gercenio@gmail.com", "Example User");
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

        /// <summary>
        /// Enviar o link do formulario por e-mail
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public async Task NotificaQuestionario(Infra.CrossCutting.ViewModel.NotificacaoVewModel Model)
        {
            
            try
            {
                var Config = _IConfigurationSettingsApplication.GetAll().Where(m => m.Type == Domain.Util.ConfigurationType.Email).Single();
                var EvaluatedList = _IEvaluatedApplication.GetAll().Where(m => m.CompanyUnityId == Model.CompanyUnityId).ToList();
                if (EvaluatedList.Count > 0)
                {
                    foreach (var Colaborador in EvaluatedList)
                    {
                        if (!string.IsNullOrEmpty(Colaborador.Email))
                        {
                            if (TheChamaApp.Infra.CrossCutting.Util.Utilities.IsEmail(Colaborador.Email))
                            {
                                var client = new SendGridClient(_Sendgrid_Key);
                                var from = new EmailAddress(_From, _FromDescription);
                                var subject = _Subject;
                                var to = new EmailAddress(Colaborador.Email, Colaborador.Description);
                                var plainTextContent = string.Format("{0}/u/{1}/e/{2}", Config.Url, Colaborador.CompanyUnityId, Colaborador.EvaluatedId);
                                var htmlContent = string.Format("{0}/u/{1}/e/{2}", Config.Url, Colaborador.CompanyUnityId, Colaborador.EvaluatedId);//"<strong>and easy to do anywhere, even with C#</strong>";
                                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                                var response = await client.SendEmailAsync(msg);
                                
                            }
                           
                        }
                        
                    }
                    
                }
                
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
            var apiKey = _IConfigurationSettingsApplication.GetAll().Where(m => m.Type == Domain.Util.ConfigurationType.Email).Single().Token.ToString();
            return apiKey;
        }

        /// <summary>
        /// Retorna á Conta de E-Mail Padrão de envio (FROM)
        /// </summary>
        /// <returns></returns>
        private string GetEmailFrom()
        {
            var apiKey = _IConfigurationSettingsApplication.GetAll().Where(m => m.Type == Domain.Util.ConfigurationType.Email).Single().UserName.ToString();
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
