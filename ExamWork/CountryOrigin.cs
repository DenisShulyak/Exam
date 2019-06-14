using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
   public class CountryOrigin
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } //Название страны
        public ICollection<Product> Products { get; set; }
    }
}
