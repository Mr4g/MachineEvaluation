namespace MachineEvaluation
{

    public abstract class MachineBase : IMachine
    {
        public delegate void GradeAddedDelegate(object sender, string mx);

        public virtual event GradeAddedDelegate GradeAdded;

        public List<float> grades = new List<float>();

        public MachineBase(string name, string eq, string depeartment)
        {
            this.Name = name;
            this.Eq = eq;
            this.Department = depeartment;
        }
        public string Name { get; private set; }
        public string Eq { get; private set; }
        public string Department { get; private set; }

        public virtual void AddGrade(float grade)
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
        public void AddGrade(int grade)
        {
            float intGrade = grade;
            this.AddGrade(intGrade);
        }
        public void AddGrade(double grade)
        {
            float doubleGrade = (float)grade;
            this.AddGrade(doubleGrade);
        }
        public void AddGrade(long grade)
        {
            float longGrade = (float)grade;
            this.AddGrade(longGrade);
        }
        public void AddGrade(string grade)
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
        public void AddGrade(char grade)
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
        public abstract Statistics GetStatistics();
    }
}
