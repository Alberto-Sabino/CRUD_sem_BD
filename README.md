# CRUD_sem_BD

Sistema Finalizado

Esse sistema foi desenvolvido à partir do desafio de programar um CRUD (Create, Read, Update e Delete) SEM o uso de Banco de Dados.

Com isso, foi pensado em um sistema para cadastro simples de um restaurante, com CNPJ, nome, tipo da culinária, endereço e telefone.
O sistema utiliza os métodos da classe StreamWriter para manipular o arquivo txt.



Funcionalidades:

  -Cadastrar um restaurante;
  
  -Ver a lista de todos os restaurantes cadastrados;
  
  -Alterar os dados de um restaurante, passando o CNPJ do mesmo como parâmetro;
  
  -Deletar os dados de um restaurante, passando o CNPJ do mesmo como parãmetro;
  
  -Impossibilita o cadastro de um CNPJ que possua menos do que 10 Caracteres;
  
  -Ao cadastrar um novo restaurante, o sistema bloqueia no case de já existir um CNPJ igual cadastrado;
  
  -O sistema só apaga ou altera a linha onde o cnpj passado por parâmetro é idêntico ao já existente no arquivo txt.
  
  Não esqueça de alterar a variável path presente na classe Restaurante, colocando o caminho onde a pasta do projeto está salva em sua máquina e  "\restaurante.txt"  no final.
