using System;

namespace Example_005 {
    /// <summary>
    /// Выводит сообщение о завешении программы
    /// </summary>
    class Helper {
        public void PressAnyKey() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nРабота программы завершена, нажмите любую клавишу для выхода");
            Console.ReadLine();
        }
    }
}