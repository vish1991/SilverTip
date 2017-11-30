namespace SilverTip.BusinessEntities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class SilverTipEntities : DbContext
    {
        // Your context has been configured to use a 'SilverTipEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SilverTip.BusinessEntities.SilverTipEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SilverTipEntities' 
        // connection string in the application configuration file.
        public SilverTipEntities()
            : base("name=SilverTipEntities")
        {
           // Database.SetInitializer<SilverTipEntities>(null);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<LeafType> LeafTypes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}