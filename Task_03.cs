using System;

namespace Example_005 {
    public class Task_03 {
        /// <summary>
        /// Удаляет повторяющиеся символы
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string RemoveExtraChar(string text) {
            char temp = text[0];
            string newText = "" + temp;
            
            for(int i = 0; i < text.Length; i++) {
                if(text[i] != temp) {
                    temp = text[i];
                    newText += temp;
                }
            }

            return newText;
        }
        
        public void Start() {
            Console.WriteLine("\nЗадание 3 Удаление повторяющихся символов\n");
            Console.WriteLine("Введите текст со множеством повторений:");
            
            string text = Console.ReadLine();
            
            text = RemoveExtraChar(text.ToLower());
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nНовый текст: \n{text}");
            
            Helper helper = new Helper();
            helper.PressAnyKey();
        }
    }
}