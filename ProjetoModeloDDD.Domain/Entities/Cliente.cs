using System;
using System.Collections;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable Produtos { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCriacao.Year >= 5;
        }
    }
}
