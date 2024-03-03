using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomGame
{
    class EventApplier
    {
        public EventApplierType Type { get; set; } = EventApplierType.Global;
        public string? Id { get; set; }
        public Estajho? estajho;
        List<Event> events;
        public void LoopOn()
        {
            foreach (Event item in events)
            {
                if (Tools.Lucky(1D / item.Interval))
                {
                    item.Try(this);
                }
            }
        }
        public void RefreshEvents()
        {
            events.Clear();
            foreach (var item in Logic.save.GetList<Event>("event"))
            {
                if (item.IsFit(this))
                {
                    events.Add(item);
                }
            }
        }
        public void DecideOnEvent(Event thisEvent)
        {
            // ...
        }
        public EventApplier(Estajho estajho)
        {
            Type = EventApplierType.Estajho;
            events = [];
            this.estajho = estajho;
            Id = estajho.id;
        }
        public EventApplier()
        {
            Type = EventApplierType.Global;
            events = [];
        }
    }
    enum EventApplierType
    {
        Global,
        Estajho,
    }
    class Event
    {
        public string id = "EVENT ID";
        public string Subtitle { get; set; } = "";
        public int Interval { get; set; } = 24;
        public List<Condition> Conditions { get; set; } = [];
        public List<Factor> Factors { get; set; } = [];
        public EventType Type { get; set; } = EventType.Silent;
        public string Name { get; set; } = "EVENT NAME";
        public string Description { get; set; } = "EVENT DESCRIPTION";
        public List<Selection> Selections { get; set; } = new List<Selection>();
        public List<Effect> Effects { get; set; } = [];
        public void Initialize()
        {
            if (Subtitle == "")
            {
                id = Logic.save.New("event", this);
            }
            else
            {
                id = Logic.save.New("event", Subtitle, this);
            }
        }
        public static Event FromJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            JsonSerializerOptions options = new();
            options.Converters.Add(new JsonStringEnumConverter());
            Event? myEvent = JsonSerializer.Deserialize<Event>(jsonString, options);
            myEvent.Initialize();
            return myEvent;
        }
        public bool IsFit(EventApplier applier)
        {
            foreach (Condition condition in Conditions)
            {
                if (!condition.IsTrue(applier))
                {
                    return false;
                }
            }
            return true;
        }
        public void Try(EventApplier applier)
        {
            if (IsFit(applier))
            {
                double possibility = 1D;
                foreach (var factor in Factors)
                {
                    possibility *= factor.Get(applier);
                }
                if (Tools.Lucky(possibility))
                {
                    Perform(applier);
                }
            }
        }
        public void Perform(EventApplier applier)
        {
            if (Type == EventType.Display)
            {
                if (applier.estajho.id == Logic.save.playerId)
                {
                    Gui.OpenEventWindow(this, applier);
                }
                else
                {
                    applier.DecideOnEvent(this);
                }
            }
            foreach (Effect effect in Effects)
            {
                effect.Perform(applier);
            }
            Debug.WriteLine($"{id} performed on {applier.Id}");
        }
        static void EventToJsonFile(Event thisEvent, string fileName)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            string jsonString = JsonSerializer.Serialize(thisEvent, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
    enum EventType
    {
        Silent,
        Display
    }
    class Selection
    {
        public List<Condition> Conditions { get; set; } = [];
        public string Text { get; set; } = "SELECTION TEXT";
        public List<Effect> Effects { get; set; } = [];
        public bool IsAvailable(EventApplier applier)
        {
            foreach (Condition condition in Conditions)
            {
                if (!condition.IsTrue(applier))
                {
                    return false;
                }
            }
            return true;
        }
        public void Perform(EventApplier applier)
        {
            foreach (Effect effect in Effects)
            {
                effect.Perform(applier);
            }
        }
    }
    class Condition
    {
        public ConditionType Type { get; set; } = ConditionType.True;
        public Condition? SubCondition { get; set; } = null;
        public Condition? SubConditionA { get; set; } = null;
        public Condition? SubConditionB { get; set; } = null;
        public StatoType StatoType { get; set; }
        public bool IsTrue(EventApplier applier)
        {
            return Type switch
            {
                ConditionType.True => true,
                ConditionType.False => false,
                ConditionType.And => SubConditionA.IsTrue(applier) && SubConditionB.IsTrue(applier),
                ConditionType.Or => SubConditionA.IsTrue(applier) || SubConditionB.IsTrue(applier),
                ConditionType.Not => !SubCondition.IsTrue(applier),
                ConditionType.HaveStato => applier.estajho.mensastatos.IsHave(StatoType),
                ConditionType.IsPlayer => applier.Id == Logic.save.playerId,
                ConditionType.NotPlayer => applier.Id != Logic.save.playerId,
                _ => throw new NotImplementedException(),
            };
        }
    }
    enum ConditionType
    {
        True,
        False,
        And,
        Or,
        Not,
        IsPlayer,
        NotPlayer,
        HaveStato,
    }
    class Effect
    {
        public EffectType Type { get; set; } = EffectType.DisplayMessage;
        public string Message { get; set; } = "EFFECT MESSAGE";
        public string SaveId { get; set; } = "SAVE ID";
        public string EventId { get; set; } = "EVENT ID";
        public string CommandId { get; set; } = "COMMAND ID";
        public DoubleValue? DoubleValue { get; set; } = null;
        public ConditionedString? StringValue { get; set; } = null;
        public StatoType StatoType { get; set; }
        public void Perform(EventApplier applier)
        {
            switch (Type)
            {
                case EffectType.DisplayMessage:
                    Gui.DisplayMessage(Message);
                    break;
                case EffectType.SaveSetD:
                    Logic.save.Set(SaveId, DoubleValue.Get(applier));
                    break;
                case EffectType.SaveSetS:
                    Logic.save.Set(SaveId, StringValue.Get(applier));
                    break;
                case EffectType.PerformCommand:
                    Command.Perform(CommandId);
                    break;
                case EffectType.PerformEvent:
                    Logic.save.Get<Event>(EventId).Perform(applier);
                    break;
                case EffectType.AddStato:
                    applier.estajho.mensastatos.Add(StatoType);
                    break;
                case EffectType.RemoveStato:
                    applier.estajho.mensastatos.Remove(StatoType);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
    enum EffectType
    {
        SaveSetD,
        SaveSetS,
        AddStato,
        RemoveStato,
        DisplayMessage,
        PerformEvent,
        PerformCommand,
    }
    class Factor
    {
        public FactorType Type { get; set; } = FactorType.Static;
        public DoubleValue Value { get; set; } = new();
        public Condition FactorCondition { get; set; } = new Condition();
        public DoubleValue FactorTrue { get; set; } = new();
        public DoubleValue? FactorFalse { get; set; } = null;
        public double Get(EventApplier applier)
        {
            if (Type == FactorType.Conditioned)
            {
                if (FactorCondition.IsTrue(applier))
                {
                    return FactorTrue.Get(applier);
                }
                else
                {
                    return FactorFalse.Get(applier);
                }
            }
            else
            {
                return Value.Get(applier);
            }
        }
    }
    enum FactorType
    {
        Static,
        Conditioned,
    }
    class ConditionedString
    {
        public Condition? StringCondition { get; set; } = null;
        public string ValueTrue { get; set; } = "STRING TRUE";
        public string ValueFalse { get; set; } = "STRING FALSE";
        public string Get(EventApplier applier)
        {
            if (StringCondition.IsTrue(applier))
            {
                return ValueTrue;
            }
            else
            {
                return ValueFalse;
            }
        }
    }
    class DoubleValue
    {
        public ValueType Type { get; set; } = ValueType.Double;
        public double Value { get; set; } = 1D;
        public string SaveId { get; set; } = "SAVE ID";
        public DoubleValue? BasicValue { get; set; } = null;
        public Factor? TheFactor { get; set; } = null;
        public double Get(EventApplier applier)
        {
            if (Type == ValueType.FactoredValue)
            {
                return (double)BasicValue.Get(applier) * TheFactor.Get(applier);
            }
            else if (Type == ValueType.Double)
            {
                return Value;
            }
            else if (Type == ValueType.FromSave)
            {
                return Logic.save.Get<double>(SaveId);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
    enum ValueType
    {
        FromSave,
        Double,
        FactoredValue,
    }
}
