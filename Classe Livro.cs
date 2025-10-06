using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Livro
    {
        public int ISBN { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        private List<Exemplar> exemplares = new List<Exemplar>();
        public IReadOnlyList<Exemplar> Exemplares => exemplares.AsReadOnly();

        public void AdicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int QtdeExemplares() => exemplares.Count;

        public int QtdeDisponiveis() => exemplares.Count(e => e.Disponivel());

        public int QtdeEmprestimos() => exemplares.Sum(e => e.QtdeEmprestimos());

        public double PercDisponibilidade()
        {
            return QtdeExemplares() > 0 ? (double)QtdeDisponiveis() / QtdeExemplares() * 100 : 0;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\nTítulo: {Titulo}\nAutor: {Autor}\nEditora: {Editora}\n" +
                   $"Exemplares: {QtdeExemplares()}, Disponíveis: {QtdeDisponiveis()}, " +
                   $"Empréstimos: {QtdeEmprestimos()}, Disponibilidade: {PercDisponibilidade():F2}%";
        }
    }
}
