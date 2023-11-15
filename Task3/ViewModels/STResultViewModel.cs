using Task3.Models;

namespace Task3.ViewModels
{
    internal class STResultViewModel
    {
        private SortingTester _selectSortingTester;
        private SortingTester _abcSortingTester;

        private readonly SelectSorting _selectSorting = new();
        private readonly ABCSorting _abcSorting = new();

        private readonly TextFile _textFile = new("none");
        private readonly InputText _inputedText = new();

        private readonly List<SortingTester> _testersOfSelectSorting = new();
        public List<SortingTester> TestersOfSelectSorting
        {
            get
            {
                return _testersOfSelectSorting;
            }
        }

        private readonly List<SortingTester> _testersOfABCSorting = new();
        public List<SortingTester> TestersOfABCSorting
        {
            get
            {
                return _testersOfABCSorting;
            }
        }

        public void Start()
        {
            foreach(var path in _textFile.GetAllFiles())
            {
                _selectSortingTester = new();
                _abcSortingTester = new();

                _inputedText.GetTextFromFile(path);

                _selectSortingTester.SortingToTest = _selectSorting.Sort;
                _selectSortingTester.TestSorting(_inputedText.Text);

                _testersOfSelectSorting.Add(_selectSortingTester);

                _abcSortingTester.SortingToTest = _abcSorting.Sort;
                _abcSortingTester.TestSorting(_inputedText.Text);

                _testersOfABCSorting.Add(_abcSortingTester);
            }
        }
    }
}
