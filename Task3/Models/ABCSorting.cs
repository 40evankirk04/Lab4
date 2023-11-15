namespace Task3.Models
{
    internal class ABCSorting
    {
        public ABCSorting() { }

        public ABCSorting(List<string> words)
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
            if (words == null || words.Count <= 1)
                return;

            int length = words.Count;
            int gap = length / 2;

            while (gap > 0)
            {
                for (int i = gap; i < length; i++)
                {
                    string temp = words[i];
                    int j = i;

                    while (j >= gap && string.Compare(words[j - gap], temp) > 0)
                    {
                        words[j] = words[j - gap];
                        j -= gap;
                    }

                    words[j] = temp;
                }

                gap /= 2;
            }

            _sortedList = words;
        }
    }
}