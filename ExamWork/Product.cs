using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
   public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } //Название товара
        public int Price { get; set; }// Цена товара


        public DateTime DateOfIssue { get; set; }//Дата выпуска
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid CountryOriginId { get; set; }
        public CountryOrigin CountryOrigin { get; set; }
        
    }
}
