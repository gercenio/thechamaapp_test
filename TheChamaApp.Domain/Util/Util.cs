using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.Util
{
    public class Util
    {
    }

    /// <summary>
    /// Tipos de usuarios do sistema
    /// SYSTEM = API QUE ACESSA E SOLICITA TOKEN
    /// ADMIN = EMPRESA QUE CONSTRUIU O SISTEMA
    /// OWNER = HGM CONSULTORES
    /// COMPANY = EMPRESA CLIENTE DA HGM CONSULTORES
    /// PEOPLE = USUARIO FINAL QUE REALIZA PESQUISA NA PLATAFORMA
    /// </summary>
    public enum LoginType {
        System,
        Admin,
        Owner,
        Company,
        People
    }
}
