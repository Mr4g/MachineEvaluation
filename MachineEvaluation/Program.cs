using MachineEvaluation;

string windowWidth = "|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
Console.WindowWidth = windowWidth.Length;


Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                             Witamy w Ocenie stanu maszyny                         ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||   Proszę przyznać ocenę od 0-10                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||   Na podstawie ocen zostanie wyświetlona statysyka poziomu TPM od 0 do 3          ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("||                                                                                   ||");
Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
Console.WriteLine("");
Console.WriteLine("");

while  (true)
{
    Console.WriteLine("Podaj nazwę maszyny...");
    Console.WriteLine("");
    var name = Console.ReadLine();
    Console.WriteLine("Podaj EQ maszyny...");
    Console.WriteLine("");
    var eq = Console.ReadLine();
    Console.WriteLine("Podaj dział maszny ...");
    Console.WriteLine("");
    var department = Console.ReadLine();
    var machineName = $"{eq}_{name}_{department}";
    Console.WriteLine($"Pełna nazwa maszyny : {machineName}");
    Console.WriteLine("");
    Console.WriteLine("Wybierz czy będziesz pracować na pliku czy na pamięci..");
    Console.WriteLine("r - pamieć");
    Console.WriteLine("p - plik");
    MachineBase machine = null;

    while (true)
    {
        var workMode = Console.ReadLine();
        if (workMode == "r")
        {
            machine = new MachineInMemory(name, eq, department);
            break;
        }
        else if (workMode == "p")
        {
            machine = new MachineInFile(name, eq, department);
            break;
        }
        else
        {
            Console.WriteLine("Został źle wybrany tryb pracy...");
        }
    }

    machine.GradeAdded += HandleGradeAddedEvent;
    Console.WriteLine("q - zakończ");
    Console.WriteLine("r - statystyki i stworzenie nowego obiektu");
    Console.WriteLine("inny klawisz kontunuacja dodawania punktów");
    Console.WriteLine("");
    while (true)
    {
        Console.WriteLine($"Wprowadz punktację...");

        var grade = Console.ReadLine();
        if (grade == "q")
        {
            break;
        }
        else if (grade == "r")
        {
            var statistic = machine.GetStatistics();
            Console.WriteLine($"AVG: {statistic.Average:N2}");
            Console.WriteLine($"Poziom TPM: {statistic.LevelTpm}");
            Console.WriteLine($"Min: {statistic.Min}");
            Console.WriteLine($"Max: {statistic.Max}");
            Console.WriteLine($"Sum: {statistic.Sum}");
            Console.WriteLine($"Licznik: {statistic.Count}");
            break;
        }
        try
        {
            machine.AddGrade(grade);
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Niepoprawna wartość...");
            Console.WriteLine("");
        }     
    }
    Console.WriteLine("");
    Console.WriteLine("Jeśli chcesz zakończyć dodawanie punktów wybierz q");
    Console.WriteLine("Jeśli chcesz przeprowadzić ocenę nowej maszyny wybierz o");
    var input2 = Console.ReadLine();
    if (input2 == "q") 
    {
        break;
    }
}
void HandleGradeAddedEvent(object sender, string mx)
{
    Console.WriteLine($"{mx}");
    Console.WriteLine("");
}

