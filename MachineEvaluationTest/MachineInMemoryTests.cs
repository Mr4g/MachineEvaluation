using MachineEvaluation;

namespace MachineEvaluationTest
{
    public class MachineInMemoryTests
    {
        [Test]
        public void CreateObject_ShouldReturnNameEqDepartment()
        {
            // Arrange
            var machine = new MachineInMemory("MachineName", "MachineEQ", "Department");
            
            Assert.AreEqual("MachineName", machine.Name);
            Assert.AreEqual("MachineEQ", machine.Eq);
            Assert.AreEqual("Department", machine.Department);
        }

        [Test]
        public void AddGradeInt_ShouldAddCorrectStatistics()
        {
            // Arrange
            var machine = new MachineInMemory("MachineName", "MachineEQ", "Department");

            //act 
            machine.AddGrade(5);
            machine.AddGrade(6);
            machine.AddGrade(7);

            var statistic = machine.GetStatistics();
            Assert.AreEqual(5, statistic.Min);
            Assert.AreEqual(7, statistic.Max);
            Assert.AreEqual(6, statistic.Average);
        }
        public void AddGradeChar_ShouldReturnNumber()
        {
            // Arrange
            var machine = new MachineInMemory("MachineName", "MachineEQ", "Department");

            //act 
            machine.AddGrade('a');


            var statistic = machine.GetStatistics();
            Assert.AreEqual(3, statistic.Min);

        }
    }
}