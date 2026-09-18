using System.Security.Cryptography.X509Certificates;

public class SolverDFS : SudokuSolver
{
    public override bool CanBeSolved(in Board board)
    {
        Board solution = board;
        return Solve(solution).isFilled();
    }

    public override bool CanBeSolved(in Board board, out Board result)
    {
        Board solution = board;
        result = Solve(solution);
        return result.isFilled();
    }

    public override bool HasOnlySolution(in Board board)
    {
        Board solution = board;
        Board solution1 = board;
        return Solve(solution1) == Solve(solution);
    }

    public override Board Solve(Board board)
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if (board[x, y] == 0)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (SolutionVerifier.CheckChange(board, x, y, i))
                        {
                            board[x, y] = i;              
                            if (Solve(board).isFilled()) 
                            {
                                return board;   
                            }
                            board[x, y] = 0;              
                        }
                    }
                    return board;
                }
            }
        }
        return board;
    }
    private Board SolveDesc(Board board)
    {
        for (int x = 8; x >= 0; x--)
        {
            for (int y = 8; y >= 0; y--)
            {
                if (board[x, y] == 0)
                {
                    for (int i = 9; i >= 1; i--)
                    {
                        if (SolutionVerifier.CheckChange(board, x, y, i))
                        {
                            board[x, y] = i;              
                            if (SolveDesc(board).isFilled()) 
                            {
                                return board;   
                            }
                            board[x, y] = 0;              
                        }
                    }
                    return board;
                }
            }
        }
        return board;
    }
}