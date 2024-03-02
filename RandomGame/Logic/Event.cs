﻿using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomGame
{
    class EventApplier
    {
        Estajho estajho;
        List<Event> events;
        public void LoopOn()
        {
            foreach (Event item in events)
            {
                if (Tools.Lucky(1D / item.Interval))
                {
                    item.Try();
                }
            }
        }
        public void RefreshEvents()
        {
            events.Clear();
            foreach (var item in Logic.save.GetList<Event>("event"))
            {
                if (item.IsFit())
                {
                    events.Add(item);
                }
            }
        }
        public EventApplier(Estajho estajho)
        {
            events = [];
            this.estajho = estajho;
        }
    }
    class Event
    {
        public string Id = "EVENT ID";
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
            Id = Logic.save.New("event", this);
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
        public bool IsFit()
        {
            foreach (Condition condition in Conditions)
            {
                if (!condition.IsTrue())
                {
                    return false;
                }
            }
            return true;
        }
        public void Try()
        {
            if (IsFit())
            {
                double possibility = 1D;
                foreach(var factor in Factors)
                {
                    possibility *= factor.Get();
                }
                if (Tools.Lucky(possibility))
                {
                    Perform();
                }
            }
        }
        public void Perform()
        {
            if (Type == EventType.Display)
            {
                Gui.OpenEventWindow(this);
            }
            foreach (Effect effect in Effects)
            {
                effect.Perform();
            }
            Debug.WriteLine($"{Id} performed.");
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
        public bool IsAvailable()
        {
            foreach (Condition condition in Conditions)
            {
                if (!condition.IsTrue())
                {
                    return false;
                }
            }
            return true;
        }
        public void Perform()
        {
            foreach (Effect effect in Effects)
            {
                effect.Perform();
            }
        }
    }
    class Condition
    {
        public ConditionType Type { get; set; } = ConditionType.True;
        public bool IsTrue()
        {
            return Type switch
            {
                ConditionType.True => true,
                ConditionType.False => false,
                _ => throw new NotImplementedException(),
            };
        }
    }
    enum ConditionType
    {
        True,
        False,
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
        public void Perform()
        {

            switch (Type)
            {
                case EffectType.DisplayMessage:
                    Gui.DisplayMessage(Message);
                    break;
                case EffectType.SaveSetD:
                    Logic.save.Set(SaveId, DoubleValue.Get());
                    break;
                case EffectType.SaveSetS:
                    Logic.save.Set(SaveId, StringValue.Get());
                    break;
                case EffectType.PerformCommand:
                    Command.Perform(CommandId);
                    break;
                case EffectType.PerformEvent:
                    Logic.save.Get<Event>(EventId).Perform();
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
        DisplayMessage,
        PerformEvent,
        PerformCommand,
    }
    class Factor
    {
        public FactorType type { get; set; } = FactorType.Static;
        public DoubleValue Value { get; set; } = new();
        public Condition FactorCondition { get; set; } = new Condition();
        public DoubleValue FactorTrue { get; set; } = new();
        public DoubleValue? FactorFalse { get; set; } = null;
        public double Get()
        {
            if (type == FactorType.Conditioned)
            {
                if (FactorCondition.IsTrue())
                {
                    return FactorTrue.Get();
                }
                else
                {
                    return FactorFalse.Get();
                }
            }
            else
            {
                return Value.Get();
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
        public string Get()
        {
            if (StringCondition.IsTrue())
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
        public double Get()
        {
            if (Type == ValueType.FactoredValue)
            {
                return (double)BasicValue.Get() * TheFactor.Get();
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
