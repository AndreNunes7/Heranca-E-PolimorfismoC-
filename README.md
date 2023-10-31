# Exemplo de Classe Genérica

Este é um exemplo de código C# para demonstrar uma hierarquia de classes em um sistema de gerenciamento de pessoas. 

## Descrição

O código consiste em uma hierarquia de classes em que a classe `Pessoa` é a classe base abstrata, contendo informações gerais sobre uma pessoa. As classes derivadas incluem `Professor`, `Aluno`, `Funcionario` e `Noia`, cada uma com propriedades específicas relacionadas à sua função.

## Estrutura do Código

- `Pessoa`: A classe base abstrata que contém informações básicas de uma pessoa, como nome, data de nascimento, RG, CPF e sexo. Também define um método abstrato `Salario` para cálculo de salário e métodos para gerenciar telefones.

- `Professor`: Classe derivada de `Pessoa` que adiciona informações específicas de professores, como registro funcional e formação.

- `Aluno`: Classe derivada de `Pessoa` que inclui informações específicas para alunos, como RA (Registro Acadêmico) e curso.

- `Funcionario`: Classe derivada de `Pessoa` que representa funcionários. Ela inclui informações sobre cargo, data de admissão e registro funcional.

- `Noia`: Uma classe adicional que herda de `Pessoa`, representando um tipo genérico de pessoa.

## Uso

O código exemplifica como criar instâncias de diferentes tipos de pessoas e adicioná-las a listas. Também permite que o usuário insira informações relacionadas a cargos e telefones.

## Instruções de Execução

1. Clone o repositório.
2. Abra o código em um ambiente de desenvolvimento C#.
3. Execute o programa para visualizar as informações das pessoas criadas.

