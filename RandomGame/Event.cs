using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Event
    {
        List<Condition> nessesaryConditions;
        List<Factor> probabilityFactors;
        List<Influence> influences;
        List<Factor> influenceFactors;
        List<Selection> selections;
        string text;
    }
    class EventApplier
    {
        public void Try()
        {

        }
        private void TryLoad()
        {

        }
        private void TryEvent(Event thisEvent)
        {

        }
        private void LoadEvent()
        {

        }
    }

    class Selection
    {

    }
    class Condition
    {
        public ConditionType type { get; set; }
        public string a { get; set; }
        public string b { get; set; }
    }
    class Influence
    {
        public ConditionType type { get; set; }
        public string a { get; set; }
        public string b { get; set; }
    }
    
    class Factor
    {
        public string type { get; set; }
        public double factor { get; set; }
    }
    enum ConditionType
    {
        Equal,
        NotEqual,
    }

    class Value
    {
        ValueType valueType { get; set; }
        string value { get; set; }
    }

    enum ValueType
    {
        FromSave,
        String,
    }
}
