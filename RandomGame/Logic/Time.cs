namespace RandomGame
{
    class Time
    {
        public int hour { get; set; }=0;
        public void Step()
        {
            EstajhoLoop();
            hour++;
            if (hour % 24 == 0)
            {
                Logic.RefreshEventAppliers();
            }
            (Gui.mainView.leftPane as MainWindow).UpdateTime();
        }
        public void EstajhoLoop()
        {
            var list = Logic.save.GetList<Estajho>("estajho");
            foreach (var item in list)
            {
                item.eventApplier.LoopOn();
            }
        }
        public override string ToString()
        {
            return $"Day {hour / 24}\nHour {hour % 24}";
        }
    }
}
