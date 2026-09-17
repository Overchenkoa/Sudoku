using System.Linq;
public class SudokuHider
{
    int[,] tempBoard = new int[9,9];
    
    public int[,] HideNumbers(int[,] board)
    {
        Random random = new Random();
        int operations = 20;
        bool hasOneSolution = false;
        for(int i = 0; i < operations; i++)
        {
            hasOneSolution = false;
            while(!hasOneSolution)
            {
                tempBoard = board;
                int x = random.Next(9),y = random.Next(9);
                if (tempBoard[y,x] == 0) continue;
                else tempBoard[y,x] = 0;
                //SudokuSolverDFS.hasOneSolution((int[,])tempBoard.Clone());
                Console.WriteLine(i + "/" + operations);
                hasOneSolution = true;
            }
            board = tempBoard;
        }
        return board;
    }
}