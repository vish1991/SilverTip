namespace SilverTip.BusinessEntities
{
    using Boughtleaf.BusinessEntities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class SilverTipEntities : DbContext
    {
        // Your context has been configured to use a 'SilverTipEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SilverTip.BusinessEntities.SilverTipEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SilverTipEntitiesConnectionString' 
        // connection string in the application configuration file.
        public SilverTipEntities()
            : base("name=SilverTipEntities")
        {
            Database.SetInitializer<SilverTipEntities>(new CreateDatabaseIfNotExists<SilverTipEntities>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<CollectionOfficer> CollectionOfficers { get; set; }
        public virtual DbSet<CollectionOfficerRoute> CollectionOfficerRoutes { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<FundMode> FundModes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<LeafCollection> LeafCollections { get; set; }
        public virtual DbSet<LeafReconciliation> LeafReconciliations { get; set; }
        public virtual DbSet<LeafType> LeafTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCollection> SupplierCollections { get; set; }
        public virtual DbSet<SupplierFund> SupplierFunds { get; set; }
        public virtual DbSet<SupplierPaymentType> SupplierPaymentTypes { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<LogMessage> LogMessages { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}