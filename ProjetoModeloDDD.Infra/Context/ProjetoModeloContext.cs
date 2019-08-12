
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.EntityConfig;

namespace ProjetoModeloDDD.Infra.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() 
            : base("ProjetoModeloDDD")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //As tabelas não serão pluralizadas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Não deletará em cascata quando tiver uma relação de one to many
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando houver uma propriedade que possuir o nome for qualquer coisa com Id no final ela será a Chave Primária
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Todas strings serão criadas como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Tamanho do varchar se não for informado.
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        public override int SaveChanges()
        {
            //Quando estiver fazendo alguma mudança na entidade.
            //Trabalhando com Reflection, estou verificando se a entidade tem a propriedade DataCriacao
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}