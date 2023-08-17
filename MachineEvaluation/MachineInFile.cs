namespace MachineEvaluation
{
    public class MachineInFile : MachineBase
    {
        private const string fileName = "grades.txt";
        public MachineInFile(string name, string eq, string depeartment) : base(name, eq, depeartment)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

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

        public override void AddGrade(int grade)
        {
            float intGrade = grade;
            this.AddGrade(intGrade);
        }

        public override void AddGrade(double grade)
        {
            float doubleGrade = (float)grade;
            this.AddGrade(doubleGrade);
        }

        public override void AddGrade(long grade)
        {
            float longGrade = (float)grade;
            this.AddGrade(longGrade);
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float stringGrade))
            {
                this.AddGrade(stringGrade);
            }
            else
            {
                throw new Exception();
            }
        }

        public override void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'a':
                case 'A':
                    this.AddGrade(3);
                    break;
                case 'b':
                case 'B':
                    this.AddGrade(4);
                    break;
                case 'c':
                case 'C':
                    this.AddGrade(5);
                    break;
                default:
                    throw new Exception("Litera nie odpowada żadnej liczbie...");
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
