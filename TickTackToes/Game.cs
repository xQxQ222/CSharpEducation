using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToes
{
    public class Game
    {
        private const FieldFillType NOUGHT = FieldFillType.NOUGHT;

        private const FieldFillType CROSS = FieldFillType.CROSS;

        private const string MENU = "1)Играть\n2)Выход";

        private const string TABLE_HEADER = " ------------ ";

        private Field field { get; }

        public Game(int fieldSize)
        {
            this.field = new Field(fieldSize);
        }

        public void Start()
        {
            int movesCount = 0;
            while (true)
            {
                Console.WriteLine(MENU);
                int choise = 0;

                if (int.TryParse(Console.ReadLine(), out choise))
                {
                    switch (choise)
                    {
                        case 1:
                            Console.Clear();
                            bool isWin = false;
                            FieldFillType player = FieldFillType.EMPTY;
                            const int cellsNeedToFill = 9;
                            while (isWin == false)
                            {
                                if (movesCount == cellsNeedToFill)
                                    break;
                                PrintGameField();
                                bool isMoveSuccess = false;
                                int[] coordinates = InputMove(movesCount % 2 == 0 ? CROSS : NOUGHT);
                                if (coordinates != null && coordinates.Length == 2)
                                {
                                    player = movesCount % 2 == 0 ? CROSS : NOUGHT;
                                    field.MakeMove(coordinates[0], coordinates[1], player, ref isWin, ref isMoveSuccess);
                                    if (isMoveSuccess)
                                        movesCount++;
                                }
                                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            PrintGameField();
                            Console.WriteLine((movesCount == cellsNeedToFill && !isWin) ? "Ничья!" : ("Игра окончена! Победитель: " + (player.Equals(CROSS) ? "крестики" : "нолики")));

                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Выберите пункт из списка!");
                            continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }
        }

        private int[] InputMove(FieldFillType player)
        {
            int[] coordinates = null;
            Console.WriteLine($"Сейчас ходят {(player.Equals(CROSS) ? "крестики" : "нолики")}");
            Console.Write("Введите через пробел координаты (x,y), где (1,1) - левый верхний угол: ");
            try
            {
                coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (coordinates.Length != 2)
                {
                    throw new Exception("Нужно ввести 2 координаты!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Неправильный ввод!");
            }
            return coordinates;

        }

        private void PrintGameField()
        {
            for (int i = 0; i < field.fieldSize; i++)
            {
                for (int j = 0; j < field.fieldSize; j++)
                {

                    if (i == 0 && j == 0)
                    {
                        Console.WriteLine(TABLE_HEADER);
                    }
                    if (j == 0)
                    {

                        Console.Write("| ");
                    }
                    var fieldType = field.field[i, j];
                    Console.Write(fieldType == CROSS ? " X |" : (fieldType == NOUGHT ? " O |" : " * |"));
                }
                Console.WriteLine(i == field.fieldSize - 1 ? "\n" + TABLE_HEADER : "\n");
            }

        }

    }
}
