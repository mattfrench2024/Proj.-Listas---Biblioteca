using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Livros
    {
        private List<Livro> acervo = new List<Livro>();
        public IReadOnlyList<Livro> Acervo => acervo.AsReadOnly();

        public void Adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro? Pesquisar(int isbn)
        {
            return acervo.FirstOrDefault(l => l.ISBN == isbn);
        }
    }
}
