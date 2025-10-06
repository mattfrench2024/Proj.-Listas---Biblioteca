using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Exemplar
    {
        public int Tombo { get; set; }
        private List<Emprestimo> emprestimos = new List<Emprestimo>();
        public IReadOnlyList<Emprestimo> Emprestimos => emprestimos.AsReadOnly();

        public bool Disponivel()
        {
            return !emprestimos.Any(e => e.DtDevolucao == null);
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                emprestimos.Add(new Emprestimo());
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            var atual = emprestimos.LastOrDefault(e => e.DtDevolucao == null);
            if (atual != null)
            {
                atual.RegistrarDevolucao();
                return true;
            }
            return false;
        }

        public int QtdeEmprestimos()
        {
            return emprestimos.Count;
        }

        public override string ToString()
        {
            return $"Tombo: {Tombo} | Disponível: {Disponivel()} | Qtde Empréstimos: {QtdeEmprestimos()}";
        }
    }
}
