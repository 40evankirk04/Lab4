﻿using System.Diagnostics;

namespace Task3.Models
{
    internal class SortingTester
    {
        private readonly Stopwatch _stopWatch = new();

        public Action<List<string>>? SortingToTest { get; set; }

        private long _timeOfSorting;
        public long TimeOfSorting
        {
            get
            {
                return _timeOfSorting;
            }

            set
            {
                _timeOfSorting = value;
            }
        }

        public List<string> TestSorting(List<string> wordsToSort)
        {
            if (wordsToSort == null || SortingToTest == null)
                return new List<string>();

            _stopWatch.Start();

            SortingToTest.Invoke(wordsToSort);

            _stopWatch.Stop();

            _timeOfSorting = _stopWatch.ElapsedMilliseconds;

            _stopWatch.Reset();

            return wordsToSort;
        }
    }
}