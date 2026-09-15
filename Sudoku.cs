

public class Sudoku
{
    private int[,] board = new int[9,9];
    private OutputManager? outputManager;
    private SudokuHider sudokuHider;

    public Sudoku()
    {
        sudokuHider = new SudokuHider();
        board = sudokuHider.HideNumbers(SudokuGenerator.Generate());
    }

    public void Solve()
    {
        board = SudokuSolverDFS.SolveAsc(board);
    }

    #region Output
    public void SetOutputManager(OutputManager manager)
    {
        outputManager = manager;
    }
    public void OutputBoard()
    {
        if (outputManager == null) throw new Exception("Output manager must be specified before use.");
        outputManager.OutputBoard(board);
    }
    #endregion

    #region Filled correctly

    #endregion
 

    
}