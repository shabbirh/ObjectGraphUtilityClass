using System;

namespace ObjectGraphMergeUtilityClass.Entities
{
    public class Book 
    {
        public Guid Id { get; set; }

        public int CatalogNumber { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }

       
    }
}
