namespace Task3.Models
{
    internal class WordsCounter
    {
        public WordsCounter(List<string> words)
        {
            CountEveryWord(words);
        }

        private List<int> _countedValues = new();
        public List<int> CountedValues
        { 
            get
            { 
                return _countedValues; 
            }

            private set 
            { 
                _countedValues = value; 
            }
        }

        private void CountEveryWord(List<string> words)
        {
            int count;

            foreach(var word in words)
            {
                count = words.Count(w => w == word);

                CountedValues.Add(count);
            }
        }
    }
}
