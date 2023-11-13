namespace Task3.Models
{
    internal class BubbleSort
    {
        public BubbleSort(List<string> words)
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

        private void Sort(List<string> words)
        {
            if (words == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < words.Count; i++)
                {
                    if (string.Compare(words[i - 1], words[i]) > 0)
                    {
                        string temp = words[i - 1];
                        words[i - 1] = words[i];
                        words[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            for (int i = 1; i < words.Count; i++)
            {
                if (string.Compare(words[i - 1], words[i]) == 0 && string.Compare(words[i - 1], words[i]) > 0)
                {
                    string temp = words[i - 1];
                    words[i - 1] = words[i];
                    words[i] = temp;
                }
            }

            SortedList = words;
        }
    }
}