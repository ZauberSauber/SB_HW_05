using System;

namespace Example_005 {
    public class Task_04 {
        /// <summary>
        /// Метод определяет является ли
        /// переданная последовательность арифметической
        /// или геометрической прогрессией
        /// </summary>
        /// <param name="numbers">Передавемая последовательность чисел</param>
        /// <returns></returns>
        private void IsProgression(int[] numbers) {
            int firstNumber = numbers[0];
            int diff = numbers[1] - firstNumber;
            double denom = numbers[1] / firstNumber;
            bool isArithmetic = false;
            bool isGeometric = false;

            for(int i = 2; i < numbers.Length; i++) {
                if(numbers[i] == firstNumber + (i) * diff) {
                    isArithmetic = true;
                } else if(numbers[i] == firstNumber*Math.Pow(denom, i)) {
                    isGeometric = true;
                } else {
                    isArithmetic = false;
                    isGeometric = false;
                }
            }

            if(isArithmetic) {
                Console.WriteLine("Последовательность является арифметической прогрессией");
            } else if(isGeometric) {
                Console.WriteLine("Последовательность является геометрической прогрессией");
            } else {
                Console.WriteLine("Последовательность не является ни арифметической, ни геометрической прогрессией");
            }
        }
        
        public void Start() {
            Console.WriteLine("\nЗадание 4");
            Console.WriteLine("Выяснить является ли заданная последовательность элементами арифметической или геометрической прогрессией");
            
            int temp;
            bool isNumber;
            string[] numbersStr;
            int[] numbers = new int[0];
            
            Console.Write("Введите последовательность целых чисел через пробел:\n");
            numbersStr = Console.ReadLine().Split(' ', ',', '.');
            
            for (int i = 0; i < numbersStr.Length; i++) {
                isNumber = int.TryParse(numbersStr[i], out temp);
                if(isNumber) {
                    Array.Resize(ref numbers, numbers.Length + 1);
                    numbers[numbers.Length - 1] = temp;
                }
            }

            IsProgression(numbers);

            Helper helper = new Helper();
            helper.PressAnyKey();
        }
    }
}