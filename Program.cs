using System;

namespace Biblioteca
{
    class Program
    {
        static Livros biblioteca = new Livros();

        static void Main()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.WriteLine("====================================");
                Console.Write("Escolha uma opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: AdicionarLivro(); break;
                    case 2: PesquisarLivroSintetico(); break;
                    case 3: PesquisarLivroAnalitico(); break;
                    case 4: AdicionarExemplar(); break;
                    case 5: RegistrarEmprestimo(); break;
                    case 6: RegistrarDevolucao(); break;
                }

            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine()!);
            Console.Write("Título: ");
            string titulo = Console.ReadLine()!;
            Console.Write("Autor: ");
            string autor = Console.ReadLine()!;
            Console.Write("Editora: ");
            string editora = Console.ReadLine()!;

            Livro l = new Livro { ISBN = isbn, Titulo = titulo, Autor = autor, Editora = editora };
            biblioteca.Adicionar(l);

            Console.WriteLine("Livro adicionado!");
            Console.ReadKey();
        }

        static void PesquisarLivroSintetico()
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine()!);
            var livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
                Console.WriteLine(livro);
            else
                Console.WriteLine("Livro não encontrado!");
            Console.ReadKey();
        }

        static void PesquisarLivroAnalitico()
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine()!);
            var livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine(livro);
                Console.WriteLine("\nDetalhes dos exemplares:");
                foreach (var ex in livro.Exemplares)
                {
                    Console.WriteLine(ex);
                    foreach (var emp in ex.Emprestimos)
                        Console.WriteLine("   " + emp);
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
            Console.ReadKey();
        }

        static void AdicionarExemplar()
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine()!);
            var livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Digite o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine()!);
                livro.AdicionarExemplar(new Exemplar { Tombo = tombo });
                Console.WriteLine("Exemplar adicionado!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
            Console.ReadKey();
        }

        static void RegistrarEmprestimo()
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine()!);
            var livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                var ex = livro.Exemplares.FirstOrDefault(e => e.Disponivel());
                if (ex != null && ex.Emprestar())
                    Console.WriteLine($"Exemplar {ex.Tombo} emprestado!");
                else
                    Console.WriteLine("Nenhum exemplar disponível!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
            Console.ReadKey();
        }

        static void RegistrarDevolucao()
        {
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine()!);
            var livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Digite o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine()!);
                var ex = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
                if (ex != null && ex.Devolver())
                    Console.WriteLine($"Exemplar {ex.Tombo} devolvido!");
                else
                    Console.WriteLine("Exemplar não encontrado ou já devolvido!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
            Console.ReadKey();
        }
    }
}
