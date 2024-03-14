﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.EmailSender
{
    public class EmailSender
    {
        public static async Task EnviarEmailAsync(Produto produto, EmailSend emails)
        {
            string melhorCompraTexto = emails.Best == 0 ? "MagazineLuiza - <a href=\"" + emails.MagazineUrl + "\">Clique aqui</a>" :
                           emails.Best == 1 ? "Mercado Livre -  <a href=\"" + emails.MercadoUrl + "\">Clique aqui</a>" :
                           "O Preço é igual nos dois.";

            var email = new Email("smtp-mail.outlook.com", "testrpasenai@outlook.com", "#testrpa0011");

            string corpoEmailHtml = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                </head>
                <body>
                    <h1>Produto Pesquisado</h1>
                    <p>{produto.Desciption}</p>
                    <h2>Mercado Livre</h2>
                    <p>Produto: {emails.MercadoTitle}</p>
                    <p>Preço: R$ {emails.MercadoPrice}</p>
                    <h2>MagazineLuiza</h2>
                    <p>Produto: {emails.MagazineTitle}</p>
                    <p>Preço: {emails.MagazinePrice}</p>
                    <h2>Melhor Compra</h2>
                    <p>{melhorCompraTexto}</p>
                    <p>Robô 3416</p>
                    <p>Usuário: andreLuiz</p>
                </body>
                </html>
                ";

            await email.SendEmailAsync(
                new List<string>
                {
                    "andre.l.junior13@aluno.senai.br",
                    emails.Email
                },
                "Resultado da Comparação de Preço",
                corpoEmailHtml
            );
        }
    }
}
