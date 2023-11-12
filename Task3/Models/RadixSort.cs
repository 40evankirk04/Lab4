namespace Task3.Models
{
    internal class RadixSort
    {
        public RadixSort(List<string> words)
        {
            Sort(words);
        }

        private List<string>? _sortedList;
        public List<string> SortedList
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
            if (words == null || words.Count < 2)
                return;

            int maxLength = words.Max(s => s.Length);
            for (int i = maxLength - 1; i >= 0; i--)
            {
                List<string>[] buckets = new List<string>[256];
                for (int j = 0; j < 256; j++)
                    buckets[j] = new List<string>();

                foreach (string s in words)
                {
                    if (i < s.Length)
                        buckets[s[i]].Add(s);
                    else
                        buckets[0].Add(s);
                }

                words.Clear();
                foreach (List<string> bucket in buckets)
                    words.AddRange(bucket);
            }

            _sortedList = words;
        }
    }
}