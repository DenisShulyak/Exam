namespace ExamWork
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ProductsContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ExamWork.ProductsContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ProductsContext" 
        // в файле конфигурации приложения.
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CountryOrigin> CountryOrigins { get; set; }
        public DbSet<Product> Products { get; set; }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}