public abstract class SudokuSolver
{
    public abstract bool CanBeSolved(in Board board);
    public abstract bool CanBeSolved(in Board board, out Board result);
    public abstract bool HasOnlySolution(in Board board);
    public abstract Board Solve(Board board);
}