using System;

class Program
{
    static void Main()
    {
        var buffer = new CircularBuffer<int>(3);

        Console.WriteLine("Добавляем 1, 2, 3:");
        buffer.Add(1);
        buffer.Add(2);
        buffer.Add(3);

        Console.WriteLine("Добавляем 4, 5 (перезапись старых):");
        buffer.Add(4);
        buffer.Add(5);

        Console.WriteLine("\nОбход через foreach (от старых к новым):");
        foreach (var item in buffer)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\nОбход через Reverse() (от новых к старым):");
        foreach (var item in buffer.Reverse())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}