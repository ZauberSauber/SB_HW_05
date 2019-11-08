using System;


namespace Example_005 {
    public class Task_05 {
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
            int userFirstNum = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            
            Console.WriteLine("Введите второе число:");
            int userSecondNum = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            int result = AkkermannFunc(userFirstNum, userSecondNum);
            Console.WriteLine($"\nРезультат: {result}");

            Helper helper = new Helper();
            helper.PressAnyKey();
        }
    }
}