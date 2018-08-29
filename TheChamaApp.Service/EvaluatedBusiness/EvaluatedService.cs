using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;

namespace TheChamaApp.Service.EvaluatedBusiness
{
    public class EvaluatedService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        #endregion

        #region # Constructor
        public EvaluatedService(IEvaluatedApplication evaluated
            , ICompanyUnityApplication companyUnityApplication)
        {
            _IEvaluatedApplication = evaluated;
            _ICompanyUnityApplication = companyUnityApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um novo registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Evaluated Incluir(Domain.Entities.Evaluated Entity, out string Mensagem)
        {
            try
            {
                var UnityList = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == Entity.CompanyUnityId).ToList();
                if (UnityList.Count > 0)
                {
                    _IEvaluatedApplication.Add(Entity);
                    Mensagem = Entity.EvaluatedId.ToString();
                }
                else {
                    Mensagem = "Unity is not found !!!";
                }
                    
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void Alterar(Domain.Entities.Evaluated Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OriginalList = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == Entity.EvaluatedId).ToList();
                if (OriginalList.Count > 0) {
                    _IEvaluatedApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int EvaluatedId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Orginal = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
                if (Orginal != null) {
                    _IEvaluatedApplication.Remove(Orginal);
                    Mensagem = "Done";
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public Domain.Entities.Evaluated Obter(int EvaluatedId)
        {
            return _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
        }

        /// <summary>
        /// Obtem uma lista de avaliados por unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Evaluated> ObterTodosPorUnidade(int CompanyUnityId)
        {
            return _IEvaluatedApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId).ToList();
        }

        /// <summary>
        /// Realiza a importação de avaliado
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="Mensagem"></param>
        public void Importa(List<Domain.Entities.Evaluated> lista, out string Mensagem)
        {
            Mensagem = string.Empty;
            foreach (var Avaliado in lista)
            {
                this.Incluir(Avaliado,out Mensagem);
            }
        }

        /// <summary>
        /// Obtem um avaliado passando a descrição dele
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Evaluated> ObterByDescription(string Description)
        {
            List<Domain.Entities.Evaluated> lista = new List<Domain.Entities.Evaluated>();
            foreach (var Avaliado in _IEvaluatedApplication.GetAll().Where(m => m.Description.Contains(Description)).ToList())
            {
                lista.Add(this.Obter(Avaliado.EvaluatedId));
            }
            return lista;
        }

        /*
        public void EnviarEmail(int EvaluatedId)
        {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient(args[0],,);
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("jane@contoso.com",
               "Jane " + (char)0xD8 + " Clayton",
            System.Text.Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress("ben@contoso.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
        }*/

        #endregion

        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

    }
}
