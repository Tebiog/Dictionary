using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Linq;

namespace dictionaries
{
    internal class MyDictionary
    {
        List<Word> _words;
        DictionaryType _dictionaryType;
        
        public DictionaryType DictionaryType { get { return _dictionaryType; } }
        public MyDictionary(DictionaryType dictionaryType)
        {
            _words = new List<Word>();
            _dictionaryType = dictionaryType;
            if (!Directory.Exists(dictionaryType.ToString()))
            {
                Directory.CreateDirectory(dictionaryType.ToString());
            }
            else
            {
               DirectoryInfo directoryInfo = new DirectoryInfo(dictionaryType.ToString());
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    AddFromFile(file.FullName.ToString());
                }
            }
        }
        public void AddWord(string first_version, string second_version)
        {
            foreach (var item in _words)
            {
                if (item.FirstMeaning == first_version)
                {
                    item.AddMeaning(second_version);
                    return;
                }
            }
            Word word = new Word(first_version);
            word.AddMeaning(second_version);
            _words.Add(word);
        }
        public void RemoveWord(Word word)
        {
            _words.Remove(word);
            if (File.Exists($@"{_dictionaryType.ToString()}\{word.FirstMeaning}.json"))
            {
                File.Delete($@"{_dictionaryType.ToString()}\{word.FirstMeaning}.json");
            }
        }
        public void RemoveWord(string first_tranlation)
        {
            foreach(var word in _words)
            {
                if(word.FirstMeaning == first_tranlation)
                {
                    _words.Remove(word);
                    break;
                }
            }
            if (File.Exists($@"{_dictionaryType.ToString()}\{first_tranlation}.json"))
            {
                File.Delete($@"{_dictionaryType.ToString()}\{first_tranlation}.json");
            }

        }
        public List<string> FindWordTranslation(string word)
        {
            foreach (var item in _words)
            {
                if (item.FirstMeaning == word)
                {
                    return item.SecondMeaning;
                }
            }
            return null;
        }
        public void UploadToFile()
        {
            string pathBase = _dictionaryType.ToString();
            string path;
            string jString;
            foreach (var word in _words)
            {
                path = $@"{pathBase}\{word.FirstMeaning}.json";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                jString = JsonSerializer.Serialize(word);
                File.WriteAllText(path, jString);
            }
            Console.ReadKey();
        }

        public void AddFromFile(string path)
        {
            string jString = File.ReadAllText(path);
            Word word = JsonSerializer.Deserialize<Word>(jString);
            _words.Add(word);
        }
        public Word GetWord(string first_version)
        {
            foreach (var item in _words)
            {
                if (item.FirstMeaning == first_version)
                {
                    return item;
                }
            }

            return null;
        }
        public void PrintArr()
        {
            foreach(var word in _words)
            {
                Console.WriteLine(word.FirstMeaning);
                foreach(string word2 in word.SecondMeaning)
                {
                    Console.Write($"\t{word2}");
                }
            }
        }
    }
}
