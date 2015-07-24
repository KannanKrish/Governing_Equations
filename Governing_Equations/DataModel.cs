namespace Governing_Equations
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        // Your context has been configured to use a 'DataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Governing_Equations.DataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModel' 
        // connection string in the application configuration file.
        public DataModel()
            : base("name=DataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Mx_Value> MxValue { get; set; }
        public DbSet<Mmin_Value> MminValue { get; set; }
        public DbSet<Tb_Value> TbValue { get; set; }
        public DbSet<Td_Value> TdValue { get; set; }
        public DbSet<H_Value> HValue { get; set; }
        public DbSet<Qab_Value> QabValue { get; set; }
        public DbSet<Qbc_Value> QbcValue { get; set; }
    }
}