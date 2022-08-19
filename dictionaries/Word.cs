using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace dictionaries
{
    internal class Word
    {
        public string FirstMeaning { get; set; }
        public List<string> SecondMeaning { get; set; }
        public Word(string firstMeaning)
        {
            FirstMeaning = firstMeaning;
            SecondMeaning = new List<string>();
        }
        public Word()
        {
            FirstMeaning = "";
            SecondMeaning = new List<string>();
        }
        public Word(string firstMeaning, List<string> secondMeaning)
        {
            FirstMeaning = firstMeaning;
            SecondMeaning = secondMeaning;
        }
        public void AddMeaning(string meaning)
        {
            SecondMeaning.Add(meaning);
        }
        public void ChangeFirstTranslation(string old_trans, string new_trans, DictionaryType dictionaryType)
        {
            if(old_trans == new_trans) { return; }
            if (FirstMeaning == old_trans)
            {
                FirstMeaning = new_trans;
                File.Delete($@"{dictionaryType}\{old_trans}.json");
            }
            else
            {
                Console.WriteLine("Данного слова не было в словаре! Выберите 1 вариант");
            }
        }
        public void ChangeTranslation(string old_trans, string new_trans)
        {
            if (old_trans == new_trans) { return; }
            if (SecondMeaning.Contains(old_trans))
            {
                SecondMeaning.Remove(old_trans);
                SecondMeaning.Add(new_trans);
                Console.WriteLine("Перевод успешно изменён!");
            }
            else
            {
                Console.WriteLine("Данного перевода не было в словаре! Выберите пункт 2");
            }
        }
        public void RemvoveTranslation(string trans)
        {
            if(SecondMeaning.Count > 1) { 
                if(SecondMeaning.Contains(trans))
                    SecondMeaning.Remove(trans);
                    Console.WriteLine("Перевод успешно удалено!");
                
            }
            else
            {
                Console.WriteLine("Невозможно удалить последний перевод!!");
            }
        }
        public override string ToString()
        {
            string result = $"\tFirst translation: {FirstMeaning}\n\t Second translations: ";
            foreach(var item in SecondMeaning)
            {
                result += $"\n\t\t{item}";
            }
            
            return result;
        }
    }
}
