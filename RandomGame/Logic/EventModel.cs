using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomGame
{
    class Event
    {
        public EventType Type { get; set; } = EventType.Silent;
        // Hours
        public int Interval { get; set; } = 24;
        public List<Condition> Conditions { get; set; } = [];
        public List<Effect> Effects { get; set; } = [];
        public List<Factor> Factors { get; set; } = [];
        public string Id { get; set; } = "EVENT ID";
        public string Name { get; set; } = "EVENT NAME";
        public string Description { get; set; } = "EVENT DESCRIPTION";
        public List<Selection> Selections { get; set; } = new List<Selection>();
        public static Event FromJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            JsonSerializerOptions options = new();
            options.Converters.Add(new JsonStringEnumConverter());
            Event? myEvent = JsonSerializer.Deserialize<Event>(jsonString, options);
            return myEvent ?? throw new Exception("Deserialized object is null");
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
        public static void EventUnitTest()
        {
            if (!Directory.Exists("unit-test-files"))
                Directory.CreateDirectory("unit-test-files");
            EventToJsonFile(GetEventSample(), "unit-test-files/sample-event.json");
            FromJsonFile("unit-test-files/sample-event.json");
        }
        public static void EventToJsonFile(Event thisEvent, string fileName)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            string jsonString = JsonSerializer.Serialize(thisEvent, options);
            File.WriteAllText(fileName, jsonString);
        }
        public static Event GetEventSample()
        {
            return new Event
            {
                Type = EventType.Display,
                Id = "event.1",
                Name = "Testing Event",
                Description = "Description",
                Selections = new List<Selection> { { new Selection { Text = "I am the Selection" } } },
                Conditions = new List<Condition> { { new Condition() } },
                Effects = new List<Effect> { { new Effect { Type = EffectType.DisplayMessage, Message = "a" } } },
            };
        }
    }
    enum EventType
    {
        Silent,
        Display
    }
    class Selection
    {
        public List<Condition> TheConditions { get; set; } = [];
        public string Text { get; set; } = "SELECTION TEXT";
        public List<Effect> Effects { get; set; } = [];
        public bool IsAvailable()
        {
            foreach (Condition condition in TheConditions)
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
        public string A { get; set; } = "A";
        public string B { get; set; } = "B";
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
        Equal,
        NotEqual,
        LargerThan,
        SmallerThan,
    }
    class Effect
    {
        public EffectType Type { get; set; } = EffectType.DisplayMessage;
        public string Id { get; set; } = "EFFECT ID";
        public DoubleValue? DoubleValue { get; set; } = null;
        public ConditionedString? StringValue { get; set; } = null;
        public string Message { get; set; } = "EFFECT MESSAGE";
        public void Perform()
        {
            Debug.WriteLine($"event {Id} with Type {Type} triggered");
            switch (Type)
            {
                case EffectType.DisplayMessage:
                    Console.WriteLine(Message);
                    break;
                case EffectType.SaveSetD:
                    Logic.save.Set(Id, DoubleValue.Get());
                    break;
                case EffectType.SaveSetS:
                    Logic.save.Set(Id, DoubleValue.Get());
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
        public Condition ConditionIn { get; set; } = new Condition();
        public DoubleValue? FactorTrue { get; set; } = null;
        public DoubleValue? FactorFalse { get; set; } = null;
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
        public Condition? TheCondition { get; set; } = null;
        public string ValueTrue { get; set; } = "STRING TRUE";
        public string ValueFalse { get; set; } = "STRING FALSE";
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
        public ValueType Type { get; set; } = ValueType.Double;
        public double Value { get; set; } = 1D;
        public string Id { get; set; } = "";
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
                return (double)Logic.save.Get(Id);
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
