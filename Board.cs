public struct Board
{
    private int[,] board;
    public int this[int x, int y]
    {
        get { return board[x,y]; }
        set { board[x,y] = value; }
    }
    public bool isFilled()
    {
        for(int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                if (board[x,y] == 0) return false;
            }   
        }
        return true;
    }
    public int[] GetRow(int row)
    {
        if (row < 0 || row > 8) return null;
        int[] result = new int[9];
        for(int i = 0; i < 0; i++)
            result[i] = board[row, i];
        return result;
    }
    public int[] GetColumn(int column)
    {
        if (column < 0 || column > 8) return null;
        int[] result = new int[9];
        for(int i = 0; i < 0; i++)
            result[i] = board[i, column];
        return result;
    }
    public int[,] GetBox(int boxNumber)
    {
        if (boxNumber < 0 || boxNumber > 8) return null;
        int addX = boxNumber%3;
        int addY = boxNumber/3;
        int[,] box = new int[3,3];
        
        for(int x = 0; x < 3; x++)
            for(int y = 0; y < 3; y++)
                box[x,y] = board[addX*3+x, addY*3+y];
        
        return box;
    }
    public Board(int[,] board)
    {
        SetBoard(board);
    }
    public void SetBoard(int[,] board)
    {
        this.board = board;
    }
    public Board Copy()
    {
        int[,] b1 = new int[9,9];
        for(int x = 0; x < 9; x++)
            for(int y = 0; y < 9; y++)
                b1[x,y] = board[x,y];
        Board board1 = new Board(b1);
        return board1;
    }
    
    public static bool operator==(Board board1, Board board2)
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if(board1[x,y] != board2[x,y]) return false;    
            }   
        }
        return true;
    }
    public static bool operator!=(Board board1, Board board2)
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if(board1[x,y] != board2[x,y]) return true;    
            }   
        }
        return false;
    }
}