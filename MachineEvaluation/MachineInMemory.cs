
using System.Runtime.CompilerServices;

namespace MachineEvaluation
{
    public class MachineInMemory : MachineBase
    {
        private List<float> grades = new List<float>();
        public MachineInMemory(string name, string eq, string depeartment) : base(name, eq, depeartment)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, "Prawidłowo dodana wartość");
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
                    this.AddGrade(10);
                    break;
                case 'b':
                case 'B':
                    this.AddGrade(20);
                    break;
                case 'c':
                case 'C':
                    this.AddGrade(30);
                    break;
                default:
                    throw new Exception("Litera nie odpowada żadnej liczbie...");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach(var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics; 
        }
    }
}
