using System.Diagnostics;

namespace RandomGame
{
    class EventApplier
    {
        public EventApplierType Type;
        public Estajho? estajho;
        public string owner;
        List<Event> events;
        public void LoopOn()
        {
            foreach (Event @event in events)
            {
                @event.Try(this);
            }
        }
        public void RefreshEvents()
        {
            events.Clear();
            foreach (var @event in Logic.events)
            {
                if (@event.IsFit(this))
                {
                    events.Add(@event);
                }
            }
        }
        public EventApplier(Estajho estajho)
        {
            Type = EventApplierType.Estajho;
            events = [];
            this.estajho = estajho;
            owner = estajho.id;
        }
        public EventApplier()
        {
            Type = EventApplierType.Global;
            owner = "global";
            events = [];
        }
    }
    enum EventApplierType
    {
        Global,
        Estajho,
    }
    abstract class Event
    {
        public required string id = "";
        public bool isSilent = true;
        public string name = "DEFAULT EVENT NAME";
        public string description = "DEFAULT EVENT DESCRIPTION";
        public List<Selection>? selections;
        abstract public bool IsFit(EventApplier applier);
        abstract public bool IsLucky(EventApplier applier);
        abstract public bool PerformEffects(EventApplier applier);
        abstract public bool SelectionsAutoDecide(EventApplier applier);
        public void Try(EventApplier applier)
        {
            if (IsFit(applier) && IsLucky(applier))
            {
                Perform(applier);
            };
        }
        public void Perform(EventApplier applier)
        {
            if (!isSilent && applier.estajho.id == Logic.save.Get<string>("global.player"))
            {
                Gui.OpenEventWindow(this, applier);
            }
            else
            {
                SelectionsAutoDecide(applier);
            }
            PerformEffects(applier);
            Debug.WriteLine($"{id} performed on {applier.owner}");
        }
    }
    abstract class Selection
    {
        public string text = "";
        abstract public bool IsAvailable(EventApplier applier);
        abstract public void Perform(EventApplier applier);
    }
}
