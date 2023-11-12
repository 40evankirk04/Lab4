using System.IO;
using System.Text.RegularExpressions;

namespace Task3.Models
{
    internal class InputText
    {
        public InputText(TextFile textFile)
        {
            ReadFile(textFile.FilePath);
            TrimSignsFromWords();
        }

        public List<string>? Text { get; set; }

        private void ReadFile(string path)
        {
            if (path == null)
                return;

            List<string> words = new List<string>();

            using (StreamReader sr = new(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineWords = line.Split(' ');
                    foreach (string word in lineWords)
                    {
                        words.Add(word);
                    }
                }
            }

            Text = words;
        }

        private void TrimSignsFromWords()
        {
            if (Text == null) 
                return;

            string[] signs = { "!", ",", "?", ".", ";", "-", ":", "(", ")" };

            for (int i = 0; i < Text.Count; i++)
            {
                foreach(string sign in signs)
                {
                    Text[i] = Text[i].Replace(sign, "");
                }
            }
        }
    }
}
