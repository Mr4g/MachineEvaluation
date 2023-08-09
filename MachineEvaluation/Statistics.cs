namespace MachineEvaluation
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return Sum / this.Count;
            }
        }

        public int LevelTpm
        {
            get
            {
                switch (this.Sum)
                {
                    case var sum when sum >= 30:
                        return 3;
                    case var sum when sum >= 20:
                        return 2;
                    case var sum when sum    >= 10:
                        return 1;
                    default:
                        return 0;
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddGrade(float grade) 
        {
            this.Count++;
            this.Sum += grade;  
            this.Min = Math.Min(grade , this.Min);
            this.Max = Math.Max(grade, this.Max);
        }
    }
}
