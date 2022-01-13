using GameOfLife.Console;
using GameOfLife.Core;

Console.WriteLine("Enter path and filename (*.txt) for Game of Life: ");
var pathAndFileName = Console.ReadLine();
if (string.IsNullOrWhiteSpace(pathAndFileName))
{
    Console.WriteLine("No file name was provided.");
    return;
}

var rawModel = FileManager.LoadTextFile(pathAndFileName, out string fileErrorMessage);
if (rawModel is null)
{
    Console.WriteLine(fileErrorMessage);
    return;
}

var model = ModelBuilder.Build(rawModel, out string modelErrorMessage);
if (model is null)
{
    Console.WriteLine(modelErrorMessage);
    return;
}

var modelOutput = ModelRunner.EvolveComplete(model);
foreach (var modelRow in ModelBuilder.BuildRaw(modelOutput))
{
    Console.WriteLine(modelRow);
}

Console.WriteLine("");
Console.WriteLine("Operation complete.");





