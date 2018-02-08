
using GeradorDeCurriculo.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GeradorDeCurriculo.Services
{
    public class HtmlService
    {
        string versao = "1.0.0";
        HtmlDocument html;
        
        string pathTemplate;
        string pathTemplateAperfeicoamento;
        string pathTemplateFirma;
        string pathTemplatePessoa;

        public HtmlService()
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Mode=Debug v. "+versao);
                pathTemplate = @"../../Views/Template.html";
                pathTemplateAperfeicoamento = @"../../Views/AperfeicoamentoTemplate.html";
                pathTemplateFirma = @"../../Views/Firma.html";
                pathTemplatePessoa = @"../../Views/Pessoa.html";
            }
            else
            {
                Console.WriteLine("Mode=Release");

                pathTemplate = @"./Template.html";
                pathTemplateAperfeicoamento = @"./AperfeicoamentoTemplate.html";
                pathTemplateFirma = @"./Firma.html";
                pathTemplatePessoa = @"./Pessoa.html";
            }
               

            this.html = carregarHtml(File.ReadAllText(pathTemplate));
        }

        HtmlDocument carregarHtml(string html){
            var htmlC = new HtmlDocument();
            htmlC.LoadHtml(html);

            return htmlC;
        }

        public void alterarValor(string id, string value) {
            alterarValor(ref this.html, id, value);
        }

        public void alterarValor(ref HtmlDocument h,  string id, string value)
        {
            h.GetElementbyId(id).InnerHtml = value;
        }

        public void adicionarValor( string id, HtmlNode nodeA)
        {
            HtmlNode node = this.html.GetElementbyId(id);
            node.AppendChild(node);
        }

        public void adicionarAperfeicoamentos(List<Aperfeicoamento> aperfeicoamentos)
        {
            adicionarBloco(
                "lstAperf",
                aperfeicoamentos,
                carregaHtml(
                    aperfeicoamentos.Count,
                    pathTemplateAperfeicoamento
                )
            );
            
        }

        public void adicionarFirma(List<Firma> firmas)
        {
            adicionarBloco(
                "lstFirma",
                firmas,
                carregaHtml(
                    firmas.Count,
                    pathTemplateFirma
                )
            );
        }

        public void adicionarFirma(List<Pessoa> pessoas)
        {
            adicionarBloco(
                "lstPessoa",
                pessoas,
                carregaHtml(
                    pessoas.Count,
                    pathTemplatePessoa
                )
            );
        }
        

       HtmlDocument carregaHtml(int count, string path) {
            HtmlDocument template = null;

            if (count > 0)
                template = carregarHtml(File.ReadAllText(path));

            return template;
        }

        public void adicionarBloco<Tipo>(string idNomeCampo, List<Tipo> blocos, HtmlDocument template)
        {
            var templateString = "";
            foreach (var b in blocos)
            {
                var tipo = b.GetType();
                var propriedades = tipo.GetProperties();

                foreach (var p in propriedades)
                {
                    alterarValor(ref template, p.Name.ToLower(), (string) p.GetValue(b, null));
                }

                templateString += template.DocumentNode.InnerHtml;

            }
            alterarValor(idNomeCampo, templateString);
        }

        public string retornaHtml()
        {
            return html.DocumentNode.InnerHtml;
        }

    }
}
