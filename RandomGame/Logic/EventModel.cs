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
        public EventType Type { get; set; }
        public EventInterval Interval { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<Effect> Effects { get; set; }
        public List<Factor> Factors { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }
        public static Event FromJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            Event myEvent = JsonSerializer.Deserialize<Event>(jsonString, options);
            return myEvent;
        }
        public bool IsShouldPerform()
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
            if (!IsShouldPerform())
            {
                return;
            }
            Perform();
        }
        public void Perform()
        {
            if (Type == EventType.Display)
            {
                Debug.WriteLine(Id);
                Console.WriteLine(Name);
                Console.WriteLine(Description);
                foreach (Selection selection in Selections)
                {
                    Console.WriteLine(selection.Text);
                    // ...
                }
            }
            foreach (Effect effect in Effects)
            {
                effect.Perform();
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
        public List<Condition> TheConditions { get; set; }
        public string Text { get; set; }
        public List<Effect> Effects { get; set; }
        public bool IsAvailable()
        {
            foreach(Condition condition in TheConditions)
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
            foreach(Effect effect in Effects)
            {
                effect.Perform();
            }
        }
    }
    class Condition
    {
        public ConditionType Type { get; set; } = ConditionType.True;
        public string A { get; set; }
        public string B { get; set; }
        public bool IsTrue()
        {
            switch (Type)
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
        public EffectType Type { get; set; }
        public string Id { get; set; }
        public DoubleValue DoubleValue { get; set; }
        public ConditionedString StringValue { get; set; }
        public string Message { get; set; }
        public void Perform()
        {
            Debug.WriteLine($"event {Id} with Type {Type} triggered");
            switch (Type)
            {
                case EffectType.DisplayMessage:
                    Console.WriteLine(Message);
                    break;
                case EffectType.SaveSetD:
                    Program.save.Set(Id, DoubleValue.Get());
                    break;
                case EffectType.SaveSetS:
                    Program.save.Set(Id, DoubleValue.Get());
                    break;
                case EffectType.PerformCommand:
                    Command.Perform(Id);
                    break;
                case EffectType.PerformEvent:
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
        PerformEvent,
        PerformCommand,
    }
    class Factor
    {
        public Condition ConditionIn { get; set; }
        public DoubleValue FactorTrue { get; set; }
        public DoubleValue FactorFalse { get; set; }
        public double Get()
        {
            if (ConditionIn.IsTrue())
            {
                return (double)FactorTrue.Get();
            }
            else
            {

                return (double)FactorFalse.Get();
            }
        }
    }
    class ConditionedString
    {
        public Condition TheCondition { get; set; } = new Condition();
        public string ValueTrue { get; set; }
        public string ValueFalse { get; set; }
        public string Get()
        {
            if (TheCondition.IsTrue())
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
        public ValueType Type { get; set; }
        public double Value { get; set; }
        public string Id { get; set; }
        public DoubleValue BasicValue { get; set; }
        public Factor TheFactor { get; set; }
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
                return (double)Program.save.Get(Id);
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
