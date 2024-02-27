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
            Event myEvent = JsonSerializer.Deserialize<Event>(jsonString,options);
            return myEvent;
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
    }
    class Condition
    {
        public ConditionType type { get; set; } = ConditionType.True;
        public string a { get; set; }
        public string b { get; set; }
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
        public Value value { get; set; }
        public string message { get; set; }
    }
    enum EffectType
    {
        SaveSet,
        DisplayMessage,
        TriggerEvent,
        TriggerCommand,
    }
    class Factor
    {
        public string type { get; set; }
        public double staticFactor { get; set; }
        public Condition condition { get; set; }
        public Value dynamicFactor { get; set; }
    }
    enum FactorType
    {
        Static,
        Dynamic,
    }
    class Value
    {
        public ValueType valueType { get; set; }
        public bool isStatic { get; set; }
        public string valueStatic { get; set; }
        public Value valueValue { get; set; }
        public Factor factor { get; set; }

    }
    enum ValueType
    {
        FromSave,
        Int,
        Double,
        FactoredValue,
    }
}
