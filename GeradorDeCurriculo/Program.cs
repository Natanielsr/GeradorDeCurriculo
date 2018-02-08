using GeradorDeCurriculo.Models;
using GeradorDeCurriculo.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GeradorDeCurriculo
{
    class Program
    {
        static HtmlService htmlService;
        static void Main(string[] args)
        {
            

            htmlService = new HtmlService();

            Console.WriteLine("\nINDENTIFICAÇÃO \n");

            ler("Insira um nome", "nome");
            ler("Insira um Endereço", "endereco");
            ler("Insira um numero", "numero");
            ler("Insira um Bairro", "bairro");
            ler("Insira um Telefone", "fone");
            ler("Insira um Email", "email");
            ler("Insira um Site", "site");
            ler("Insira uma Cidade", "cidade");
            ler("Insira um CEP", "cep");
            ler("Insira um Estado", "estado");
            ler("Insira um Filho de", "filhode");
            ler("Insira uma Nacionalidade", "nacionalidade");
            ler("Insira uma Naturalidade", "naturalidade");
            ler("Insira uma Data de Nascimento", "dataDeNascimento");
            ler("Insira um Estado Civil", "estadoCivil");
            ler("Insira uma identidade", "identidade");
            ler("Insira uma Carteira Profissional", "cartProfissional");
            ler("Insira a Serie da Carteira Profissional", "serie");
            ler("Insira o Numero da Carteira de Reservista", "carteiraDeReservista");
            ler("Insira o numero do Titulo de Eleitor", "tituloDeEleitor");
            ler("Insira a zona do Titulo de Eleitor", "zona");
            ler("Insira um CPF", "cpf");
            ler("Insira o numero da carteira de Habilitação", "carteiraDeHabilitacao");
            ler("Insira a categoria da carteira de Habilitação", "categoria");

            Console.WriteLine("\nESCOLARIDADE\n");

            Console.WriteLine("\nCURSO 1º GRAU(1 a 8ª SERIE)\n");

            ler("Insira a escola do 1ª grau", "1grauEscola");
            ler("Insira a cidade da escola do 1º grau", "1grauCidade");
            ler("Insira o periodo da escola do 1º grau\n", "1grauPeriodo");

            Console.WriteLine("\nCURSO COLEGIAL\n");

            ler("Insira a escola do Colegial", "colegialEscola");
            ler("Insira a cidade da escola do Colegial", "colegialCidade");
            ler("Insira o periodo da escola do Colegial\n", "colegialPeriodo");

            Console.WriteLine("\nCURSO SUPERIOR\n");

            ler("Insira a Universidade do Curso Superior", "universade");
            ler("Insira a Faculade do Curso Superior", "faculdade");
            ler("Insira a Curso do Curso Superior", "curso");
            ler("Insira a cidade do Curso Superior", "universidadeCidade");
            ler("Insira o periodo do Curso Superior", "universiadePeriodo");
                     
            var qtdCursos = capturarNumero("CURSOS DE APERFEIÇOAMENTO, PÓS GRADUAÇÃO, SEMINÁRIOS, PALESTRAS, ETC ",
                "Quantos cursos de aperfeiçoamento você possui?");

            List<Aperfeicoamento> aps= new List<Aperfeicoamento>();
            for (int i = 0; i < qtdCursos; i++)
            {
                var aperfeicoamento = new Aperfeicoamento();
                Console.WriteLine("Assunto do Curso de aperfeiçoamento "+(i+1));
                aperfeicoamento.Assunto = Console.ReadLine();
                Console.WriteLine("Entidade do Curso de aperfeiçoamento " + (i + 1));
                aperfeicoamento.Entidade = Console.ReadLine();
                Console.WriteLine("Periodo do Curso de aperfeiçoamento " + (i + 1));
                aperfeicoamento.Periodo = Console.ReadLine();

                aps.Add(aperfeicoamento);
            }
            htmlService.adicionarAperfeicoamentos(aps);
            
            var qtdFirmas = capturarNumero("EXPERIÊNCIA PROFISSIONAL",
                "Quantas firmas você passou?");

            List<Firma> fms = new List<Firma>();
            for (int i = 0; i < qtdFirmas; i++)
            {
                var firma = new Firma();
                Console.WriteLine("Nome da Firma" + (i + 1));
                firma.Nome = Console.ReadLine();
                Console.WriteLine("Endereço da Firma" + (i + 1));
                firma.Endereco = Console.ReadLine();
                Console.WriteLine("Bairro da Firma" + (i + 1));
                firma.Bairro = Console.ReadLine();
                Console.WriteLine("Cidade da Firma" + (i + 1));
                firma.Cidade = Console.ReadLine();
                Console.WriteLine("Estado da Firma" + (i + 1));
                firma.Estado = Console.ReadLine();
                Console.WriteLine("Periodo da Firma" + (i + 1));
                firma.Periodo = Console.ReadLine();
                Console.WriteLine("Cargo da Firma" + (i + 1));
                firma.Cargo = Console.ReadLine();
                Console.WriteLine("Funções desempenhadas na Firma" + (i + 1));
                firma.FuncoesDesempenhadas = Console.ReadLine();
                
                fms.Add(firma);
            }
            htmlService.adicionarFirma(fms);

            var qtdPessoas= capturarNumero("INFORMAÇÕES COMPLEMENTARES - PESSOAS QUE POSSAM DAR INFORMAÇÕES",
                "Quantas Pessoas podem dar informações?");

            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < qtdFirmas; i++)
            {
                var pessoa = new Pessoa();
                Console.WriteLine("Nome da Pessoa" + (i + 1));
                pessoa.Nome = Console.ReadLine();
                Console.WriteLine("Endereço da Pessoa" + (i + 1));
                pessoa.Endereco = Console.ReadLine();
                Console.WriteLine("Telefone da Pessoa" + (i + 1));
                pessoa.Fone = Console.ReadLine();
                Console.WriteLine("Cidade da Pessoa" + (i + 1));
                pessoa.Cidade = Console.ReadLine();

                pessoas.Add(pessoa);
            }
            htmlService.adicionarFirma(fms);


            ler("Insira Seu Ultimo Salario", "ultimoSalario");
            ler("Insira O Salário Pretendido", "salarioPretendido");
            ler("Insira Outras funções que se propões a exercer", "outrasFuncoes");

            Console.WriteLine("\nGerando Curriculo...");
            var html = htmlService.retornaHtml();
            Console.WriteLine("Curriculo Gerado");
            Console.WriteLine("Salvando Curriculo...\n");
            var r = ArquivoService.salvar(html);
            Console.WriteLine("Curriculo Salvo em '"+r+"'");

            Console.ReadKey();
        }

        static void ler(string label, string id) {
            Console.WriteLine(label);
            var r = Console.ReadLine();
            htmlService.alterarValor(id, r);
        }

        static int capturarNumero(string titulo, string pergunta) {
            
            var qtd = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("\n"+titulo+"\n");
                    Console.WriteLine(pergunta);
                    qtd = Convert.ToInt32(Console.ReadLine());
                    return qtd;
                }
                catch (Exception)
                {
                    Console.WriteLine("Insira um numero corretamente");
                }
            }
        }
    }
    
}
