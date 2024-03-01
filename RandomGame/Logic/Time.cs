namespace RandomGame
{
    class Time
    {
        public int hour = 0;
        public int day = 0;
        public void PassHour()
        {
            EstajhoLoop();
            hour++;
        }
        public void EstajhoLoop()
        {
            List<object> list = Logic.save.GetList("estajho");
            foreach (object item in list)
            {
                ((Estajho)item).eventApplier.LoopOn();
            }
        }
        public void PassHours(int hours)
        {
            for (int i = 0; i < hours; i++)
            {
                PassHour();
            }
        }
        public override string ToString()
        {
            return $"Day {day}\nHour {hour}";
        }
    }
}
