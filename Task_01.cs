using System;
using MathNet.Numerics.LinearAlgebra;

namespace Example_005 {
    public class Task_01 {
        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random randomize;
         
        /// <summary>
        /// Вспомогательные методы
        /// </summary>
        private Helper _helper = new Helper();
        
        /// <summary>
        /// Отступ между числами в матрице
        /// </summary>
        private int Padding = 6;
        
        /// <summary>
        /// Пользвотельский выбор операции над матрицами
        /// </summary>
        private string userAction;
        
        /// <summary>
        /// Кол-во столбцов для матрицы 1
        /// </summary>
        private int userRows_1;

        /// <summary>
        /// Кол-во строк для матрицы 1
        /// </summary>
        private int userColumns_1;

        /// <summary>
        /// Кол-во столбцов для матрицы 2
        /// </summary>
        private int userRows_2;

        /// <summary>
        /// Кол-во строк для матрицы 2
        /// </summary>
        private int userColumns_2;
        
        /// <summary>
        /// Первая матрица
        /// </summary>
        private Matrix<double> _firstMatrix;

        /// <summary>
        /// Вторая матрица
        /// </summary>
        private Matrix<double> _secondMatrix;

        /// <summary>
        /// Результирующая матрица
        /// </summary>
        private Matrix<double> _resultMatrix;
        

        /// <summary>
        /// Метод получения формата строки
        /// </summary>
        /// <param name="index"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        private string GetFormat(int index, int padding) {
            return "{" + index + "," + padding + "}";
        }
        
         /// <summary>
         /// Получение случайного числа
         /// </summary>
         /// <returns></returns>
        private int GetRandomValue() {
            return randomize.Next(11);
        }

        /// <summary>
        /// Получение от пользователя размеров для 1 матрицы
        /// </summary>
        private void AskSizesOnce() {
            Console.WriteLine("Сколько строк в матрице?");
            userRows_1 = _helper.ParseUserInput(Console.ReadLine());
            
            Console.WriteLine("Сколько столбцов в матрице?");
            userColumns_1 = _helper.ParseUserInput(Console.ReadLine());
        }

        /// <summary>
        /// Получение от пользователя размеров для 2х матриц
        /// </summary>
        private void AskSizesTwice() {
            Console.WriteLine("Сколько строк в первой матрице?");
            userRows_1 = _helper.ParseUserInput(Console.ReadLine());
            
            Console.WriteLine("Сколько столбцов в первой матрице?");
            userColumns_1 = _helper.ParseUserInput(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nПри умножении кол-во строк во второй матрице ровно числу столбцов в первой\n");
            userRows_2 = userColumns_1;
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Сколько столбцов во второй матрице?");
            userColumns_2 = _helper.ParseUserInput(Console.ReadLine());
        }

        /// <summary>
        /// Метод опрации сложения
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        private Matrix<double> Addition(Matrix<double> firstMatrix, Matrix<double> secondMatrix) {
            return firstMatrix + secondMatrix;
        }

        /// <summary>
        /// Метод операции вычитания
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        private Matrix<double> Subtraction(Matrix<double> firstMatrix, Matrix<double> secondMatrix) {
            return firstMatrix - secondMatrix;
        }

        /// <summary>
        /// Метод операции умножения
        /// </summary>
        public Matrix<double> Multiplication(Matrix<double> firstMatrix, Matrix<double> secondMatrix) {
            return firstMatrix.Multiply(secondMatrix);
        }

        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="multiNumber"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        public Matrix<double> Multiplication(int multiNumber, Matrix<double> secondMatrix) {
            return Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x, y) => secondMatrix[x, y] * multiNumber);
        }

        /// <summary>
        /// Выводит матрицу в консоль
        /// </summary>
        /// <param name="matrix"></param>
        private void PrintMatrix(Matrix<double> matrix) {
            string format;
            
            int columnCount;
            int rowCount;
            
            rowCount = matrix.Column(0).Count;
            columnCount = matrix.Row(0).Count;
            
            string[] row = new string[columnCount];
            
            for (int i = 0; i < rowCount; i++) {
                format = "";
                for (int j = 0; j < columnCount; j++) {
                    format += GetFormat(j, Padding);
                    row[j] = Convert.ToString(matrix[i, j]);
                }
                Console.WriteLine(format, row);
            }
        }

        /// <summary>
        /// Отправляет матрицы на вывод в консоль 
        /// </summary>
        private void PrintResult(Matrix<double> firstMatrix, Matrix<double> secondMatrix, Matrix<double> resultMatrix) {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintMatrix(firstMatrix);
            
            // печать знака выполняемой операции над матрицами
            int columns = firstMatrix.Row(0).Count;
            int center = (Padding * columns / 2) + (Padding / 2);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch (userAction) {
                case "1":
                    Console.WriteLine("{0," + center + "}", "+");
                    break;
                case "2":
                    Console.WriteLine("{0," + center + "}", "-");
                    break;
                case "3":
                    Console.WriteLine("{0," + center + "}", "*");
                    break;
                case "4":
                    Console.WriteLine("{0," + center + "}", "*");
                    break;
            }
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintMatrix(secondMatrix);
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("{0," + center + "}", "=");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintMatrix(resultMatrix);
        }

        /// <summary>
        /// Действия по сложению матриц
        /// </summary>
        private void AdditionActions() {
            AskSizesOnce();
            
            _firstMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _secondMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _resultMatrix = Addition(_firstMatrix, _secondMatrix);
            
            PrintResult(_firstMatrix, _secondMatrix, _resultMatrix);
        }

        /// <summary>
        /// Действия по вычитанию матриц
        /// </summary>
        private void SubtractionActions() {
            AskSizesOnce();
            
            _firstMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _secondMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _resultMatrix = Subtraction(_firstMatrix, _secondMatrix);
            
            PrintResult(_firstMatrix, _secondMatrix, _resultMatrix);
        }

        /// <summary>
        /// Действия по умножению матриц
        /// </summary>
        private void MultiplicationActions() {
            AskSizesTwice();
            
            _firstMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _secondMatrix = Matrix<double>.Build.Dense(userRows_2, userColumns_2, (x,y) => GetRandomValue());
            _resultMatrix = Multiplication(_firstMatrix, _secondMatrix);
            
            PrintResult(_firstMatrix, _secondMatrix, _resultMatrix);
        }

        /// <summary>
        /// Действия по умножению матрицы на число
        /// </summary>
        private void MultiplicationByNumberActions() {
            Console.WriteLine("На какое число будем умножать?");
            
            int userNum = _helper.ParseUserInput(Console.ReadLine(), true);
            _firstMatrix = Matrix<double>.Build.Dense(1, 1, userNum);
            
            AskSizesOnce();
            _secondMatrix = Matrix<double>.Build.Dense(userRows_1, userColumns_1, (x,y) => GetRandomValue());
            _resultMatrix = Multiplication(userNum, _secondMatrix);
            
            PrintResult(_firstMatrix, _secondMatrix, _resultMatrix);
        }
        
        public void Start() {
            Console.Clear();
            Console.WriteLine("\nЗадание 1 «Создание методов из прошлошлого ДЗ»");
            Console.WriteLine("«Манипуляции с матрицами»\n");
            
            Console.WriteLine("Будем складывать, вычитать, умножать?\n");
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - хочу сложить матрицы");
            Console.WriteLine("2 - хочу вычесть из матрицы матрицу");
            Console.WriteLine("3 - хочу перемножить матрицы");
            Console.WriteLine("4 - хочу умножть матрицу на число");

            userAction = Console.ReadLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            
            randomize = new Random();
            
            // создание и обработка матриц исходя из выбора пользователя
            switch (userAction) {
                case "1":
                    AdditionActions();
                    break;
                case "2":
                    SubtractionActions();
                    break;
                case "3":
                    MultiplicationActions();
                    break;
                case "4":
                    MultiplicationByNumberActions();
                    break;
                default:
                    AdditionActions();
                    break;
            }
            
            _helper.PressAnyKey();
        }
    }
}