namespace MachineEvaluation
{
    public class MachineInMemory : MachineBase
    {

        public MachineInMemory(string name, string eq, string depeartment) : base(name, eq, depeartment)
        {
        }

        public override Statistics GetStatistics()
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
