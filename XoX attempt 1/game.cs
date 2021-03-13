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
        public bool Is_turn_zero()
        {
            return turn_number % 2 == 0;
        }

        public bool Place_is_free(int x_coordinate, int y_coordinate)
        {
            return game_field[x_coordinate, y_coordinate] == 0;
        }

        public string Victory_check()
        {
            string win = Horizontal_win();
            if (win == "nobody") 
                win = Vertically_win();
            {
                if (win == "nobody")
                {
                    win = Diagonal_win();
                    if (win == "nobody" && turn_number == 9)
                        return "draw";
                }
            }
            return win;
        }

        private string Diagonal_win()
        {
            int sum_of_symbols = 0;
            sum_of_symbols += game_field[0, 0];
            sum_of_symbols += game_field[1, 1];
            sum_of_symbols += game_field[2, 2];

            if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                return who_win(sum_of_symbols);

            sum_of_symbols = 0;
            sum_of_symbols += game_field[0, 2];
            sum_of_symbols += game_field[1, 1];
            sum_of_symbols += game_field[2, 0];

            if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                return who_win(sum_of_symbols);
        
            return "nobody";
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

        private string Vertically_win()
        {
            for (int i = 0; i < game_field.GetLength(1); i++)
            {
                int sum_of_symbols = 0;
                for (int ii = 0; ii < game_field.GetLength(0); ii++)
                    sum_of_symbols += game_field[i, ii];

                if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                    return who_win(sum_of_symbols);
            }
            return "nobody";
        }

        private string Horizontal_win()
        {
            for (int i = 0; i < game_field.GetLength(0); i++)
            {
                int sum_of_symbols = 0;
                for (int ii = 0; ii < game_field.GetLength(1); ii++)
                    sum_of_symbols += game_field[ii, i];

                if (sum_of_symbols == zero_number * 3 || sum_of_symbols == cross_number * 3)
                    return who_win(sum_of_symbols);
            }
            return "nobody";
        }

        private string who_win(int sum_of_symbols)
        {
            if (sum_of_symbols / 3 == zero_number)
                return "zero";
            else
                return "cross";
        }
    }
}
