namespace MachineEvaluation
{
    public class MachineInFile : MachineBase
    {
        private const string fileName = "grades.txt";

        public override event GradeAddedDelegate GradeAdded;

        public MachineInFile(string name, string eq, string depeartment) : base(name, eq, depeartment)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, "Prawidłowo dodana wartość");
                    }
                }
            }
            else
            {
                throw new Exception("Niepoprawna wartość...");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }
        private Statistics CountStatistics(List<float> grades)
        {
            {
                var statistics = new Statistics();

                foreach (var grade in grades)
                {
                    statistics.AddGrade(grade);
                }

                return statistics;
            }
        }
    }
}
