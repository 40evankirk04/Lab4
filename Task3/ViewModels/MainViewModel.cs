using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;
using Task3.Views;

namespace Task3.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ABCSorting _abcSorting;
        public ABCSorting ABCSorting
        {
            get
            {
                return _abcSorting;
            }

            set
            {
                _abcSorting = value;
            }
        }

        private SelectSorting _selectSorting;
        public SelectSorting SelectSorting
        {
            get
            {
                return _selectSorting;
            }
            set
            {
                _selectSorting = value;
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
            }
        }

        private readonly List<Word> _words = new();
        public List<Word> Words
        {
            get
            {
                return _words;
            }
        }

        private RelayCommand _openABCSortingWindowCommand;
        public RelayCommand OpenABCSortingWindowCommand
        {
            get
            {
                return _openABCSortingWindowCommand ??= new RelayCommand(obj =>
                {
                    Words.Clear();

                    ABCSorting = new(InputedText.Text);
                    WordsCounter = new(ABCSorting.SortedList);

                    FillWordsList(ABCSorting.SortedList);

                    ABCSortWindow abcSortWindow = new()
                    {
                        DataContext = this
                    };

                    abcSortWindow.Show();

                }, (obj) => OpenedFile?.FileName is not null); 
            }
        }

        private RelayCommand _openSelectSortingWindowCommand;
        public RelayCommand OpenSelectSortingWindowCommand
        {
            get
            {
                return _openSelectSortingWindowCommand ??= new RelayCommand(obj =>
                {
                    Words.Clear();

                    SelectSorting = new(InputedText.Text);
                    WordsCounter = new(SelectSorting.SortedList);

                    FillWordsList(SelectSorting.SortedList);

                    SelectSortWindow selectSortWindow = new()
                    {
                        DataContext= this
                    };

                    selectSortWindow.Show();

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

        private RelayCommand _testCommand;
        public RelayCommand TestCommand
        {
            get
            {
                return _testCommand ??= new RelayCommand(obj => {

                    STResultViewModel _STResultviewModel = new();

                    _STResultviewModel.Start();

                    STResultWindow STResultWindow = new STResultWindow()
                    {
                        DataContext = _STResultviewModel
                    };

                    STResultWindow.Show();
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