using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //FluentApi - Mapeia comportamentos das Entidades do Domínio para o Banco de Dados

            HasKey(c => c.ClienteId);
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);
            Property(c => c.Email)
                .IsRequired();
        }
    }
}
