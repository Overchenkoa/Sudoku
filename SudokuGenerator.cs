public class SudokuGenerator
{
    private static int[,] board = new int[9,9];

    #region Generation
    public static string GenerateSeed()
    {
        string seed = "";
        Random random = new Random();
        for(int i = 0; i<10; i++)
        {
            int r = random.Next(5);
            seed+=r;
        }
        return seed;
    }
    public static int[,] Generate(string seed)
    {
        GenerateBasic();
        return GenerateFromSeed(seed);
    }
    public static int[,] Generate()
    {
        GenerateBasic();
        string seed = GenerateSeed();
        return GenerateFromSeed(seed);
    }
    private static void GenerateBasic()
    {
        for(int y = 0; y<9; y++)
        {
            for(int x = 0; x<9;x++)
            {
                if(y/3 == 0)    board[y,x] = (1+x+y*3)%9;
                else    board[y,x] = (board[y%3,x]+y/3)%9;
                if(board[y,x] == 0) board[y,x] = 9;
            }
        }
    }
    private static int[,] GenerateFromSeed(string seed)
    {
        int method, parameter;
        for(int i = 0; i < 5; i++)
        {
            method = Convert.ToInt32(seed[i*2].ToString());
            parameter = Convert.ToInt32(seed[i*2+1].ToString());
            switch(method)
            {
                case 0:
                    SwapRows(parameter%3);
                break;
                case 1:
                    SwapColumns(parameter%3);
                break;
                case 2:
                    Transposition();
                break;
                case 3:
                    SwapAreaColumns();
                break;
                case 4:
                    SwapAreaRows();
                break;
            }
        }
        return board;
    }
    #endregion
    
    #region Swaps
    private static void SwapRows(int area)
    {
        int buffer;
        for(int x = 0; x < 9; x++)
        {
            buffer = board[area*3,x];
            board[area*3,x] = board[area*3+1,x];
            board[area*3+1,x] = board[area*3+2,x];
            board[area*3+2,x] = buffer;
        }
    }
    private static void SwapColumns(int area)
    {
        int buffer;
        for(int y = 0; y < 9; y++)
        {
            buffer = board[y,area*3];
            board[y,area*3] = board[y,area*3+1];
            board[y,area*3+1] = board[y,area*3+2];
            board[y,area*3+2] = buffer;
        }
    }
    private static void Transposition()
    {
        int buffer;
        for(int y = 0; y < 9; y++)
        {
            for(int x = y+1; x < 9; x++)
            {
                buffer = board[y,x];
                board[y,x] = board[x,y];
                board[x,y] = buffer;
            }   
        }
    }
    private static void SwapAreaRows()
    {
        int buffer;
        for (int y = 0; y < 3; y++){
            for(int x = 0; x < 9; x++)
            {
                buffer = board[y,x];
                board[y,x] = board[y+3,x];
                board[y+3,x] = board[y+6,x];
                board[y+6,x] = buffer;             
            }
        }
    }
    private static void SwapAreaColumns()
    {
        int buffer;
        for (int x = 0; x < 3; x++){
            for(int y = 0; y < 9; y++)
            {
                buffer = board[y,x];
                board[y,x] = board[y,x+3];
                board[y,x+3] = board[y,x+6];
                board[y,x+6] = buffer;             
            }
        }
    }
    #endregion
}