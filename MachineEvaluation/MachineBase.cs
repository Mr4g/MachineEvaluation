
namespace MachineEvaluation
{

    public abstract class MachineBase : IMachine
    {
        public delegate void GradeAddedDelegate(object sender, string mx);

        public abstract event GradeAddedDelegate GradeAdded;  

        public MachineBase(string name, string eq, string depeartment)
        {
            this.Name = name;
            this.Eq = eq;
            this.Department = depeartment;  
        }
        public string Name { get; private set; }
        public string Eq { get; private set; }
        public string Department { get; private set; }

        public abstract void AddGrade(float grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(double grade);
        public abstract void AddGrade(long grade);
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(char grade);
        public abstract Statistics GetStatistics();
    }
}
