public class ConsoleOutputManager : OutputManager
{
    public override void OutputBoard(int[,] board)
    {
        for(int y = 0; y<9; y++)
        {
            for(int x = 0; x<9;x++)
            {
                Console.Write(board[y,x] + "  ");           
                if(x!= 8 && x%3 == 2) Console.Write("|  ");
            }
            Console.WriteLine();
            if(y!= 8 && y%3 == 2) Console.WriteLine("-------------------------------");
        }
    }
}