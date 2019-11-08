using System;


namespace Example_005 {
    public class Task_02 {
        /// <summary>
        /// Разбиение строки на массив с последующей сортировкой
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string[] SplitAndSort(string text) {
            string[] words = text.Split(' ', '.', ',');
            
            for(int i = 0; i < words.Length; i++) {
                string temp = words[i];
                int j = i - 1;
                
                while(j >= 0 && temp.Length < words[j].Length) {
                    words[j + 1] = words[j];
                    j--;
                }
                words[j + 1] = temp;
            }

            return words;
        }
        
        /// <summary>
        /// Вывод слов
        /// </summary>
        /// <param name="array">Массив строк</param>
        private void PrintWords(string[] array) {
            for(int i = 0; i < array.Length; i++) {
                Console.Write($"{array[i]} ");
            }
        }
        
        /// <summary>
        /// Поиск самых коротких слов
        /// </summary>
        /// <param name="text">Текст в котором надо найти слова</param>
        private string[] SearchShortestWords(string text) {
            string[] words;
            string[] shortestWords = new string[0];
            string shortestWord;
            
            words = SplitAndSort(text);
            shortestWord = words[0];
            
            foreach (string word in words) {
                if(word.Length == shortestWord.Length) {
                    Array.Resize(ref shortestWords, shortestWords.Length + 1);
                    shortestWords[shortestWords.Length - 1] = word;
                }
            }
            
            return shortestWords;
        }
        
        /// <summary>
        /// Поиск самых длинных слов
        /// </summary>
        /// <param name="text">Текст в котором нужно найти слова</param>
        private string[] SearchLongestWords(string text) {
            string[] words;
            string[] longestWords = new string[0];
            string longestWord;

            words = SplitAndSort(text);
            longestWord = words[words.Length - 1];
            
            foreach (string word in words) {
                if (word.Length == longestWord.Length) {
                    Array.Resize(ref longestWords, longestWords.Length + 1);
                    longestWords[longestWords.Length - 1] = word;
                }
            }
            
            return longestWords;
        }
        
        public void Start() {
            Console.WriteLine("\nЗадание 2 «Создать метод, принимающий  текст и возвращающий слова,");
            Console.WriteLine("содержащие минимальное и максимальное количество букв»\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите текст, в котором нужно произвести поиск");
            
            Console.ForegroundColor = ConsoleColor.White;
            string text = Console.ReadLine();
            
            Console.WriteLine("\nСамые короткие слова:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintWords(SearchShortestWords(text));
            
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nСамые длинные слова:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintWords(SearchLongestWords(text));

            Helper helper = new Helper();
            helper.PressAnyKey();
        }
    }
}