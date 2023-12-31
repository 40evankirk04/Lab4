﻿using System.IO;
using Microsoft.Win32;

namespace Task3.Models
{
    internal class TextFile
    {
        private readonly OpenFileDialog openFileDialog = new()
        {
            Filter = "Text files (*.txt)|*.txt"
        };

        public TextFile()
        {
            _filePath = Open();
            _fileName = GetFileName();
        }

        public TextFile(string none = "") { }

        private string? _filePath;
        public string? FilePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                _filePath = value;
            }
        }

        private string? _fileName;
        public string? FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        private string? Open()
        {
            bool? success = openFileDialog.ShowDialog();

            if (success == true)
                return openFileDialog.FileName;
            else
                return null;
        }

        private string? GetFileName()
        {
            if (FilePath is null) return null;

            else
                return Path.GetFileName(openFileDialog.FileName);
        }

        public List<string> GetAllFiles()
        {
            return Directory.GetFiles("Texts", "*", SearchOption.TopDirectoryOnly).ToList();
        }
    }
}
