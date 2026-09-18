using System.Linq;
public class SudokuHider
{
    private Board tempBoard;
    
    public Board HideNumbers(Board board)
    {
        Random random = new Random();
        int operations = 61;
        for(int i = 0; i < operations; i++)
        {
            while(true)
            {
                tempBoard = board;
                int x = random.Next(9),y = random.Next(9);
                if (tempBoard[x,y] == 0) continue;
                else tempBoard[x,y] = 0;
                if(i <= 2) break;
                if (HasOneSolution(tempBoard)) break;
            }
            board = tempBoard;
        }
        return board;
    }
    private bool HasOneSolution(Board board)
    {
        SolverDFS solver = new SolverDFS();
        return solver.HasOnlySolution(board.Copy());
    }
}