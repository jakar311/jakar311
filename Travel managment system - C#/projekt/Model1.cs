using System;
using System.Data.Entity;
using System.Linq;

namespace projekt
{
    /// <summary>
    /// Klasa Model1 potrzebna do zapisu biura podró¿y do bazy danych
    /// </summary>
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'projekt.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.

        /// <summary>
        /// Konstruktor nieparametryczny Model1
        /// </summary>
        public Model1()
            : base("name=Model1")
        {
        }

        /// <summary>
        /// Kolekcja obiektu DBSet o nazwie BiuroPod
        /// </summary>
        public virtual DbSet<BiuroPodrozy> BiuroPod { get; set; }

        /// <summary>
        /// Kolekcja obiektu DbSet o nazwie PodrozWBiurze
        /// </summary>
        public virtual DbSet<Podroze> PodrozeWBiurze { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}