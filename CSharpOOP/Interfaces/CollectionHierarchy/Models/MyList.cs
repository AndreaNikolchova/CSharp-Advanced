namespace CollectionHierarchy.Models
{
    using Models.Interfaces;
    using System.Collections.Generic;
    public class MyList : IMyList
    {
        public MyList()
        {
            _collection = new List<string>();
        }

        private readonly List<string> _collection;
        public int Used => _collection.Count;

        public int Add(string item)
        {
            _collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string output = _collection[0];
            _collection.RemoveAt(0);
            return output;
        }
    }
}
