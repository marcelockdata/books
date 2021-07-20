using MHP.Domain.Tests.Core;
using System;

namespace MHP.Domain.Tests.Entities
{
    public class Book: Entity
    {      
        public string Name { get; set; }
        public double Price { get; set; }

        public Book(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;         
        }

    }
}
