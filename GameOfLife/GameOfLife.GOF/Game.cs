using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GOF
{
    public class Game
    {
        public int[,] GetNextGeneration(int[,] state)
        {
            state = AddBorder(state);
            int[,] nextState = new int[state.GetLength(0), state.GetLength(1)];

            for (int i = 1; i < state.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < state.GetLength(1) - 1; j++)
                {
                    int item = state[i, j];
                    int neighbor = GetNeighborCount(state, i, j);
                    nextState[i, j] = GetNextState(item, neighbor);
                }
            }
            nextState = RemoveBorder(nextState);
            return nextState;
        }

        private int GetNextState(int item, int neighbor)
        {
            if (StayAliveRule(item, neighbor))
            {
                return 1;
            }
            if (DieRule(item, neighbor))
            {
                return 0;
            }
            if (ReviveRule(item, neighbor))
            {
                return 1;
            }
            return 0;
        }

        private bool ReviveRule(int item, int neighbor)
        {
            return item == 0 && neighbor == 3;
        }

        private bool DieRule(int item, int neighbor)
        {
            return item == 1 && (neighbor < 2 || neighbor > 3);
        }

        private bool StayAliveRule(int item, int neighbor)
        {
            return item == 1 && (neighbor == 2 || neighbor == 3);
        }

        private int GetNeighborCount(int[,] state, int i, int j)
        {
            int neighbor = 0;
            for (int n = -1; n < 2; n++)
            {
                for (int p = -1; p < 2; p++)
                {
                    if (state[i + n, j + p] == 1) neighbor++;
                }
            }
            if (state[i, j] == 1) neighbor--;
            return neighbor;
        }

        private int[,] AddBorder(int[,] state)
        {
            int[,] border = new int[state.GetLength(0) + 2, state.GetLength(1) + 2];
            for (int i = 0; i < state.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < state.GetLength(1) - 1; j++)
                {
                    border[i + 1, j + 1] = state[i, j];
                }
            }
            return border;
        }

        private int[,] RemoveBorder(int[,] state)
        {
            int[,] border = new int[state.GetLength(0) - 2, state.GetLength(1) - 2];
            for (int i = 1; i < state.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < state.GetLength(1) - 1; j++)
                {
                    border[i - 1, j - 1] = state[i, j];
                }
            }
            return border;
        }


    }


}
