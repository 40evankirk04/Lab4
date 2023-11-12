using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;
using Task3.Views;

namespace Task3.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ABCSort _abcSort;
        public ABCSort ABCSort
        {
            get
            {
                return _abcSort;
            }

            set
            {
                _abcSort = value;
                OnPropertyChanged();
            }
        }

        private BubbleSort _bubbleSort;
        public BubbleSort BubbleSort
        {
            get
            {
                return _bubbleSort;
            }

            set
            {
                _bubbleSort = value;
                OnPropertyChanged();
            }
        }

        private InputText _inputedText;
        public InputText InputedText 
        {  
            get 
            { 
                return _inputedText;
            }
            set
            {
                _inputedText = value;
                OnPropertyChanged();
            }
        }

        private TextFile _openedFile;
        public TextFile OpenedFile 
        {  
            get 
            {   
                return _openedFile;
            }

            set 
            { 
                _openedFile = value; 
                OnPropertyChanged();
            } 
        }

        private WordsCounter _wordsCounter;
        public WordsCounter WordsCounter
        {
            get
            {
                return _wordsCounter;
            }

            set 
            { 
                _wordsCounter = value;
                OnPropertyChanged();
            }
        }

        private List<Word> _words = new();
        public List<Word> Words
        {
            get
            {
                return _words;
            }

            set 
            { 
                _words = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _openABCSortWindowCommand;
        public RelayCommand OpenABCSortWindowCommand
        {
            get
            {
                return _openABCSortWindowCommand ??= new RelayCommand(obj =>
                {
                    Words.Clear();

                    ABCSort = new(InputedText.Text);
                    WordsCounter = new(ABCSort.SortedList);

                    FillWordsList(ABCSort.SortedList);

                    ABCSortWindow abcSortWindow = new()
                    {
                        DataContext = this
                    };

                    abcSortWindow.Show();

                }, (obj) => OpenedFile?.FileName is not null); 
            }
        }

        private RelayCommand _openBubbleSortWindowCommand;
        public RelayCommand OpenBubbleSortWindowCommand
        {
            get
            {
                return _openBubbleSortWindowCommand ??= new RelayCommand(obj =>
                {
                    Words.Clear();

                    BubbleSort = new(InputedText.Text);
                    WordsCounter = new(BubbleSort.SortedList);

                    FillWordsList(BubbleSort.SortedList);

                    BubbleSortWindow bubbleSortWindow = new()
                    {
                        DataContext= this
                    };

                    bubbleSortWindow.Show();

                }, (obj) => OpenedFile?.FileName is not null);
            }
        }

        private RelayCommand _openFileCommand;
        public RelayCommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ??= new RelayCommand(obj => {

                    OpenedFile = new TextFile();
                    InputedText = new InputText(OpenedFile);

                });
            }
        }

        private void FillWordsList(List<string> words)
        {
            words = words.Distinct().ToList();

            for (int i = 0; i < words.Count; i++)
            {
                Words.Add(new Word(words[i], WordsCounter.CountedValues[i]));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}