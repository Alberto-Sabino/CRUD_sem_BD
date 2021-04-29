using System;
using System.IO;

namespace CRUD_sem_BD
{
    class MainClass : Restaurante
    {
        static void Main(string[] args)
        {

            string opcao;
            Restaurante c = new Restaurante();

            for (; ; )//For infinito... Só encerra com break;
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo, o que deseja fazer ?");
                Console.WriteLine("\t(C) Criar restaurante");
                Console.WriteLine("\t(R) Listar Restaurantes");
                Console.WriteLine("\t(U) Alterar Restaurante");
                Console.WriteLine("\t(D) Deletar Restaurante");
                Console.WriteLine("\t(S) Sair");
                opcao = Console.ReadLine();

                opcao = opcao.ToLower();

                if (opcao == "s") { break; }

                else if (opcao == "c")
                {
                    string dados = c.setRestaurantData();
                    c.createRestaurant(dados);
                }
                else if (opcao == "r")
                {
                    c.readRestaurant();
                }
                else if (opcao == "d")
                {
                    Console.Write("\n\n Digite um CPNJ: ");
                    string cnpj = Console.ReadLine();
                    c.deleteRestaurant(cnpj);
                }
                else if (opcao == "u")
                {
                    Console.Write("\n\n Digite um CPNJ: ");
                    string cnpj = Console.ReadLine();
                    c.updateRestaurant(cnpj);
                }
            }
            Console.Write("\n\nSistema Finalizado.\n\n");
        }
    }
}
