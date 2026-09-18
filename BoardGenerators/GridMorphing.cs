public class GridMorphingGenerator : BoardGenerator
{
    public override string GenerateSeed()
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
    private Board GenerateBasic()
    {
        int[,] basicBoard = new int[9,9];
        for(int x = 0; x<9;x++)
        {
            for(int y = 0; y<9;y++)
            {
                if(x/3 == 0)    basicBoard[x,y] = (1+y+x*3)%9;
                else    basicBoard[x,y] = (basicBoard[x%3,y]+x/3)%9;
                if(basicBoard[x,y] == 0) basicBoard[x,y] = 9;
            }
        }
        return new Board(basicBoard);
    }
    public override Board Generate()
    {
        seed = GenerateSeed();
        return Generate(seed);
    }
    public override Board Generate(string seed)
    {
        board = GenerateBasic();
        int method, parameter;
        for(int i = 0; i < seed.Length/2; i++)
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
                case 9:
                return board;
            }
        }
        return board;
    }
    
    #region Swaps
    private void SwapRows(int area)
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
    private void SwapColumns(int area)
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
    private void Transposition()
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
    private void SwapAreaRows()
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
    private void SwapAreaColumns()
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