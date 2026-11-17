using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(" Инициализация кольцевого буфера");
        ICircularBuffer<int> buffer = null;

        while (buffer == null)
        {
            try
            {
                Console.Write("Введите емкость буфера: ");
                int capacity = int.Parse(Console.ReadLine());
                buffer = new CircularBuffer<int>(capacity);
            }
            catch (InvalidCapacityException ex)
            {
                Console.WriteLine($"[Ошибка] {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("[Ошибка] Введите корректное целое число!");
            }
        }

        while (true)
        {
            Console.WriteLine("\n Меню");
            Console.WriteLine("1. Добавить элемент");
            Console.WriteLine("2. Показать буфер (foreach)");
            Console.WriteLine("3. Показать буфер (Reverse)");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите число для добавления: ");
                    if (int.TryParse(Console.ReadLine(), out int item))
                    {
                        buffer.Add(item);
                        Console.WriteLine($"Элемент {item} добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("[Ошибка] Нужно ввести число!");
                    }
                    break;

                case "2":
                    Console.Write("Буфер (от старых к новым): ");
                    foreach (var val in buffer) Console.Write(val + " ");
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Write("Буфер (от новых к старым): ");
                    foreach (var val in buffer.Reverse()) Console.Write(val + " ");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Выход из программы...");
                    return;

                default:
                    Console.WriteLine("[Ошибка] Неверный пункт меню.");
                    break;
            }
        }
    }
}