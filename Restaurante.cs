using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace CRUD_sem_BD
{
    class Restaurante
    {
        //O único caminho que vc precisa alterar é esse aqui, botei na variável path pra ficar mais fácil
        static string path = @"Caminho que você criou essa pasta na sua máquina\restaurante.txt";

        //StreamWriter é uma função que permite criar, abrir e escrever em arquivos
        StreamWriter writer = new StreamWriter(path, true);

        //No começo de todos os métodos que envolvem o arquivo, é bom colocar um objeto StreamWriter .Close() para evitar bugs

        public string setRestaurantData()
        {
            string dados, cnpj = "", nomeRest, culinaria, endereco, telefone;

            while (cnpj.Length < 10)//Não permite ao usuário cadastrar um cnpj com menos de 10 caracteres
            {
                Console.WriteLine("\n\nDigite um CNPJ (com mais de 10 digitos): ");
                cnpj = Console.ReadLine();
            }

            Console.WriteLine("Restaurante: ");
            nomeRest = Console.ReadLine();
            Console.WriteLine("Culinária: ");
            culinaria = Console.ReadLine();
            Console.WriteLine("Endereço: ");
            endereco = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            telefone = Console.ReadLine();

            dados = cnpj + ". Restaurante: " + nomeRest + " | Culinária: " + culinaria + " | Endereço: " + endereco + " | Telefone: " + telefone;
            //A variável dados é a linha que será cadastrada no txt...
            //IMPORTANTE: NÃO REMOVA O PONTO DEPOIS DO CNPJ!
            //ELE SERVE DE DIVISOR DE VARIÁVEIS, SEPARANDO O CNPJ DO RESTANTE DA LINHA!
            //QUALQUER COISA ESCRITA ANTES DO . SERÁ CONSIDERADA CNPJ
            return dados;
        }

        public void createRestaurant(string dados)
        {
            writer.Close();
            string[] cnpjDados = dados.Split(".");//Separando o cnpj do restante da linha inserida pelo usuário

            foreach (string cnpjLista in File.ReadLines(path))//verificando o arquivo à procura de um cpnj igual existente
            {
                string[] cnpjLinha = cnpjLista.Split(".");

                if (cnpjLinha[0] == cnpjDados[0])//cnpjDados é o que o usuário tentou cadastrar agora, cnpjLinha é o que está salvo no arquivo
                {
                    Console.WriteLine("\nJá existe um CNPJ cadastrado!");
                    Console.ReadKey();
                }
                else
                {
                    //Salvando no arquivo
                    writer.Close();
                    writer = File.AppendText(path);
                    writer.Write("\n" + dados);
                    writer.Close();

                    Console.Write("\n\n\tRestaurante cadastrado com sucesso!");
                    Console.ReadKey();
                }
            }
        }

        public void readRestaurant()
        {
            writer.Close();
            foreach (string line in File.ReadLines(path))//para cada linha no arquivo, salva em line e escreva na tela
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }

        public void deleteRestaurant(string cnpjPrm)
        {
            writer.Close();
            List<string> Lista = new List<string>(); //Ver na doc o que é uma List<T> https://docs.microsoft.com/pt-br/dotnet/api/system.collections.generic.list-1?view=net-5.0
            string cnpjDEL = "";


            //Verificando se o cnpj existe e definindo como cnpjDEL
            foreach (string cnpjLista in File.ReadLines(path))
            {
                //Separando a linha em [0].[1], onde [0] é o cnpj e [1] é o resto da linha
                string[] cnpjLinha = cnpjLista.Split(".");

                //Comparando o cnpj da lista com o passado por parametro
                if (cnpjLinha[0] == cnpjPrm)
                {
                    cnpjDEL = cnpjLinha[0];
                    break;
                }
            }

            //para cada linha no arquivo, salve dentro de "line" e execute o if / else
            foreach (string line in File.ReadLines(path))
            {
                if (!line.Contains(cnpjDEL))
                {
                    //Se essa linha não tiver o cnpj que eu desejo excluir, inclua na variável Lista...
                    Lista.Add(line);
                }
                else { }
            }
            //Abrindo e reescrevendo o arquivo SEM a linha onde estava o CNPJ passado por parâmetro
            using (writer = File.CreateText(path))
            {
                foreach (string str in Lista)
                {
                    writer.WriteLine(str);
                }
            }
        }

        public void updateRestaurant(string cnpjPrm)
        {
            writer.Close();
            string cnpjDEL = "";
            List<string> Lista = new List<string>();

            foreach (string cnpjLista in File.ReadLines(path))
            {
                string[] cnpjLinha = cnpjLista.Split(".");

                if (cnpjLinha[0] == cnpjPrm)
                {
                    cnpjDEL = cnpjLinha[0];
                    break;
                }
            }

            foreach (string line in File.ReadLines(path))
            {
                if (!line.Contains(cnpjDEL))
                {
                    Lista.Add(line);
                }
                else { }
            }

            using (writer = File.CreateText(path))
            {
                foreach (string str in Lista)
                {
                    writer.WriteLine(str);
                }
                //recadastrando e fingindo que alterou---------- Fora isso, o método é idêntico ao de excluir
                string dados = setRestaurantData();
                createRestaurant(dados);
            }
        }
    }
}