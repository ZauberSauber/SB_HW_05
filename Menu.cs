using System;


namespace Example_005 {
    class Menu {
        public void ShowMainMenu() {
            Task_01 task_01 = new Task_01();
            Task_02 task_02 = new Task_02();
            Task_03 task_03 = new Task_03();
            Task_04 task_04 = new Task_04();
            Task_05 task_05 = new Task_05();
            
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Привет, что будем делать?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - Операции с матрицами");
            Console.WriteLine("2 - Получение самых длинных слов");
            Console.WriteLine("3 - Удаление повторяющихся символов");
            Console.WriteLine("4 - Проверка на арифметическую или геометрическую прогрессию");
            Console.WriteLine("5 - Вычисление ф-ции Аккермана\n");
            
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine();
            
            switch(userInput) {
                case "1":
                    task_01.Start();
                    break; 
                case "2":
                    task_02.Start();
                    break;
                case "3":
                    task_03.Start();
                    break;
                case "4":
                    task_04.Start();
                    break;
                case "5":
                    task_05.Start();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nОшибка ввода, попробуйте ещё раз\n");
                    
                    ShowMainMenu();
                    break;
            }
        }
    }
}