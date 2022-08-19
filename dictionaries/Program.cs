using System;
using System.Text;

namespace dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {

                Console.Clear();
                int choose;
                Console.WriteLine("\tМеню программы");
                Console.WriteLine("1. Добавить слово");
                Console.WriteLine("2. Добавить перевод к слову");
                Console.WriteLine("3. Изменить перевод слова");
                Console.WriteLine("4. Изменить слово");
                Console.WriteLine("5. Удалить слово");
                Console.WriteLine("6. Удалить перевод");

                MyDictionary dictionary = new MyDictionary(DictionaryType.RussianEnglish);
                choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) == null)
                    {
                        Console.Clear();
                        Console.Write("Введите перевод: ");
                        string trans = Console.ReadLine();
                        dictionary.AddWord(word, trans);
                        Console.WriteLine("Слово успешно добавлено!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Данного слова уже было в словаре! Выберите 2-ой или 3-ий пункт для изминения слова в словре!");
                        Console.ReadKey();
                    }
                }
                if (choose == 2)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) != null)
                    {
                        Console.Clear();
                        Console.Write("Введите перевод: ");
                        string translation = Console.ReadLine();
                        dictionary.AddWord(word, translation);
                        Console.WriteLine("Перевод успешно добавлен!");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Данного слова не было в словаре! Выберите 1-ой пункт для добавления слова к слову!");
                        Console.ReadKey();
                    }
                }
                if (choose == 3)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) != null)
                    {
                        Console.Clear();
                        Console.Write("Введите старый перевод: ");
                        string old_translation = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Введите перевод: ");
                        string translation = Console.ReadLine();
                        dictionary.GetWord(word).ChangeTranslation(old_translation, translation);
                       
                    }
                    else
                    {
                        Console.WriteLine("Данного слова не было в словаре! Выберите 1-ой пункт для добавления слова к слову!");
                        Console.ReadKey();
                    }

                }
                if(choose == 4)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) != null)
                    {
                        Console.Clear();
                        Console.Write("Введите перевод: ");
                        string translation = Console.ReadLine();
                        dictionary.GetWord(word).ChangeFirstTranslation(word, translation, dictionary.DictionaryType);

                    }
                    else
                    {
                        Console.WriteLine("Данного слова не было в словаре! Выберите 1-ой пункт для добавления слова к слову!");
                        Console.ReadKey();
                    }

                }
                if(choose == 5)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) != null)
                    {
                        Console.Clear();
                        dictionary.RemoveWord(word);

                    }
                        Console.WriteLine("Операция по удалению слова прошла успешно");                   
                }
                if(choose == 6)
                {
                    Console.Clear();
                    Console.Write("Введите слово: ");
                    string word = Console.ReadLine();
                    if (dictionary.GetWord(word) != null)
                    {
                        Console.Clear();
                        Console.Write("Введите перевод: ");
                        string translation = Console.ReadLine();
                        dictionary.GetWord(word).RemvoveTranslation(translation);
                    }
                    else
                    {
                        Console.WriteLine("Данного слова нет в словаре! Выберите 1 пункт дабы добавить его.");
                    }

                }
                dictionary.UploadToFile();
            }
        }
    }
}
