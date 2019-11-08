using System;

namespace Example_005 {
    class Helper {
        private Menu _menu = new Menu();
        
        /// <summary>
        /// Выводит сообщение о завешении программы
        /// </summary>
        public void PressAnyKey() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nРабота программы завершена, нажмите любую клавишу для выхода");
            Console.ReadLine();
        }

        /// <summary>
        /// Проверяет ввод пользователя на преобразование к числу
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="isNegativAllowed"></param>
        /// <returns></returns>
        public int ParseUserInput(string userInput = "1", bool isNegativAllowed = false) {
            bool isSuccess = Int32.TryParse(userInput, out int result);

            if (!isSuccess) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nОшибка ввода, вы будете перемещены в главное меню");
                Console.WriteLine("нажмите для продожения");

                Console.ReadKey();
                Console.Clear();
                _menu.ShowMainMenu();
            }

            if (!isNegativAllowed) {
                result = Math.Abs(result);
            }
            
            return result;
        }
    }
}