// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using curso_de_C_.models;

bool ativado = true;
List<string[]> cadastros = new List<string[]>();

Console.WriteLine("Já bem vindo(a) ao sistema de cadastro de alunos!");

while (ativado)
{
    Console.WriteLine($"\nNosso sistema tem atualmente: {cadastros.Count} cadastros!");
    Console.WriteLine("Qual ação deseja realizar? \n1 - Cadastrar\n2 - Listar\n3 - Sair");
    int opcao = int.Parse(Console.ReadLine()!);

    if (opcao == 1)
    {
        Console.WriteLine("--- Cadastro de Aluno ---");
        string[] novoCadastro = new string[3]; // Array de 3 posições: Nome, Idade, Curso

        Console.Write("Digite o nome do aluno: ");
        novoCadastro[0] = Console.ReadLine()!;

        Console.Write("Digite a idade do Aluno: ");
        // Tratamento de erro para a idade
        string idadeInput = Console.ReadLine()!;
        int idade;
        if (int.TryParse(idadeInput, out idade))
        {
            novoCadastro[1] = idade.ToString(); // Armazena a idade como string
        }
        else
        {
            Console.WriteLine("Idade inválida. Por favor, digite um número.");
            continue; // Volta para o início do loop se a idade for inválida
        }

        Console.Write("Digite o curso do Aluno: ");
        novoCadastro[2] = Console.ReadLine()!;

        cadastros.Add(novoCadastro); // Adiciona o array do novo aluno à lista
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }
    else if (opcao == 2)
    {
        Console.WriteLine("--- Lista de Alunos ---");
        if (cadastros.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado ainda.");
        }
        else
        {
            Console.Write("Deseja buscar um aluno específico pelo nome? (S/N): ");
            string buscaOpcao = Console.ReadLine()?.ToUpper() ?? "";

            if (buscaOpcao == "S")
            {
                Console.Write("Digite o nome do aluno para buscar: ");
                string nomeBusca = Console.ReadLine()!;
                bool encontrado = false;
                foreach (string[] aluno in cadastros) // Itera sobre cada array de aluno na lista
                {
                    // Compara o nome (primeira posição do array do aluno) ignorando maiúsculas/minúsculas
                    if (aluno[0].Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nNome: {aluno[0]}\nIdade: {aluno[1]}\nCurso: {aluno[2]}");
                        encontrado = true;
                        break; // Encontrou, pode sair do loop
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine($"Aluno com nome '{nomeBusca}' não encontrado.");
                }
            }
            else
            {
                // Lista todos os alunos
                foreach (string[] aluno in cadastros)
                {
                    Console.WriteLine($"\nNome: {aluno[0]}\nIdade: {aluno[1]}\nCurso: {aluno[2]}");
                }
            }
        }
    }
    else if (opcao == 3)
    {
        ativado = false;
        Console.WriteLine("Saindo do sistema. Até mais!");
    }
    else if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Opção inválida! Por favor, digite um número.");
        continue; // Volta para o início do loop
    }
    else
    {
        Console.WriteLine("Opção inválida! Por favor, escolha 1, 2 ou 3.");
    }
}