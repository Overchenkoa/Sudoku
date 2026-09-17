public class SudokuSolverDFS
{
    public int[,] Solve(int[,] board)
    {
        if (SolveRec(board))
            return board;
        return null;
    }

    private bool SolveRec(int[,] board)
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (board[y, x] == 0)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (SolutionVerifier.CheckChange(board, x, y, i))
                        {
                            board[y, x] = i;              
                            if (SolveRec(board)) 
                            {
                                return true;              
                            }
                            board[y, x] = 0;              
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }
}