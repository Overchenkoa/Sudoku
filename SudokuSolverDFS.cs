public class SudokuSolverDFS
{
    public static bool hasOneSolution(int[,] board)
    {
        int[,] b1 = SolveAsc((int[,])board.Clone());
        int[,] b2 = SolveDesc((int[,])board.Clone());

        for(int y = 0; y < 9; y++)
        {
            for(int x = 0; x < 9; x++)
            {
                if(b1[y,x] != b2[y,x]) return false;
            }    
        }
        return true;
    }
    public static int[,] SolveAsc(int[,] board, int prevX = 0, int prevY = 0)
    {
        for(int y = prevY; y < 9; y++)
        {
            for(int x = prevX; x < 9; x++)
            {
                
                if(board[x,y] == 0)
                {
                    for(int i = 1; i <= 9; i++)
                    {
                        board[x,y] = i;
                        if (SolutionVerifier.IsFilledCorrectly(board))
                            board = SolveAsc(board,x,y);   
                    }
                }
            }    
        }
        return board;
    }
    public static int[,] SolveDesc(int[,] board, int prevX = 0, int prevY = 0)
    {
        for(int y = 8; y <= 0; y--)
        {
            for(int x = 8; x <= 0; x--)
            {
                if(board[x,y] == 0)
                {
                    for(int i = 9; i > 0; i--)
                    {
                        board[x,y] = i;
                        if (SolutionVerifier.IsFilledCorrectly(board))
                            board = SolveAsc(board,x,y);   
                    }
                    if(board[x,y] == 0) return board;
                }
            }    
        }
        return board;
    }
}