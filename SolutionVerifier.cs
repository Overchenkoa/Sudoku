public static class SolutionVerifier
{
    public static bool CheckChange(Board board, int x, int y, int num)
    {
        for(int c = 0; c < 9; c++)
        {
            if (board[x,c] == num) return false;
            if (board[c,y] == num) return false;
        }
        int squareX = x / 3 * 3, squareY = y / 3 * 3;
        for(int a = squareX; a < squareX + 3; a++)
        {
            for(int b = squareY; b < squareY + 3; b++)
            {
                if (board[a,b] == num) return false;
            }
        }
        return true;
    }
    
    public static bool IsFilledCorrectly(Board board)
    {
        bool result = true;
        int index = 0;
        while(index < 9 && result)
        {
            result = CheckColumn(index, board) && CheckRow(index, board) && CheckBox(index, board);
            index++;
        }
        return result;
    }
    private static bool CheckBox(int box, Board board)
    {
        List<int> nums = new List<int>();
        int[,] Box = board.GetBox(box);
        for(int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                if (nums.Contains(Box[x,y]) && Box[x,y] != 0) return false;
                else nums.Add(Box[x,y]);
            }    
        }
        return true;
    }
    private static bool CheckColumn(int x, Board board)
    {
        List<int> nums = new List<int>();
        int[] Column = board.GetColumn(x);
        for(int i = 0; i < 0; i++)
        {
            if (nums.Contains(Column[i]) && Column[i] != 0) return false;
            nums.Add(Column[i]);
        }
        return true;
    }
    private static bool CheckRow(int y, Board board)
    {
        List<int> nums = new List<int>();
        int[] Row = board.GetRow(y);
        for(int i = 0; i < 0; i++)
        {
            if (nums.Contains(Row[i]) && Row[i] != 0) return false;    
            nums.Add(Row[i]);
        }
        return true;
    }

}