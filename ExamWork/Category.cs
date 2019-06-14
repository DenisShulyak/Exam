using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
  public  class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } //название категории товара

        public ICollection<Product> Products { get; set; }
    }
}
