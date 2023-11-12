namespace Task3.Models
{
    internal class Word
    {
        public Word(string word, int quantity)
        {
            _value = word;
            _quantity = quantity;
        }

        private string _value;
        public string Value
        {
            get 
            { 
                return _value; 
            }

            init
            { 
                _value = value; 
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }

            init 
            { 
                _quantity = value; 
            }
        }
    }
}
