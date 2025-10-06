using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime? DtDevolucao { get; set; }

        public Emprestimo()
        {
            DtEmprestimo = DateTime.Now;
            DtDevolucao = null;
        }

        public void RegistrarDevolucao()
        {
            DtDevolucao = DateTime.Now;
        }

        public override string ToString()
        {
            string devolucao = DtDevolucao.HasValue ? DtDevolucao.Value.ToString("dd/MM/yyyy HH:mm") : "Não devolvido";
            return $"Emprestimo: {DtEmprestimo:dd/MM/yyyy HH:mm} | Devolução: {devolucao}";
        }
    }
}
