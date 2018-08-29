using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.Util
{
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

    /// <summary>
    /// Status do questionario
    /// INDEFINIDO = 0 (Quando e criado)
    /// IN PROGRESS = 1 (Quando as perguntas e resposta ainda estão sendo atribuidas)
    /// VALID = 2 (Quando já contém todas as perguntas e resposta definidas e esta liberado para uso)
    /// </summary>
    public enum QuestionsStatus
    {
        Indefine,
        InProgress,
        Valid
    }
}
