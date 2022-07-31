namespace CollectionHierarchy.Models
{
    using Models.Interfaces;
    using System.Collections.Generic;
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            _collection = new List<string>();
        }

        private readonly List<string> _collection;
        public int Add(string item)
        {
           _collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string output = _collection[_collection.Count - 1];
           _collection.RemoveAt(_collection.Count - 1);
            return output;
        }
    }
}
