using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3.Models;
using Task3.Views;

namespace Task3.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private RadixSort _radixSort;
        public RadixSort RadixSort
        {
            get
            {
                return _radixSort;
            }

            set
            {
                _radixSort = value;
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

        private RelayCommand _openRadixSortWindowCommand;
        public RelayCommand OpenRadixSortWindowCommand
        {
            get
            {
                return _openRadixSortWindowCommand ??= new RelayCommand(obj =>
                {
                    RadixSort = new(InputedText.Text);
                    WordsCounter = new(RadixSort.SortedList);

                    FillWordsList();

                    RadixSortWindow radixSortWindow = new()
                    {
                        DataContext = this
                    };

                    radixSortWindow.Show();

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

        private void FillWordsList()
        { 
            InputedText.DeleteDublicates();

            for (int i = 0; i < InputedText.Text.Count; i++)
            {
                Words.Add(new Word(InputedText.Text[i], WordsCounter.CountedValues[i]));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}