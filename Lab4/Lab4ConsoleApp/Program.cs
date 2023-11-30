using McMaster.Extensions.CommandLineUtils;
using Lab4Classes;

class Program
{
    public static string GetPath(CommandOption<string> option, string defFileName)
    {
        string optionValue = option.Value();

        // Перевірка параметрів командного рядка для шляху вхідного файлу
        if (!string.IsNullOrEmpty(optionValue))
        {
            return optionValue;
        }

        // Перевірка змінної середовища "LAB_PATH" для шляху вхідного файлу
        string labPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (!string.IsNullOrEmpty(labPath))
        {
            return labPath + defFileName + ".txt";
        }

        // Якщо шлях вхідного файлу так і не знайдено, пошук в домашній директорії користувача
        string currentDirectory = Directory.GetCurrentDirectory();
        string defaultInputPath = Path.Combine(currentDirectory, defFileName + ".txt");

        if (File.Exists(defaultInputPath))
        {
            return defaultInputPath;
        }

        // Якщо жодна з умов не допомогла знайти вхідний файл, вивести помилку
        Console.WriteLine(defFileName + " file not found.");
        Environment.Exit(1); // Виходить із програми з кодом помилки

        return null; // Цей рядок ніколи не виконається, але потрібен для компіляції
    }

    static int Main(string[] args)
    {
        var app = new CommandLineApplication();
        app.Name = "lab4ConsoleApp";

        app.HelpOption("-?|-h|--help");

        app.Command("version", versionCmd =>
        {
            versionCmd.Description = "Display information about the version of the application and the author";

            versionCmd.OnExecute(() =>
            {
                Console.WriteLine("lab4ConsoleApp");
                Console.WriteLine("Author: Yehor Kostenko");
                Console.WriteLine("Ver: 1.0");
                return 0;
            });
        });

        app.Command("run", runCmd =>
        {
            runCmd.Description = "Launch of practical work";

            runCmd.Command("lab1", lab1Cmd =>
            {
                lab1Cmd.Description = "Launch of practical work -> 1";

                var inputOption = lab1Cmd.Option<string>("-I|--input", "Input file path", CommandOptionType.SingleValue);
                var outputOption = lab1Cmd.Option<string>("-o|--output", "Output file path", CommandOptionType.SingleValue);

                lab1Cmd.OnExecute(() =>
                {
                    string lab1Input = GetPath(inputOption, "input");
                    string lab1Output = GetPath(outputOption, "output");
                    Lab1 lab1 = new Lab1();
                    lab1.Run(lab1Input, lab1Output);
                    return 0;
                });
            });

            runCmd.Command("lab2", lab2Cmd =>
            {
                lab2Cmd.Description = "Launch of practical work -> 2";

                var inputOption = lab2Cmd.Option<string>("-I|--input", "Input file path", CommandOptionType.SingleValue);
                var outputOption = lab2Cmd.Option<string>("-o|--output", "Output file path", CommandOptionType.SingleValue);

                lab2Cmd.OnExecute(() =>
                {
                    string lab2Input = GetPath(inputOption, "input");
                    string lab2Output = GetPath(outputOption, "output");
                    Lab2 lab1 = new Lab2();
                    lab1.Run(lab2Input, lab2Output);
                    return 0;
                });
            });

            runCmd.Command("lab3", lab3Cmd =>
            {
                lab3Cmd.Description = "Launch of practical work -> 3";

                var inputOption = lab3Cmd.Option<string>("-I|--input", "Input file path", CommandOptionType.SingleValue);
                var outputOption = lab3Cmd.Option<string>("-o|--output", "Output file path", CommandOptionType.SingleValue);

                lab3Cmd.OnExecute(() =>
                {
                    string lab3Input = GetPath(inputOption, "input");
                    string lab3Output = GetPath(outputOption, "output");
                    Lab3 lab3 = new Lab3();
                    lab3.Run(lab3Input, lab3Output);
                    return 0;
                });
            });

            runCmd.OnExecute(() =>
            {
                Console.WriteLine("It is necessary to specify practical work (lab1, lab2, lab3)");
                return 1;
            });
        });

        app.Command("set-path", setPathCmd =>
        {
            setPathCmd.Description = "Set the path for input and output files.";
            var pathOption = setPathCmd.Option<string>("-p|--path", "The path to the directory with input and output files.", CommandOptionType.SingleValue);
            setPathCmd.OnExecute(() =>
            {
                string pathValue = pathOption.Value();
                if (!string.IsNullOrEmpty(pathValue))
                {
                    Environment.SetEnvironmentVariable("LAB_PATH", pathValue);
                    Console.WriteLine($"LAB_PATH has been set to: {pathValue}");
                }
                else
                {
                    Console.WriteLine("Please provide a valid path using the -p or --path option.");
                }
                return 0;
            });
        });

        app.OnExecute(() =>
        {
            Console.WriteLine("Unknown command or incorrect syntax.");
            app.ShowHelp();
            return 1;
        });

        return app.Execute(args);
    }
}