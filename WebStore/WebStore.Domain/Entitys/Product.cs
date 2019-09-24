using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entitys.BaseEntitys;
using WebStore.Domain.Entitys.BaseEntitys.Interface;

namespace WebStore.Domain.Entitys
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
