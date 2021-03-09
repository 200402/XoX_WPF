namespace XoX_attempt_1
{
    class Game
    {
        private bool player_is_zero = true;
        private bool pvp = true;
        private int turn_number = 0;
        private int[,] game_field = new int[3, 3];
        private const int zero_number = 1;
        private const int cross_number = -1;
        // в идеале 
        //(zero_number = cross_number * -1)

        public void Side_zero()
        {
            player_is_zero = true;
        }
        public void Side_cross()
        {
            player_is_zero = false;
        }

        public bool Is_player_zero()
        {
            return player_is_zero;
        }

        public void New_game()
        {
            turn_number = 0;
            game_field = new int[3, 3];
        }

        public void New_turn(int x_coordinate, int y_coordinate)
        {
            if (Place_is_free(x_coordinate, y_coordinate))
            {
                if (Is_turn_zero())
                    game_field[x_coordinate, y_coordinate] = zero_number;
                else
                    game_field[x_coordinate, y_coordinate] = cross_number;
                turn_number++;
            }
        }
        public bool Is_turn_zero()
        {
            return turn_number % 2 == 0;
        }

        public bool Place_is_free(int x_coordinate, int y_coordinate)
        {
            return game_field[x_coordinate, y_coordinate] == 0;
        }

        public int Victory_check()
        {
            int win = Horizontal_win();
            win += Vertically_win();
            win += Diagonal_win();

            if (win > 0)
            {
                win = zero_number;
                turn_number = 0;
            }
            else if (win < 0)
            {
                win = cross_number;
                turn_number = 0;
            }
            return win;
        }

        private int Diagonal_win()
        {
            int sum_of_symbols = 0;
            sum_of_symbols += game_field[0, 0];
            sum_of_symbols += game_field[1, 1];
            sum_of_symbols += game_field[2, 2];

            if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                return sum_of_symbols / 3;

            sum_of_symbols = 0;
            sum_of_symbols += game_field[0, 2];
            sum_of_symbols += game_field[1, 1];
            sum_of_symbols += game_field[2, 0];

            if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                return sum_of_symbols / 3;

            return 0;
        }

        private int Vertically_win()
        {
            int sum_of_symbols = 0;
            for (int i = 0; i < game_field.GetLength(1); i++)
            {
                for (int ii = 0; ii < game_field.GetLength(0); ii++)
                    sum_of_symbols += game_field[i, ii];

                if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                    return sum_of_symbols / 3;
            }
            return 0;
        }

        private int Horizontal_win()
        {
            int sum_of_symbols = 0;
            for (int i = 0; i < game_field.GetLength(0); i++)
            {
                for (int ii = 0; ii < game_field.GetLength(1); ii++)
                    sum_of_symbols += game_field[i, ii];

                if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                    return sum_of_symbols / 3;
            }
            return 0;
        }
    }
}
