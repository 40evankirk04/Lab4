namespace Task3.Models
{
    internal class SelectSorting
    {
        public SelectSorting() { }

        public SelectSorting(List<string> words)
        {
            Sort(words);
        }

        private List<string>? _sortedList;
        public List<string>? SortedList
        {
            get
            {
                return _sortedList;
            }

            set
            {
                _sortedList = value;
            }
        }

        public void Sort(List<string> words)
        {
            for (int i = 0; i < words.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (string.Compare(words[j], words[minIndex], StringComparison.Ordinal) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    (words[minIndex], words[i]) = (words[i], words[minIndex]);
                }
            }

            _sortedList = words;
        }
    }
}