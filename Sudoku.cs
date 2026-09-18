

public class Sudoku
{
    private Board board;
    private OutputManager outputManager;
    private BoardGenerator boardGenerator;
    private SudokuHider sudokuHider;
    private SudokuSolver? sudokuSolver;

    public Sudoku(OutputManager outputManager, BoardGenerator boardGenerator,
    SudokuHider sudokuHider)
    {
        this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        this.boardGenerator = boardGenerator ?? throw new ArgumentNullException(nameof(boardGenerator));
        this.sudokuHider = sudokuHider ?? throw new ArgumentNullException(nameof(SudokuHider));
        
        board = boardGenerator.Generate();
        board = sudokuHider.HideNumbers(board);    
    }
    public Sudoku(OutputManager outputManager, BoardGenerator boardGenerator,
    SudokuHider sudokuHider, SudokuSolver sudokuSolver) : this(outputManager, boardGenerator, sudokuHider)
    {
        this.sudokuSolver = sudokuSolver ?? throw new ArgumentNullException(nameof(sudokuSolver));
    }
    
    public void SetSolver(SudokuSolver solver)
    {
        sudokuSolver = solver ?? throw new ArgumentNullException(nameof(outputManager));
    }
    public void Solve()
    {
        board = sudokuSolver.Solve(board);
    }
    public void OutputBoard()
    {
        outputManager.OutputBoard(board);
    }
}