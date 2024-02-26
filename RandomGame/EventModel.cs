using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Event
    {
        EventType type;
        EventInterval interval;
        List<Condition> conditions;
        List<Effect> effects;
        List<Factor> factors;
        string id;
        string name;
        string description;
        List<Selection> selections;
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
        Condition condition;
        string text;
        Effect effect;
    }
    class Condition
    {
        public ConditionType type { get; set; }
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
    interface Effect{}
    class SaveSetEffect
    {
        public string id { get; set; }
        public Value value { get; set; }
    }
    class DisplayMessageEffect
    {
        public string value { get; set; }
    }
    class TriggerEventEffect
    {
        public string id { get; set; }
    }
    class CommandEffect
    {
        public string command { get; set; }
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
        If,
        Factor,
    }
    class Value
    {
        ValueType valueType { get; set; }
        bool isStatic { get; set; }
        string valueStatic { get; set; }
        Value valueValue { get; set; }
        Factor factor { get; set; }

    }
    enum ValueType
    {
        FromSave,
        Int,
        Double,
        FactoredValue,
    }
}
