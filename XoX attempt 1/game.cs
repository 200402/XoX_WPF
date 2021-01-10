using System;
using System.Collections.Generic;
using System.Text;

namespace XoX_attempt_1
{
    class game
    {
        private int zero_number = 1;
        private int cross_number = 10;
        private bool turn_player = true;
        private bool turn_zero = true;
        private int turn_number = 0;
        private int[,] game_field = new int[3, 3];

        public void new_turn (int x_coordinate, int y_coordinate)
        {
            if (turn_zero)
                game_field[x_coordinate, y_coordinate] = zero_number;
            else
                game_field[x_coordinate, y_coordinate] = cross_number;
        }
    }
}
