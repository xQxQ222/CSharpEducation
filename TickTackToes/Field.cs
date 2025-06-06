﻿namespace TickTackToes
{
    public class Field
    {
        private const int FIRST_CELL_X_POSITION = 1;
        private const int FIRST_CELL_Y_POSITION = 1;
        private const FieldFillType EMPTY_CELL = FieldFillType.EMPTY;
        public FieldFillType[,] field { get; }

        public int fieldSize { get; }
        public Field(int fieldSize)
        {
            this.fieldSize = fieldSize;
            field = new FieldFillType[fieldSize, fieldSize];
        }

        public void MakeMove(int x, int y, FieldFillType playerType, ref bool isWin, ref bool isSuccessMove)
        {
            if (CheckFillOfCell(x, y))
            {
                field[x - 1, y - 1] = playerType;
                if (!CheckForWin(x, y).Equals(EMPTY_CELL))
                {
                    isWin = true;
                }
                isSuccessMove = true;
            }
            else
                isSuccessMove = false;
        }

        private bool CheckFillOfCell(int x, int y)
        {
            if (x < FIRST_CELL_X_POSITION || x > field.GetLength(0) || y < FIRST_CELL_Y_POSITION || y > field.GetLength(1))
            {
                Console.WriteLine("Клетка находится за пределами поля");
                return false;
            }
            if (!field[x - 1, y - 1].Equals(EMPTY_CELL))
            {
                Console.WriteLine("Эта клетка уже заполнена! Введите другую");
                return false;
            }
            return true;
        }

        private FieldFillType CheckForWin(int x, int y)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                if (CheckLine(0, i, 1, 0))
                    return field[i, 0];
            }

            for (int j = 0; j < fieldSize; j++)
            {
                if (CheckLine(j, 0, 0, 1))
                    return field[0, j];
            }

            if (CheckLine(0, 0, 1, 1))
                return field[0, 0];

            if (CheckLine(0, fieldSize - 1, 1, -1))
                return field[0, fieldSize - 1];

            return FieldFillType.EMPTY;
        }

        private bool CheckLine(int startX, int startY, int dx, int dy)
        {
            FieldFillType symbol = field[startY, startX];
            if (symbol is EMPTY_CELL)
                return false;

            for (int i = 0; i < fieldSize; i++)
            {
                int x = startX + i * dx;
                int y = startY + i * dy;
                if (!field[y, x].Equals(symbol))
                    return false;
            }
            return true;
        }
    }
}
