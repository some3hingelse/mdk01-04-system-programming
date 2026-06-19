const string diaryFile = "diary.txt";

while (true)
{
    Console.WriteLine("Дневник");
    bool diaryExists = File.Exists(diaryFile);
    Console.WriteLine(diaryExists
        ? "1. Очистить файл дневника"
        : "1. Создать файл дневника");
    Console.WriteLine("2. Добавить запись");
    Console.WriteLine("3. Прочитать все записи");
    Console.WriteLine("4. Показать количество строк");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    switch (Console.ReadLine())
    {
        case "1":
            File.Create(diaryFile).Dispose();
            Console.WriteLine(diaryExists
                ? "Файл дневника очищен."
                : $"Файл {diaryFile} создан.");
            break;

        case "2":
            Console.Write("Введите запись: ");
            string? entry = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entry))
            {
                Console.WriteLine("Пустая запись не добавлена.");
                break;
            }

            File.AppendAllText(diaryFile, entry + Environment.NewLine);
            Console.WriteLine("Запись добавлена.");
            break;

        case "3":
            if (!File.Exists(diaryFile))
            {
                Console.WriteLine("Сначала создайте дневник или добавьте запись.");
                break;
            }

            string[] entries = File.ReadAllLines(diaryFile);
            Console.WriteLine(entries.Length == 0
                ? "Дневник пока пуст."
                : string.Join(Environment.NewLine, entries));
            break;

        case "4":
            int lineCount = File.Exists(diaryFile)
                ? File.ReadLines(diaryFile).Count()
                : 0;
            Console.WriteLine($"Количество строк: {lineCount}");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Неизвестная команда.");
            break;
    }

    Console.WriteLine("\n\n");
}
