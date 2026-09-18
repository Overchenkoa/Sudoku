using System.Runtime.CompilerServices;

ConsoleOutputManager consoleOutputManager = new ConsoleOutputManager();
GridMorphingGenerator gridMorphingGenerator = new GridMorphingGenerator();
SudokuHider sudokuHider = new SudokuHider();
SolverDFS solverDFS = new SolverDFS();


Sudoku sudoku = new Sudoku(consoleOutputManager, gridMorphingGenerator, sudokuHider, solverDFS);
sudoku.OutputBoard();
//sudoku.Solve();
Console.WriteLine();
sudoku.OutputBoard();