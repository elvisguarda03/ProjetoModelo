namespace ProjetoModeloDDD.Infra.Migrations
{
    using System.Data.Entity.Migrations;
 
    internal sealed class Configuration : DbMigrationsConfiguration<Context.ProjetoModeloContext>
    {
        public Configuration()
        {
            //Refletirá as modificações da aplicação para o banco de dados
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ProjetoModeloContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
