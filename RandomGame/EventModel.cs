using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace RandomGame
{
    class Event
    {
        public EventType type { get; set; }
        public EventInterval interval { get; set; }
        public List<Condition> conditions { get; set; }
        public List<Effect> effects { get; set; }
        public List<Factor> factors { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Selection> selections { get; set; }
        public static Event FromJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            Event myEvent = JsonSerializer.Deserialize<Event>(jsonString, options);
            return myEvent;
        }
        public bool IsShouldTrigger()
        {
            foreach (Condition condition in conditions)
            {
                if (!condition.isTrue())
                {
                    return false;
                }
            }
            return true;
        }
        public void Try()
        {
            if (!IsShouldTrigger())
            {
                return;
            }
            Trigger();
        }
        public void Trigger()
        {
            if (type == EventType.Display)
            {
                Debug.WriteLine(id);
                Console.WriteLine(name);
                Console.WriteLine(description);
                foreach (Selection selection in selections)
                {
                    Console.WriteLine(selection.text);
                    // ...
                }
            }
            foreach (Effect effect in effects)
            {
                effect.Trigger();
            }
        }
    }
    enum EventType
    {
        Silent,
        Display
    }
    enum EventInterval
    {
        Daily,
        Weeky,
        Monthy,
        Seaseny,
        Yearly,
    }
    class Selection
    {
        public List<Condition> conditions { get; set; }
        public string text { get; set; }
        public List<Effect> effects { get; set; }
        public bool IsAvailable()
        {
            foreach(Condition condition in conditions)
            {
                if (!condition.isTrue())
                {
                    return false;
                }
            }
            return true;
        }
        public void Trigger()
        {
            foreach(Effect effect in effects)
            {
                effect.Trigger();
            }
        }
    }
    class Condition
    {
        public ConditionType type { get; set; } = ConditionType.True;
        public string a { get; set; }
        public string b { get; set; }
        public bool isTrue()
        {
            switch (type)
            {
                case ConditionType.True:
                    return true;
                case ConditionType.False:
                    return false;
                default:
                    throw new NotImplementedException();
            }
        }
    }
    enum ConditionType
    {
        True,
        False,
        Equal,
        NotEqual,
        LargerThan,
        SmallerThan,
    }
    class Effect
    {
        public EffectType type { get; set; }
        public string id { get; set; }
        public DoubleValue doubleValue { get; set; }
        public ConditionedString stringValue { get; set; }
        public string message { get; set; }
        public string command { get; set; }
        public void Trigger()
        {
            Debug.WriteLine($"event {id} with type {type} triggered");
            switch (type)
            {
                case EffectType.DisplayMessage:
                    Console.WriteLine(message);
                    break;
                case EffectType.SaveSetD:
                    Program.save.Set(id, doubleValue.get());
                    break;
                case EffectType.SaveSetS:
                    Program.save.Set(id, stringValue.get());
                    break;
                case EffectType.TriggerCommand:
                    Command.Trigger(id);
                    break;
                case EffectType.TriggerEvent:
                    break;
                default: break;
            }
        }
    }
    enum EffectType
    {
        SaveSetD,
        SaveSetS,
        DisplayMessage,
        TriggerEvent,
        TriggerCommand,
    }
    class Factor
    {
        public Condition condition { get; set; }
        public DoubleValue factorTrue { get; set; }
        public DoubleValue factorFalse { get; set; }
        public double get()
        {
            if (condition.isTrue())
            {
                return (double)factorTrue.get();
            }
            else
            {

                return (double)factorFalse.get();
            }
        }
    }
    class ConditionedString
    {
        public Condition condition { get; set; } = new Condition();
        public string valueTrue { get; set; }
        public string valueFalse { get; set; }
        public string get()
        {
            if (condition.isTrue())
            {
                return valueTrue;
            }
            else
            {
                return valueFalse;
            }
        }
    }
    class DoubleValue
    {
        public ValueType type { get; set; }
        public double value { get; set; }
        public string id { get; set; }
        public DoubleValue basicValue { get; set; }
        public Factor factor { get; set; }
        public double get()
        {
            if (type == ValueType.FactoredValue)
            {
                return (double)basicValue.get() * factor.get();
            }
            else if (type == ValueType.Double)
            {
                return value;
            }
            else if (type == ValueType.FromSave)
            {
                return (double)Program.save.Get(id);
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
