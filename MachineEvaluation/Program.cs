using System.ComponentModel.DataAnnotations;
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
Console.WriteLine("||   Proszę przyznawać ocenę od 0-10                                                 ||");
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
    Console.WriteLine("Podaj nazwę maszn...");
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
    while (true)
    {
        Console.WriteLine($"Wprowadz punktację od 0-10 za wybrany punkt z listy oceny dostępnej na maszynie");
        var machine = new MachineInMemory(name, eq, department);
        machine.GradeAdded += HandleGradeAddedEvent;
        Console.WriteLine();
        Console.WriteLine();
        var grade = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            machine.AddGrade(grade);
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Niepoprawna wartość została dodana...");
        }
        Console.WriteLine("");
        Console.WriteLine("Jeśli chcesz zakończyć dodawanie punktów wybierz q");
        Console.WriteLine("Jeśli chcesz wyśiwetlić statystyki i przejśc do innego obiektu wybierz r");
        Console.WriteLine("Jeśli chcesz dodać nowy obiekt wbierz n");
        Console.WriteLine("Jeśli chcesz dodać kolejny punkt wybierz dowolny inny klawisz");
        var input = Console.ReadLine();
        if (input == "q")
        {
            break;
        }
        else if (input == "r")
        {
            var statistic = machine.GetStatistics();
            Console.WriteLine($"AVG: {statistic.Average:N2}");
            Console.WriteLine($"Average Letter: {statistic.LevelTpm}");
            Console.WriteLine($"Min: {statistic.Min}");
            Console.WriteLine($"Max: {statistic.Max}");
            break;
        }
    }
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
}

