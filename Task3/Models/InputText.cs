using System.IO;

namespace Task3.Models
{
    internal class InputText
    {
        public InputText() { }

        public InputText(TextFile textFile)
        {
            GetTextFromFile(textFile.FilePath);
            TrimSignsFromWords();
            MakeLowerCase();
        }

        private List<string>? _text;
        public List<string>? Text 
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            } 
        }

        public void GetTextFromFile(string? path)
        {
            if (path == null)
                return;

            List<string> words = new();

            using (StreamReader sr = new(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineWords = line.Split(' ');
                    foreach (string word in lineWords)
                    {
                        words.Add(word);
                    }
                }
            }

            _text = words;
        }

        private void TrimSignsFromWords()
        {
            if (_text == null) 
                return;

            char[] signs = { '!', ',', '?', '.', ';', '-', ':', '(', ')', '"' };

            for (int i = 0; i < _text.Count; i++)
            {
                foreach(char sign in signs)
                {
                    _text[i] = _text[i].Trim(sign);
                }
            }
        }
        
        private void MakeLowerCase()
        {
            if (_text == null)
                return;

            for (int i = 0; i < _text.Count; i++)
            {
                _text[i] = _text[i].ToLower();
            }
        }
    }
}