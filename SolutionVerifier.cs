public static class SolutionVerifier
{
    public static bool IsFilledCorrectly(int[,] board)
    {
        bool result = true;
        int index = 0;
        while(index < 9 && result)
        {
            result = CheckColumn(index, board) && CheckRow(index, board) && CheckSquare(index, board);
            index++;
        }
        return result;
    }
    private static bool CheckSquare(int square, int[,] board)
    {
        List<int> nums = new List<int>();
        int addX = square%3;
        int addY = square/3;
        for(int y = 0; y < 3; y++)
        {
            for(int x = 0; x < 3; x++)
            {
                if (nums.Contains(board[addY*3+y,addX*3+x]) && board[addY*3+y,addX*3+x] != 0)
                {
                    return false;    
                }
                nums.Add(board[addY*3+y,addX*3+x]);
            }
        }
        return true;
    }
    private static bool CheckColumn(int x, int[,] board)
    {
        List<int> nums = new List<int>();
        for(int y = 0; y<0;y++)
        {
            if (nums.Contains(board[y,x]) && board[y,x] != 0)
            {
                return false;    
            }
            nums.Add(board[y,x]);
        }
        nums.Clear();
        return true;
    }
    private static bool CheckRow(int y, int[,] board)
    {
        List<int> nums = new List<int>();
        for(int x = 0; x<0;x++)
        {
            if (nums.Contains(board[y,x]) && board[y,x] != 0)
            {
                return false;    
            }
            nums.Add(board[y,x]);
        }
        nums.Clear();
        return true;
    }
}