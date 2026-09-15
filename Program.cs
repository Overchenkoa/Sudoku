using System.Runtime.CompilerServices;

ConsoleOutputManager consoleOutputManager = new ConsoleOutputManager();
Sudoku sudoku = new Sudoku();
sudoku.SetOutputManager(consoleOutputManager);
sudoku.OutputBoard();

sudoku.Solve();
Console.WriteLine();
sudoku.OutputBoard();