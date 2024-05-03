using System;

namespace Quiz;

public record Output
{
    public Output(
        string title,
        string content)
    {
        Console.WriteLine(title);
        Console.WriteLine(content);
        Console.WriteLine();
    }
}