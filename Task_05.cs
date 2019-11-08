using System;


namespace Example_005 {
    public class Task_05 {
        /// <summary>
        /// Вспомогательные методы
        /// </summary>
        private Helper _helper = new Helper();
        
        /// <summary>
        /// Функция Аккермана
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private int AkkermannFunc(int n, int m) {
            if(n == 0) {
                return m + 1;
            }

            if(n != 0 && m == 0) {
                return AkkermannFunc(n - 1, 1);
            }

            return AkkermannFunc(n - 1, AkkermannFunc(n, m - 1));
        }
        
        public void Start() {
            Console.WriteLine("\nЗадание 5");
            Console.WriteLine("Вычисление функции Аккермана\n");
            
            Console.WriteLine("Введите первое число:");
            int userFirstNum = _helper.ParseUserInput(Console.ReadLine());
            
            Console.WriteLine("Введите второе число:");
            int userSecondNum = _helper.ParseUserInput(Console.ReadLine());

            int result = AkkermannFunc(userFirstNum, userSecondNum);
            Console.WriteLine($"\nРезультат: {result}");

            _helper.PressAnyKey();
        }
    }
}