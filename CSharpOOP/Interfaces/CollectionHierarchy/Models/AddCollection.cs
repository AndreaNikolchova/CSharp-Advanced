namespace CollectionHierarchy.Models
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            _collection = new List<string>();
        }
        private readonly List<string>_collection;
        public int Add(string item)
        {
            _collection.Add(item);
            return _collection.Count-1;
        }
    }
}
