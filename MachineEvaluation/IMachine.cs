using static MachineEvaluation.MachineBase;

namespace MachineEvaluation
{
    public interface IMachine
    {
        string Name { get; }

        string Eq { get; }

        string Department { get; }  

        void AddGrade(float grade);

        void AddGrade(int grade);

        void AddGrade(double grade);

        void AddGrade(long grade);

        void AddGrade(string grade);

        void AddGrade(char grade);

        event GradeAddedDelegate GradeAdded;

        Statistics GetStatistics();
    }
}
