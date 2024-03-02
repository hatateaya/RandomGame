namespace RandomGame
{
    class Time
    {
        public int hour = 0;
        public void PassHour()
        {
            EstajhoLoop();
            hour++;
            if (hour % 24 == 0)
            {
                Logic.RefreshEventAppliers();
            }
        }
        public void EstajhoLoop()
        {
            var list = Logic.save.GetList<Estajho>("estajho");
            foreach (var item in list)
            {
                item.eventApplier.LoopOn();
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
            return $"Day {hour / 24}\n Hour {hour % 24}";
        }
    }
}
